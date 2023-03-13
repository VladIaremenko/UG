using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGA.Assets.Scripts._Algo
{
    public class PathCalculator : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private List<Route> _routes;

        private List<Station> _selectedStations = new List<Station>();

        private void Start()
        {
            Init();
        }

        public void CalculatePath()
        {
            //We will use A* pathfinding algo. Path lenght is irrenevant.
            //We just will look for smallest steps count and ignore distance.
            if (_selectedStations.Count < 2)
            {
                return;
            }

            List<Station> stationsToCheck = new();
            List<Station> visitedStations = new();
            List<Station> calculatedPath = new();

            var startStation = _selectedStations[0];
            var finishStation = _selectedStations[1];

            stationsToCheck.Add(startStation);

            //Try to find path in 100 steps
            for (int i = 0; i < 100; i++)
            {
                if (calculatedPath.Count > 0)
                {
                    return;
                }

                RunCalculation(finishStation, stationsToCheck, visitedStations, calculatedPath);
            }
        }

        [ContextMenu("Init")]
        public void Init()
        {
            foreach (var item in _routes)
            {
                item.Init();
            }
        }

        private void RunCalculation(Station finishStation, List<Station> stationsToCheck,
            List<Station> visitedStations, List<Station> calculatedPath)
        {
            var currentStation = stationsToCheck[0];

            if (visitedStations.Contains(currentStation))
            {
                return;
            }

            if (!stationsToCheck.Contains(currentStation))
            {
                stationsToCheck.Add(currentStation);
            }

            currentStation.ConnectedStations.Sort((x,y)=>CompareStations(x,y,finishStation));

            foreach (var item in currentStation.ConnectedStations)
            {
                if (visitedStations.Contains(item))
                {
                    continue;
                }

                item.ParentStation = currentStation;

                if (!stationsToCheck.Contains(item))
                {
                    stationsToCheck.Add(item);
                }

                if (item == finishStation)
                {
                    CalculateReturnPath(item, calculatedPath, 0);

                    item.ParentStation = null;

                    visitedStations.ForEach(x => x.ParentStation = null);
                    stationsToCheck.ForEach(x => x.ParentStation = null);
                }
            }

            stationsToCheck.Remove(currentStation);
            visitedStations.Add(currentStation);
        }

        private int CompareStations(Station x, Station y, Station finishStation)
        {
            var xDistance = Vector3.Distance(x.transform.position, finishStation.transform.position);
            var yDistance = Vector3.Distance(y.transform.position, finishStation.transform.position);

            return (int)xDistance - (int)yDistance;
        }

        private void CalculateReturnPath(Station station, List<Station> calculatedPath, int routeChanges)
        {
            calculatedPath.Add(station);

            if (station.ParentStation == null)
            {
                Debug.Log(routeChanges);

                _lineRenderer.positionCount = calculatedPath.Count;

                for (int i = 0; i < calculatedPath.Count; i++)
                {
                    _lineRenderer.SetPosition(i, calculatedPath[i].transform.position);
                }
            }
            else
            {
                if(CompareStationsRoutes(station, station.ParentStation))
                {
                    routeChanges++;
                }

                CalculateReturnPath(station.ParentStation, calculatedPath, routeChanges);
            }
        }

        private bool CompareStationsRoutes(Station station, Station parentStation)
        {
            foreach (var item in station.ParentRoutes)
            {
                foreach (var item2 in parentStation.ParentRoutes)
                {
                    if(item == item2)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.TryGetComponent(out Station station))
                    {
                        if (!_selectedStations.Contains(station))
                        {
                            _selectedStations.Add(station);

                            if (_selectedStations.Count > 2)
                            {
                                _selectedStations[0].transform.localScale = Vector3.one;
                                _selectedStations.RemoveAt(0);
                            }

                            foreach (var item in _selectedStations)
                            {
                                item.transform.localScale = Vector3.one * 2;
                            }
                        }
                    }
                }
            }
        }
    }
}


