using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._Algo
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private List<Route> _routes;

        private void Start()
        {

        }

        [ContextMenu("Draw")]
        public void DrawConnections()
        {
            foreach (var item in _routes)
            {
                item.Init();
            }
        }
    }
}


