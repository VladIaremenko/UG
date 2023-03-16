using System;
using UGA.Assets.Scripts._BattleShip._Misc;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip._Game
{
    [CreateAssetMenu(fileName = "GameStateViewModel", menuName = "SO/Ship/GameStateViewModel", order = 1)]
    public class GameStateViewModel : ScriptableObject
    {
        public ObservableVariable<GameState> GameState = new ObservableVariable<GameState>();

        public void StartBattle()
        {
            if(GameState.Value == _BattleShip.GameState.Battle)
            {
                Debug.Log("Already battling");
                return;
            }

            GameState.Value = _BattleShip.GameState.Battle;
        }

        public void StopBattle()
        {
            GameState.Value = _BattleShip.GameState.Default;
        }
    }
}


