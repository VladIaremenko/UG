using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipStatsManagerSO", menuName = "SO/Ship/ShipStatsManagerSO", order = 1)]
    public class ShipStatsManagerSO : ScriptableObject
    {
        [SerializeField] private ShipState _startState;
        private ShipState _currentState;

        public void UpdateModules(List<ShipModuleData> equipedWeapons, List<ShipModuleData> equipedUpgrades)
        {
            foreach (var item in equipedUpgrades)
            {

            }
        }
    }
}


