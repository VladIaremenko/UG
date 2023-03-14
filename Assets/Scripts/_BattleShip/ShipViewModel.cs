using System;
using System.Collections.Generic;
using UGA.Assets.Scripts._BattleShip._Misc;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipViewModel", menuName = "SO/Ship/ShipViewModel", order = 1)]
    public class ShipViewModel : ScriptableObject
    {
        public event Action HandleRefreshViewRequest = new(() => { });

        public ObservableVariable<List<ShipModuleViewData>> ModulesData = new();

        public void RefreshView()
        {
            HandleRefreshViewRequest.Invoke();
        }
    }

    public class ShipModuleViewData
    {
        public Sprite Sprite;

        public ShipModuleViewData(Sprite sprige)
        {
            Sprite = sprige;
        }
    }
}


