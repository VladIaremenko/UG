using System;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    public abstract class ShipModuleData : ScriptableObject
    {
        public Sprite Sprite;
        public ModuleType ModuleType;

        [HideInInspector]
        public int ID;

        public abstract string GetDescriptionText();
    }
}


