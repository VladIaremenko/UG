using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace UGA.Assets.Scripts._Algo
{
    public class Station : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private List<Station> _connectedStations;

        public List<Station> ConnectedStations => _connectedStations;
        public Route ParentRoute { get; set; }
        public Station ParentStation { get; set; }

        internal void TryAddStation(Station station)
        {
            if (!_connectedStations.Contains(station) && !station.IsUnityNull())
            {
                _connectedStations.Add(station);
            }
        }
    }
}


