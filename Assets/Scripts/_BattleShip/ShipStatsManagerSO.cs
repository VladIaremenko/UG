using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipStatsManagerSO", menuName = "SO/Ship/ShipStatsManagerSO", order = 1)]
    public class ShipStatsManagerSO : ScriptableObject
    {
        [SerializeField] private ShipState _startState;

        private ShipViewModel _shipViewModel;
        private ShipState _currentState;

        public void Init(ShipViewModel shipViewModel)
        {
            _shipViewModel = shipViewModel;

            UpdateStats(new List<ShipModuleData>(), new List<ShipModuleData>());
        }

        public void UpdateStats(List<ShipModuleData> equipedWeapons, List<ShipModuleData> equipedUpgrades)
        {
            _currentState = new ShipState(_startState);

            foreach (var item in equipedUpgrades)
            {
                var upgrade = item as ShipUpgradeModule;
                _currentState.HP += upgrade.HPBonus;
                _currentState.Shield += upgrade.Shield;

                _currentState.ShieldRechargeRate *= 1 + upgrade.ShieldRechargeRateBonus / 100;
                _currentState.ShieldRechargeTime *= 1 + upgrade.ReloadTimeBonus / 100;
            }

            var stateViewData = new ShipStateViewData(
                _currentState.Shield, 
                _currentState.HP,
                _currentState.ShieldRechargeTime,
                _currentState.ShieldRechargeRate,
                new List<ShipWeaponViewData>()
                );

            foreach (var item in equipedWeapons)
            {
                var weapon = item as ShipWeaponModule;
                stateViewData.WeaponsData.Add(new ShipWeaponViewData(weapon.Damage, weapon.ReloadTime));
            }

            _shipViewModel.CurrentShipState.Value = stateViewData;
        }
    }
}