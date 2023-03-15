using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipUpgradeModule", menuName = "SO/Ship/Module/ShipUpgradeModule", order = 1)]
    public class ShipUpgradeModule : ShipModuleData
    {
        public override string GetDescriptionText()
        {
            return "Upgrade";
        }
    }
}


