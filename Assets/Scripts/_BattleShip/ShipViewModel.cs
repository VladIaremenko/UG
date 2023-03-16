using System;
using System.Collections.Generic;
using UGA.Assets.Scripts._BattleShip._Misc;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipViewModel", menuName = "SO/Ship/ShipViewModel", order = 1)]
    public class ShipViewModel : ScriptableObject
    {
        public event Action RefreshViewRequestEvent = new(() => { });
        public event Action<int> EquipItemClickEvent = new((x) => { });
        public event Action<float> TakeDamageEvent = new((x) => { });

        public event Action StartBattlingEvent = new(() => { });
        public event Action StopBattlingEvent = new(() => { });

        public ObservableVariable<List<ShipModuleViewData>> AllModulesData = new();
        public ObservableVariable<List<ShipModuleViewData>> EquipedWeaponsData = new();
        public ObservableVariable<List<ShipModuleViewData>> EquipeUpgradesData = new();
        public ObservableVariable<ShipStateViewData> CurrentShipState = new();

        public void RefreshView()
        {
            RefreshViewRequestEvent.Invoke();
        }

        public void HandleEquipItemClick(int id)
        {
            EquipItemClickEvent.Invoke(id);
        }

        public void StartBattling()
        {
            StartBattlingEvent.Invoke();
        }

        public void StopBattling()
        {
            StopBattlingEvent.Invoke();
        }

        public void HandleTakeDamage(float damage)
        {
            TakeDamageEvent.Invoke(damage);
        }
    }
}


