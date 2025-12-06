using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Reactive;

namespace Core.Data
{
    public class PlayerDataRepository : IPlayerData
    {
        private readonly Dictionary<string, object> _properties = new();

        public void Register<T>(string key, T initialValue)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            
            if(_properties.ContainsKey(key))
                throw new InvalidOperationException($"Key '{key}' already registered");
            
            _properties[key] = new ReactiveProperty<T>(initialValue);
        }

        public ReactiveProperty<T> GetProperty<T>(string key)
        {
            if(!_properties.TryGetValue(key, out var property))
                throw new KeyNotFoundException($"Key '{key}' not registered");
            
            if(property is not ReactiveProperty<T> typed)
                throw new  InvalidCastException($"Key '{key}' is not {typeof(T).Name}");

            return typed;
        }
        
        public bool HasKey(string key) => _properties.ContainsKey(key);
    }
}