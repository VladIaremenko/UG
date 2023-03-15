using System;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip._Game
{
    [CreateAssetMenu(fileName = "GameStateViewModel", menuName = "SO/Ship/GameStateViewModel", order = 1)]
    public class GameStateViewModel : ScriptableObject
    {
        public event Action StartBattleEvent = new(() => { });
        public event Action EndBattleEvent = new(() => { });

        public void StartBattle()
        {
            StartBattleEvent.Invoke();
        }
    }
}


