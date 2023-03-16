using System.Collections;
using UGA.Assets.Scripts._BattleShip._Game;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip
{
    [CreateAssetMenu(fileName = "ShipShieldManagerSO", menuName = "SO/Ship/ShipShieldManagerSO", order = 1)]
    public class ShipShieldManagerSO : ScriptableObject
    {
        private ShipViewModel _shipViewModel;
        private MonoBehaviour _mono;
        private ShipStatsManagerSO _shipStatsManager;

        private float _shieldRegenerationRate;
        private float _shieldRegenerationSpeed;
        private float _maxShieldEnergy;

        private Coroutine _shieldCoroutine;

        private void StartShieldsRegeneration()
        {
            StopShieldsRegeneration();

            _shieldCoroutine = _mono.StartCoroutine(ShieldCorroutine(_shieldRegenerationRate, _shieldRegenerationSpeed));
        }

        private void StopShieldsRegeneration()
        {
            if (_shieldCoroutine != null)
            {
                _mono.StopCoroutine(_shieldCoroutine);
            }
        }

        public void UpdateShieldsData(float shieldRegenerationRate, float shieldRegenerationSpeed)
        {
            _shieldRegenerationRate = shieldRegenerationRate;
            _shieldRegenerationSpeed = shieldRegenerationSpeed;
        }
        public void Init(ShipViewModel shipViewModel, ShipStatsManagerSO shipStatsManagerSO, MonoBehaviour mono)
        {
            _mono = mono;
            _shipViewModel = shipViewModel;
            _shipStatsManager = shipStatsManagerSO;

            _shipViewModel.StartBattlingEvent += StartShieldsRegeneration;
            _shipViewModel.StopBattlingEvent += StopShieldsRegeneration;
        }

        private void OnDisable()
        {
            if (_shipViewModel != null)
            {
                _shipViewModel.StartBattlingEvent -= StartShieldsRegeneration;
                _shipViewModel.StopBattlingEvent -= StopShieldsRegeneration;
            }
        }

        private IEnumerator ShieldCorroutine(float rate, float reloadTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(reloadTime);

                _shipStatsManager.HandleShieldRecharge(rate);
            }
        }
    }
}


