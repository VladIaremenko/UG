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

        public event Action StartAttackingEvent = new(() => { });
        public event Action StopAttackingEvent = new(() => { });

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

        public void StartAttacking()
        {
            StartAttackingEvent.Invoke();
        }

        public void StopAttacking()
        {
            StopAttackingEvent.Invoke();
        }
    }
}


