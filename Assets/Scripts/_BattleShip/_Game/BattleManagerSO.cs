using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip._Game
{
    [CreateAssetMenu(fileName = "BattleManagerSO", menuName = "SO/Ship/BattleManagerSO", order = 1)]
    public class BattleManagerSO : ScriptableObject
    {
        private Dictionary<ShipAttackInterface, ShipWeaponManagerSO> _shipAttackInterfaces = new();

        public void Init(ShipAttackInterface shipAttackInterface, ShipWeaponManagerSO shipWeaponManagerSO)
        {
            _shipAttackInterfaces.Add(shipAttackInterface, shipWeaponManagerSO);
        }

        public void HandleAttack(float damage, ShipWeaponManagerSO source)
        {
            foreach (var item in _shipAttackInterfaces)
            {
                if(item.Value == source)
                {
                    continue;
                }

                item.Key.HandleAttack(damage);
            }
        }
    }
}


