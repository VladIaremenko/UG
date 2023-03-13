using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._Algo
{
    public class PathCalculator : MonoBehaviour
    {
        [SerializeField] private AlgoViewModel _algoViewModel;
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

                if (stationsToCheck.Count == 0)
                {
                    Debug.Log("Can't find path");

                    visitedStations.ForEach(x => x.ParentStation = null);
                    stationsToCheck.ForEach(x => x.ParentStation = null);

                    return;
                }
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

            currentStation.ConnectedStations.Sort((x, y) => CompareStations(x, y, finishStation));

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
                _lineRenderer.positionCount = calculatedPath.Count;

                CheckIntersections(calculatedPath);

                for (int i = 0; i < calculatedPath.Count; i++)
                {
                    _lineRenderer.SetPosition(i, calculatedPath[i].transform.position);
                }
            }
            else
            {
                CalculateReturnPath(station.ParentStation, calculatedPath, routeChanges);
            }
        }

        private void CheckIntersections(List<Station> calculatedPath)
        {
            var laneChanges = 0;

            for (int i = 0; i < calculatedPath.Count; i++)
            {
                if (i + 1 >= calculatedPath.Count)
                {
                    continue;
                }

                var current = calculatedPath[i];
                var next = calculatedPath[i + 1];

                if (current.ParentRoute != next.ParentRoute)
                {
                    laneChanges++;
                }
            }

            _algoViewModel.UpdateCalculationsData(calculatedPath.Count - 1, laneChanges);
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


