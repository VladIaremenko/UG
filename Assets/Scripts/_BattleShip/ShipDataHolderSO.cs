using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipDataHolder", menuName = "SO/Ship/ShipDataHolder", order = 1)]
    public class ShipDataHolderSO : ScriptableObject
    {
        [SerializeField] private List<ShipModuleData> _shipModules;

        public List<ShipModuleData> Modules => _shipModules;
    }
}


