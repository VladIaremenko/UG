using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip._UI
{
    public class ShipStateView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _stateText;
        private ShipViewModel _shipViewModel;

        public void Init(ShipViewModel shipViewModel)
        {
            _shipViewModel = shipViewModel;
            _shipViewModel.CurrentShipState.AddListener(UpdateView);
        }

        private void OnDisable()
        {
            _shipViewModel.CurrentShipState.RemoveListener(UpdateView);
        }

        private void UpdateView(ShipStateViewData data)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"HP: {data.HP}");
            sb.AppendLine($"Shield: {data.Shield}");
            sb.AppendLine($"ShieldRechargeTime: {data.ShieldRechargeTime}");
            sb.AppendLine($"ShieldRechargeRat: {data.ShieldRechargeRate}");

            foreach (var item in data.WeaponsData)
            {
                sb.AppendLine($"Damage: {item.Damage} Reload: {item.ReloadTime}");
            }

            _stateText.text = sb.ToString();
        }
    }
}


