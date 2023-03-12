using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._Algo
{
    public class Station : MonoBehaviour
    {
        [SerializeField] private List<Station> _connectedStations;
        [SerializeField] private List<LineRenderer> _renderers;

        internal void Init()
        {
            _renderers.Clear();

            foreach (var item in _connectedStations)
            {
                var renderer = gameObject.AddComponent<LineRenderer>();

                renderer.positionCount = 2;

                renderer.SetPosition(0, transform.position);
                renderer.SetPosition(0, item.transform.position);

                _renderers.Add(renderer);
            }            
        }
    }
}


