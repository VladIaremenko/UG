using UGA.Assets.Scripts._BattleShip._Game;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    public class ShipAttackInterface : MonoBehaviour
    {
        private ShipViewModel _shipViewModel;

        public void Init(ShipViewModel shipViewModel)
        {
            _shipViewModel = shipViewModel;
        }

        public void HandleAttack(float damage)
        {
            _shipViewModel.HandleTakeDamage(damage);
        }
    }
}


