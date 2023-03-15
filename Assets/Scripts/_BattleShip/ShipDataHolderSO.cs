using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipDataHolder", menuName = "SO/Ship/ShipDataHolder", order = 1)]
    public class ShipDataHolderSO : ScriptableObject
    {
        private ShipViewModel _shipViewModel;
        [SerializeField] private List<ShipModuleData> _shipModules;

        public List<ShipModuleData> Modules => _shipModules;

        public void Init(ShipViewModel shipViewModel)
        {
            _shipViewModel = shipViewModel;
            _shipViewModel.RefreshViewRequestEvent += HandleRefreshRequest;
        }

        private void OnDisable()
        {
            if (_shipViewModel != null)
            {
                _shipViewModel.RefreshViewRequestEvent -= HandleRefreshRequest;
            }
        }

        private void HandleRefreshRequest()
        {
            _shipViewModel.AllModulesData.Value = _shipModules.Select((x, i) => {

                x.ID = i;
                return new ShipModuleViewData(x.Sprite, x.ID); 

            }).ToList();
        }
    }
}


