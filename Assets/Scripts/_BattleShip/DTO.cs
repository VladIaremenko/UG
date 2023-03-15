using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    public class ShipModuleViewData
    {
        public int ID;
        public Sprite Sprite;

        public ShipModuleViewData(Sprite sprige, int id)
        {
            Sprite = sprige;
            this.ID = id;
        }
    }

    public enum ModuleType
    {
        Upgrade,
        Weapon
    }
}


