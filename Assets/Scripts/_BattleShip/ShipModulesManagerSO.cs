using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipModulesManagerSO", menuName = "SO/Ship/ShipModulesManagerSO", order = 1)]
    public class ShipModulesManagerSO : MonoBehaviour
    {
        private List<ShipModuleData> _equipedWeapons = new List<ShipModuleData>();
        private List<ShipModuleData> _equipedModules = new List<ShipModuleData>();
    }
}


