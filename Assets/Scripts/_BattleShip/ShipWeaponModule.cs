using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipWeaponModule", menuName = "SO/Ship/Module/ShipWeaponModule", order = 1)]
    public class ShipWeaponModule : ShipModuleData
    {
        public int ReloadTime;
        public int Damage;

        public override string GetDescriptionText()
        {
            return $"Damage: {Damage} Reload: {ReloadTime}";
        }
    }
}


