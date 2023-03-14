using System;
using UnityEngine;
using UnityEngine.UI;

namespace UGA.Assets.Scripts._BattleShip._UI
{
    public class AvailableModuleButtonView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(HandleItemClick);
        }

        private void HandleItemClick()
        {
            Debug.Log("CLICKER");
        }

        public void UpdateView(ShipModuleViewData shipModuleViewData)
        {
            _image.sprite = shipModuleViewData.Sprite;
        }
    }
}


