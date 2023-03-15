using System.Collections;
using System.Collections.Generic;
using UGA.Assets.Scripts._BattleShip._Game;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipWeaponManagerSO", menuName = "SO/Ship/ShipWeaponManagerSO", order = 1)]
    public class ShipWeaponManagerSO : ScriptableObject
    {
        private ShipViewModel _shipViewModel;
        private MonoBehaviour _mono;
        private BattleManagerSO _battleManagerSO;
        private List<ShipModuleData> _equipedWeapons = new List<ShipModuleData>();
        private List<Coroutine> _coroutines = new List<Coroutine>();

        private void StartAttacking()
        {
            if (_equipedWeapons.Count == 0)
            {
                Debug.Log("No weapons");
            }

            StopAttacking();

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

            _coroutines.Clear();
        }

        public void UpdateWeapons(List<ShipModuleData> equipedWeapons)
        {
            _equipedWeapons = equipedWeapons;

        }
        public void Init(ShipViewModel shipViewModel, BattleManagerSO battleManagerSO, MonoBehaviour mono)
        {
            _mono = mono;
            _shipViewModel = shipViewModel;
            _battleManagerSO = battleManagerSO;

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

                _battleManagerSO.HandleAttack(damage, this);
            }
        }
    }
}


