using UGA.Assets.Scripts._BattleShip._UI;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    public class InitShipObject : MonoBehaviour
    {
        [SerializeField] private ShipViewModel _shipViewModel;
        [SerializeField] private ShipDataHolderSO _shipDataHolderSO;
        [SerializeField] private ShipModulesManagerSO _shipModulesManagerSO;

        [SerializeField] private AvailableItemsContainerView _availableItemsContainerView;
        [SerializeField] private EquipedWeaponsContainerView _equipedWeaponsContainerView;

        private void Awake()
        {
            _shipViewModel = Instantiate(_shipViewModel);
            _shipDataHolderSO= Instantiate(_shipDataHolderSO);
            _shipModulesManagerSO = Instantiate(_shipModulesManagerSO);

            _shipDataHolderSO.Init(_shipViewModel);
            _availableItemsContainerView.Init(_shipViewModel);
            _shipModulesManagerSO.Init(_shipViewModel, _shipDataHolderSO);
            _equipedWeaponsContainerView.Init(_shipViewModel);
        }
    }
}


