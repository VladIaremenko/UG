using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipModulesManagerSO", menuName = "SO/Ship/ShipModulesManagerSO", order = 1)]
    public class ShipModulesManagerSO : ScriptableObject
    {
        private ShipViewModel _shipViewModel;
        private ShipDataHolderSO _shipDataHolderSO;

        private List<ShipModuleData> _equipedWeapons = new List<ShipModuleData>();
        private List<ShipModuleData> _equipedUpgrades = new List<ShipModuleData>();

        public void Init(ShipViewModel shipViewModel, ShipDataHolderSO shipDataHolderSO)
        {
            _shipViewModel = shipViewModel;
            _shipDataHolderSO = shipDataHolderSO;
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
            var module = _shipDataHolderSO.Modules[id];

            switch (module.ModuleType)
            {
                case ModuleType.Upgrade:
                    HandleModule(module, _equipedUpgrades);
                    _shipViewModel.EquipeUpgradesData.Value = GetViewDataList(_equipedUpgrades);
                    break;
                case ModuleType.Weapon:
                    HandleModule(module, _equipedWeapons);
                    _shipViewModel.EquipedWeaponsData.Value = GetViewDataList(_equipedWeapons);
                    break;
                default:
                    break;
            }
        }

        private List<ShipModuleViewData> GetViewDataList(List<ShipModuleData> list)
        {
            return list.Select((x, i) => new ShipModuleViewData(x.Sprite, x.ID)).ToList();
        }

        private void HandleModule(ShipModuleData module, List<ShipModuleData> list)
        {
            if (list.Contains(module))
            {
                list.Remove(module);
            }
            else
            {
                list.Add(module);
            }
        }
    }
}


