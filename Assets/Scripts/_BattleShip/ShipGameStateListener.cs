using System;
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
            _gameStateViewModel.GameState.AddListener(HandleGameState);
        }

        private void OnDisable()
        {
            _gameStateViewModel.GameState.RemoveListener(HandleGameState);
        }

        private void HandleGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Default:
                    HandleEndBattleEvent();
                    break;
                case GameState.Battle:
                    HandleStartBattleEvent();
                    break;
                default:
                    break;
            }
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


