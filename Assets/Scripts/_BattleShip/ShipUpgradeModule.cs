using System.Text;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipUpgradeModule", menuName = "SO/Ship/Module/ShipUpgradeModule", order = 1)]
    public class ShipUpgradeModule : ShipModuleData
    {
        public int Shield;
        public int HPBonus;
        public int ReloadTimeChangeBonus;
        public int ShieldRechargeBonus;

        public override string GetDescriptionText()
        {
            var str = new StringBuilder();

            if(Shield != 0)
            {
                str.Append($"Shield: {Shield}\n");
            }

            if (HPBonus != 0)
            {
                str.Append($"HPBonus: {HPBonus}\n");
            }

            if (ReloadTimeChangeBonus != 0)
            {
                str.Append($"Reload: {ReloadTimeChangeBonus}%\n");
            }

            if (ShieldRechargeBonus != 0)
            {
                str.Append($"ShieldRecharge: {ShieldRechargeBonus}%\n");
            }

            return str.ToString();
        }
    }
}


