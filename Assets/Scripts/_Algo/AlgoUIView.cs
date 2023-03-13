using System;
using TMPro;
using UnityEngine;

namespace UGA.Assets.Scripts._Algo
{
    public class AlgoUIView : MonoBehaviour
    {
        [SerializeField] private AlgoViewModel _algoViewModel;
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            _algoViewModel.OnUpdateCalculationsEvent += HandleDataUpdate;
        }

        private void OnDisable()
        {
            _algoViewModel.OnUpdateCalculationsEvent -= HandleDataUpdate;
        }

        private void HandleDataUpdate(int steps, int laneChanges)
        {
            _text.text = $"Steps: {steps}\nLane changes: {laneChanges}";
        }
    }
}


