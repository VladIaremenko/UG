using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip._UI
{
    public class AvailableItemsContainerView : MonoBehaviour
    {
        private ShipViewModel _shipViewModel;
        [SerializeField] private List<AvailableModuleButtonView> _buttonViews;

        public void Init(ShipViewModel shipViewModel)
        {
            _shipViewModel = shipViewModel;
            _shipViewModel.ModulesData.AddListener(RefreshView);
            _shipViewModel.RefreshView();
        }

        private void OnDisable()
        {
            _shipViewModel.ModulesData.RemoveListener(RefreshView);
        }

        private void RefreshView(List<ShipModuleViewData> modulesList)
        {
            for (int i = 0; i < _buttonViews.Count; i++)
            {
                _buttonViews[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < modulesList.Count; i++)
            {
                _buttonViews[i].UpdateView(modulesList[i]);
                _buttonViews[i].gameObject.SetActive(true);
            }
        }
    }
}


