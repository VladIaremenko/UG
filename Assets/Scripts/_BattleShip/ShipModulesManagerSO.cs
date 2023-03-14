using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipModulesManagerSO", menuName = "SO/Ship/ShipModulesManagerSO", order = 1)]
    public class ShipModulesManagerSO : ScriptableObject
    {
        private ShipViewModel _shipViewModel;

        private List<ShipModuleData> _equipedWeapons = new List<ShipModuleData>();
        private List<ShipModuleData> _equipedModules = new List<ShipModuleData>();

        public void Init(ShipViewModel shipViewModel)
        {
            _shipViewModel = shipViewModel;
            _shipViewModel.EquipItemClickEvent += HandleEquipItemClick;
        }

        public void OnDisable()
        {
            if (_shipViewModel != null)
            {
                _shipViewModel.EquipItemClickEvent -= HandleEquipItemClick;
            }
        }

        private void HandleEquipItemClick(int id)
        {
            Debug.Log(id);
        }
    }
}


