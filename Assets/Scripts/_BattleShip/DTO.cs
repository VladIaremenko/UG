using System;
using System.Collections.Generic;
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
            ID = id;
            Description = description;
        }
    }

    [Serializable]
    public class ShipState
    {
        public float HP;
        public float Shield;

        [HideInInspector]
        public float MaxHP;
        [HideInInspector]
        public float MaxShield;

        public float ShieldRechargeTime;
        public float ShieldRechargeRate;

        [HideInInspector]
        public List<ShipWeaponModule> Weapons;

        public ShipState(ShipState state)
        {
            HP = state.HP;
            Shield = state.Shield;
            ShieldRechargeTime = state.ShieldRechargeTime;
            ShieldRechargeRate = state.ShieldRechargeRate;
        }
    }

    public class ShipStateViewData
    {
        public float HP;
        public float Shield;
        public float ShieldRechargeTime;
        public float ShieldRechargeRate;
        public List<ShipWeaponViewData> WeaponsData;

        public ShipStateViewData(float hP, float shield, float shieldRechargeTime, float shieldRechargeRate, List<ShipWeaponViewData> weaponsData)
        {
            HP = hP;
            Shield = shield;
            ShieldRechargeTime = shieldRechargeTime;
            ShieldRechargeRate = shieldRechargeRate;
            WeaponsData = weaponsData;
        }
    }

    public class ShipWeaponViewData
    {
        public float Damage;
        public float ReloadTime;

        public ShipWeaponViewData(float damage, float reloadTime)
        {
            Damage = damage;
            ReloadTime = reloadTime;
        }
    }

    public enum ModuleType
    {
        Upgrade,
        Weapon
    }
}


