using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    public class ShipBlockerView : MonoBehaviour
    {
        [SerializeField] private GameObject _blocker;
        private ShipViewModel _shipViewModel;

        public void Init(ShipViewModel shipViewModel)
        {
            _shipViewModel = shipViewModel;
            _shipViewModel.StartBattlingEvent += HandlStartBattling;
            _shipViewModel.StopBattlingEvent += HandleStopBattlingEvent;
        }

        private void OnDisable()
        {
            if (_shipViewModel != null)
            {
                _shipViewModel.StartBattlingEvent -= HandlStartBattling;
                _shipViewModel.StopBattlingEvent -= HandleStopBattlingEvent;
            }
        }

        private void HandleStopBattlingEvent()
        {
            _blocker.gameObject.SetActive(false);
        }

        private void HandlStartBattling()
        {
            _blocker.gameObject.SetActive(true);
        }

    }
}
