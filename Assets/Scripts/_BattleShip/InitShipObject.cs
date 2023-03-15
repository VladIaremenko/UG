using UGA.Assets.Scripts._BattleShip._UI;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    public class InitShipObject : MonoBehaviour
    {
        [SerializeField] private ShipViewModel _shipViewModel;
        [SerializeField] private ShipDataHolderSO _shipDataHolderSO;
        [SerializeField] private ShipModulesManagerSO _shipModulesManagerSO;
        [SerializeField] private ShipStatsManagerSO _shipStatsManager;
        [SerializeField] private ShipWeaponManagerSO _shipWeaponManagerSO;

        [SerializeField] private AvailableItemsContainerView _availableItemsContainerView;
        [SerializeField] private EquipedWeaponsContainerView _equipedWeaponsContainerView;
        [SerializeField] private EquipedUpgradesContainerView _equipedUpgradesContainerView;
        [SerializeField] private ShipStateView _shipStateView;

        private void Awake()
        {
            _shipViewModel = Instantiate(_shipViewModel);
            _shipDataHolderSO= Instantiate(_shipDataHolderSO);
            _shipModulesManagerSO = Instantiate(_shipModulesManagerSO);
            _shipStatsManager = Instantiate(_shipStatsManager);
            _shipWeaponManagerSO = Instantiate(_shipWeaponManagerSO);

            _shipDataHolderSO.Init(_shipViewModel);
            _availableItemsContainerView.Init(_shipViewModel);
            _shipModulesManagerSO.Init(_shipViewModel, _shipDataHolderSO, _shipStatsManager, _shipWeaponManagerSO);
            _shipWeaponManagerSO.Init(_shipViewModel, this);
            _equipedWeaponsContainerView.Init(_shipViewModel);
            _equipedUpgradesContainerView.Init(_shipViewModel);
            _shipStatsManager.Init(_shipViewModel);
            _shipStateView.Init(_shipViewModel);
        }
    }
}


