using UGA.Assets.Scripts._BattleShip._Game;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    public class ShipGameStateListener : MonoBehaviour
    {
        [SerializeField] private GameStateViewModel _gameStateViewModel;
        private ShipViewModel _shipViewModel;

        public void Init(ShipViewModel shipViewModel)
        {
            _shipViewModel = shipViewModel;
        }

        private void OnEnable()
        {
            _gameStateViewModel.StartBattleEvent += HandleStartBattleEvent;
            _gameStateViewModel.EndBattleEvent += HandleEndBattleEvent;
        }

        private void OnDisable()
        {
            _gameStateViewModel.StartBattleEvent -= HandleStartBattleEvent;
            _gameStateViewModel.EndBattleEvent -= HandleEndBattleEvent;
        }

        private void HandleEndBattleEvent()
        {
            _shipViewModel.StopBattling();
        }

        private void HandleStartBattleEvent()
        {
            _shipViewModel.StartBattling();
        }
    }
}


