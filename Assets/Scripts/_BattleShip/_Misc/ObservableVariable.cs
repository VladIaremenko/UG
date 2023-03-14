﻿using System;
using UnityEngine;

namespace UGA.Assets.Scripts._BattleShip._Misc
{
    public class ObservableVariable<T>
    {
        private event Action<T> _onValueChanged;

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _onValueChanged?.Invoke(value);
            }
        }

        public void AddListener(Action<T> action, bool forseRefresh = true)
        {
            _onValueChanged += action;

            if (_value == null)
            {
                Debug.LogWarning("Value is null");
                return;
            }

            if (forseRefresh)
            {
                _onValueChanged.Invoke(_value);
            }
        }

        public void RemoveListener(Action<T> action)
        {
            _onValueChanged -= action;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}


