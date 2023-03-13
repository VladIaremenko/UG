﻿using System.Collections.Generic;
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

            Calculate();
        }

        private void Calculate()
        {
            List<Station> visitedStations = new();
            List<Station> stationsToVisit = new();
            List<Station> nextRoundList = new();

            Refresh();

            var startStation = _selectedStations[0];
            var finishStation = _selectedStations[1];

            stationsToVisit.Add(startStation);

            for (int i = 0; i < 100; i++)
            {
                nextRoundList.Clear();

                foreach (var item in stationsToVisit)
                {
                    Debug.Log(item.name + "UPUPUP");

                    if (!visitedStations.Contains(item))
                    {
                        visitedStations.Add(item);
                    }
                    else
                    {
                        continue;
                    }

                    CheckSingleStation(item, startStation, finishStation, visitedStations, nextRoundList);

                    if (nextRoundList == null)
                    {
                        Debug.Log("NULL");
                        return;
                    }
                }

                Debug.Log(nextRoundList.Count);
                stationsToVisit = nextRoundList;
            }
        }

        private void Refresh()
        {
            foreach (var item in _routes)
            {
                item.Refresh();
            }
        }

        private void CheckSingleStation(Station currentStation, Station startStation, Station finistStation, List<Station> visitedStations, List<Station> nextRoundList)
        {
            Debug.Log("======================");

            //Debug.Log(currentStation.name + " :::: ");

            foreach (var item in currentStation.ConnectedStations)
            {
                if (visitedStations.Contains(item))
                {
                    continue;
                }

                if (item.ParentStation == null)
                {
                    item.transform.localScale = Vector3.one * 1.5f;
                    item.ParentStation = currentStation;
                }

                if (item == startStation)
                {
                    item.ParentStation = null;
                }

                if (item == finistStation)
                {
                    Debug.Log("Success");
                    CalculateReturnPath(item, startStation, new List<Station>());
                    return;
                }

                if(!nextRoundList.Contains(item))
                {
                    //Debug.Log(item.name);
                    nextRoundList.Add(item);
                }
            }

            //Debug.Log(nextRoundList.Count);
        }

        [ContextMenu("Init")]
        public void Init()
        {
            foreach (var item in _routes)
            {
                item.Init();
            }
        }


        private void CalculateReturnPath(Station station, Station startStation, List<Station> calculatedPath)
        {
            Debug.Log(station.name);

            calculatedPath.Add(station);

            if (station.ParentStation == null)
            {
                Debug.Log(calculatedPath.Count);

                _lineRenderer.positionCount = calculatedPath.Count;

                for (int i = 0; i < calculatedPath.Count; i++)
                {
                    _lineRenderer.SetPosition(i, calculatedPath[i].transform.position);
                }
            }
            else
            {
                CalculateReturnPath(station.ParentStation, startStation, calculatedPath);
            }
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


