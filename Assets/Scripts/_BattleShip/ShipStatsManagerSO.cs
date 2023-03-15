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
            _shipViewModel.TakeDamageEvent += HandleDamage;

            UpdateStats(new List<ShipModuleData>(), new List<ShipModuleData>());
        }

        private void OnDisable()
        {
            _shipViewModel.TakeDamageEvent -= HandleDamage;
        }

        private void HandleDamage(float damage)
        {
            _currentState.Shield -= damage;

            if(_currentState.Shield < 0)
            {
                _currentState.HP += _currentState.Shield;
                _currentState.Shield = 0;
            }

            _shipViewModel.CurrentShipState.Value.Shield = _currentState.Shield;
            _shipViewModel.CurrentShipState.Value.HP = _currentState.HP;

            _shipViewModel.CurrentShipState.Value = _shipViewModel.CurrentShipState.Value;
        }

        public void UpdateStats(List<ShipModuleData> equipedWeapons, List<ShipModuleData> equipedUpgrades)
        {
            _currentState = new ShipState(_startState);
            _currentState.Weapons = new();

            foreach (var item in equipedUpgrades)
            {
                var upgrade = item as ShipUpgradeModule;
                _currentState.HP += upgrade.HPBonus;
                _currentState.Shield += upgrade.Shield;

                _currentState.ShieldRechargeRate *= 1 + upgrade.ShieldRechargeRateBonus / 100;
                _currentState.ShieldRechargeTime *= 1 + upgrade.ReloadTimeBonus / 100;
            }

            foreach (var item in equipedWeapons)
            {
                var weapon = item as ShipWeaponModule;
                _currentState.Weapons.Add(weapon);
            }

            var stateViewData = new ShipStateViewData(
                _currentState.HP, 
                _currentState.Shield,
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