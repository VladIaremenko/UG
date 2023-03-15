using System;
using System.Collections.Generic;
using UGA.Assets.Scripts._BattleShip._Misc;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip._UI
{
    public class EquipedWeaponsContainerView : MonoBehaviour, IHandleItemClick
    {
        private ShipViewModel _shipViewModel;
        [SerializeField] private List<ModuleButtonView> _buttonViews;

        public void HandleItemClick(int id)
        {
            _shipViewModel.HandleEquipItemClick(id);
        }

        public void Init(ShipViewModel shipViewModel)
        {
            HideAllItems();
            _shipViewModel = shipViewModel;
            _shipViewModel.EquipedWeaponsData.AddListener(RefreshView);
        }

        private void OnDisable()
        {
            _shipViewModel.EquipedWeaponsData.RemoveListener(RefreshView);
        }

        private void RefreshView(List<ShipModuleViewData> modulesList)
        {
            HideAllItems();

            for (int i = 0; i < modulesList.Count; i++)
            {
                _buttonViews[i].UpdateView(modulesList[i]);
                _buttonViews[i].gameObject.SetActive(true);
            }
        }

        private void HideAllItems()
        {
            for (int i = 0; i < _buttonViews.Count; i++)
            {
                _buttonViews[i].gameObject.SetActive(false);
            }
        }
    }
}


