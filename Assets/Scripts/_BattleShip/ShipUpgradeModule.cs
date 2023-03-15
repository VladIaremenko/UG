using System.Text;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipUpgradeModule", menuName = "SO/Ship/Module/ShipUpgradeModule", order = 1)]
    public class ShipUpgradeModule : ShipModuleData
    {
        public float Shield;
        public float HPBonus;
        public float ReloadTimeBonus;
        public float ShieldRechargeRateBonus;

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

            if (ReloadTimeBonus != 0)
            {
                str.Append($"Reload: {ReloadTimeBonus}%\n");
            }

            if (ShieldRechargeRateBonus != 0)
            {
                str.Append($"ShieldRecharge: {ShieldRechargeRateBonus}%\n");
            }

            return str.ToString();
        }
    }
}


