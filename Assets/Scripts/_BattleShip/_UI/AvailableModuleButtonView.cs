using System;
using UnityEngine;
using UnityEngine.UI;

namespace UGA.Assets.Scripts._BattleShip._UI
{
    public class AvailableModuleButtonView : MonoBehaviour
    {
        [SerializeField] private AvailableItemsContainerView _availableItemsContainerView;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private int _id;

        private void Awake()
        {
            _button.onClick.AddListener(HandleItemClick);
        }

        private void HandleItemClick()
        {
            _availableItemsContainerView.HandleItemClick(_id);
        }

        public void UpdateView(ShipModuleViewData shipModuleViewData)
        {
            _image.sprite = shipModuleViewData.Sprite;
            _id = shipModuleViewData.ID;
        }
    }
}


