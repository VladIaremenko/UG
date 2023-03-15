using System;
using UGA.Assets.Scripts._BattleShip._Misc;
using UnityEngine;
using UnityEngine.UI;

namespace UGA.Assets.Scripts._BattleShip._UI
{
    public class ModuleButtonView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private IHandleItemClick _container;
        private int _id;

        private void Awake()
        {
            _container = GetComponentInParent<IHandleItemClick>();
            _button.onClick.AddListener(HandleItemClick);
        }

        private void HandleItemClick()
        {
            _container.HandleItemClick(_id);
        }

        public void UpdateView(ShipModuleViewData shipModuleViewData)
        {
            _image.sprite = shipModuleViewData.Sprite;
            _id = shipModuleViewData.ID;
        }
    }
}


