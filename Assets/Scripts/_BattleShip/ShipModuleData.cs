using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipModuleData", menuName = "SO/Ship/ShipModuleData", order = 1)]
    public class ShipModuleData : ScriptableObject
    {
        public Sprite Sprite;
        public ModuleType ModuleType;
    }
}


