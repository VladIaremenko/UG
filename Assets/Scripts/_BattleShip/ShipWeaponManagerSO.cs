using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipWeaponManagerSO", menuName = "SO/Ship/ShipWeaponManagerSO", order = 1)]
    public class ShipWeaponManagerSO : ScriptableObject
    {
        private ShipViewModel _shipViewModel;
        private List<ShipModuleData> _equipedWeapons = new List<ShipModuleData>();
        private MonoBehaviour _mono;
        private List<Coroutine> _coroutines;

        private void StartAttacking()
        {
            foreach (var item in _equipedWeapons)
            {
                var weapon = item as ShipWeaponModule;
                var coroutine = _mono.StartCoroutine(AttackCoroutine(weapon.Damage, weapon.ReloadTime));
                _coroutines.Add(coroutine);
            }
        }

        private void StopAttacking()
        {
            foreach (var item in _coroutines)
            {
                _mono.StopCoroutine(item);
            }
        }

        public void UpdateWeapons(List<ShipModuleData> equipedWeapons)
        {
            _equipedWeapons = equipedWeapons;

        }
        public void Init(ShipViewModel shipViewModel, MonoBehaviour mono)
        {
            _mono = mono;
            _shipViewModel = shipViewModel;

            _shipViewModel.StartAttackingEvent += StartAttacking;
            _shipViewModel.StopAttackingEvent += StopAttacking;
        }

        private void OnDisable()
        {
            if (_shipViewModel != null)
            {
                _shipViewModel.StartAttackingEvent -= StartAttacking;
                _shipViewModel.StopAttackingEvent -= StopAttacking;
            }
        }

        private IEnumerator AttackCoroutine(float damage, float reloadTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(reloadTime);

                Debug.Log(damage);
            }
        }
    }
}


