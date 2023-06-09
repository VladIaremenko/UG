﻿using System;
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
        private ShipStatsManagerSO _shipStatsManagerSO;
        private ShipWeaponManagerSO _shipWeaponManagerSO;

        [SerializeField] private int _maxWeaponsCount;
        [SerializeField] private int _maxUpgradesCount;

        private List<ShipModuleData> _equipedWeapons = new List<ShipModuleData>();
        private List<ShipModuleData> _equipedUpgrades = new List<ShipModuleData>();

        public void Init(ShipViewModel shipViewModel, ShipDataHolderSO shipDataHolderSO, ShipStatsManagerSO shipStatsManagerSO, ShipWeaponManagerSO shipWeaponManagerSO)
        {
            _shipViewModel = shipViewModel;
            _shipDataHolderSO = shipDataHolderSO;
            _shipViewModel.EquipItemClickEvent += HandleEquipItemClick;
            _shipViewModel.StopBattlingEvent += HandleStopBattle;
            _shipStatsManagerSO = shipStatsManagerSO;
            _shipWeaponManagerSO = shipWeaponManagerSO;
        }

        public void OnDisable()
        {
            if (_shipViewModel != null)
            {
                _shipViewModel.EquipItemClickEvent -= HandleEquipItemClick;
                _shipViewModel.StopBattlingEvent -= HandleStopBattle;
            }
        }

        private void HandleStopBattle()
        {
            _shipStatsManagerSO.UpdateStats(_equipedWeapons, _equipedUpgrades);
        }

        private void HandleEquipItemClick(int id)
        {
            var module = _shipDataHolderSO.Modules[id];

            if (module.GetType() == typeof(ShipUpgradeModule))
            {
                HandleModuleList(module, _equipedUpgrades, _maxUpgradesCount);
                _shipViewModel.EquipeUpgradesData.Value = GetViewDataList(_equipedUpgrades);
            }
            if (module.GetType() == typeof(ShipWeaponModule))
            {
                HandleModuleList(module, _equipedWeapons, _maxWeaponsCount);
                _shipViewModel.EquipedWeaponsData.Value = GetViewDataList(_equipedWeapons);
            }

            _shipStatsManagerSO.UpdateStats(_equipedWeapons, _equipedUpgrades);
            _shipWeaponManagerSO.UpdateWeapons(_equipedWeapons);
        }

        private List<ShipModuleViewData> GetViewDataList(List<ShipModuleData> list)
        {
            return list.Select((x, i) => new ShipModuleViewData(x.Sprite, x.GetDescriptionText(), x.ID)).ToList();
        }

        private void HandleModuleList(ShipModuleData module, List<ShipModuleData> list, int maxAmount)
        {
            if (list.Contains(module))
            {
                list.Remove(module);
            }
            else
            {
                if (list.Count < maxAmount)
                {
                    list.Add(module);
                }
            }
        }
    }
}


