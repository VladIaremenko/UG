using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipWeaponModule", menuName = "SO/Ship/Module/ShipWeaponModule", order = 1)]
    public class ShipWeaponModule : ShipModuleData
    {
        public override string GetDescriptionText()
        {
            return "Weapon";
        }
    }
}


