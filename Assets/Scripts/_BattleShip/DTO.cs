using System;
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

    [Serializable]
    public class ShipState
    {
        public float StartHP;
        public float StartShield;
        public float ShieldRechargeTime;
        public float ShieldRechargeRate;

        public ShipState(float startHP, float startShield, float shieldRechargeTime, float shieldRechargeRate)
        {
            StartHP = startHP;
            StartShield = startShield;
            ShieldRechargeTime = shieldRechargeTime;
            ShieldRechargeRate = shieldRechargeRate;
        }
    }

    public enum ModuleType
    {
        Upgrade,
        Weapon
    }
}


