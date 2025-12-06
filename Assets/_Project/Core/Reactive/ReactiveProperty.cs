using System;
using System.Collections.Generic;

namespace Core.Reactive
{
    public class ReactiveProperty<T>
    {
        private T _value;

        public event Action<T> OnChanged;

        public ReactiveProperty(T initialValue = default)
        {
            _value = initialValue;
        }

        public T Value
        {
            get => _value;
            set
            {
                if(EqualityComparer<T>.Default.Equals(_value, value))
                    return;
                
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }

        public void SetValueAndForceNotify(T value)
        {
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }
}