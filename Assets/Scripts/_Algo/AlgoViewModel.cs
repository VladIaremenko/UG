using System;
using UnityEngine;

namespace UGA.Assets.Scripts._Algo
{
    [CreateAssetMenu(fileName = "AlgoViewModel", menuName = "SO/Algo/AlgoViewModel", order = 1)]
    public class AlgoViewModel : ScriptableObject
    {
        public event Action<int, int> OnUpdateCalculationsEvent = new((x, y) => { });

        public void UpdateCalculationsData(int steps, int laneChanges)
        {
            OnUpdateCalculationsEvent.Invoke(steps, laneChanges);
        }
    }
}


