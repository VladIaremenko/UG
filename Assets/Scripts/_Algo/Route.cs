using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGA.Assets.Scripts._Algo
{
    public class Route : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private List<Station> _stations;

        [ContextMenu("Init")]
        internal void Init()
        {
            _lineRenderer.positionCount = _stations.Count;

            for (int i = 0; i < _stations.Count; i++)
            {
                _stations[i].ConnectedStations.Remove(_stations[i]);
            }

            for (int i = 0; i < _stations.Count; i++)
            {
                if (i > 0)
                {
                    _stations[i].TryAddStation(_stations[i - 1]);
                }

                if(i < _stations.Count - 1)
                {
                    _stations[i].TryAddStation(_stations[i + 1]);
                }

                _stations[i].ParentRoute = this;

                _lineRenderer.SetPosition(i, _stations[i].transform.position);
            }
        }

        internal void Refresh()
        {
            for (int i = 0; i < _stations.Count; i++)
            {
                _stations[i].ParentStation = null;
                _stations[i].name = gameObject.name + i;
            }
        }
    }
}
