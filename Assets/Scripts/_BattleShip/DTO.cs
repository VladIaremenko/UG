using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    public class ShipModuleViewData
    {
        public int ID;
        public Sprite Sprite;
        public string Description;

        public ShipModuleViewData(Sprite sprige, string description, int id)
        {
            Sprite = sprige;
            this.ID = id;
            Description = description;
        }
    }

    public enum ModuleType
    {
        Upgrade,
        Weapon
    }
}


