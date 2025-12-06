using Core.Reactive;

namespace Core.Interfaces
{
    public interface IPlayerData
    {
        void Register<T>(string key, T initialValue);
        ReactiveProperty<T> GetProperty<T>(string key);
        bool HasKey(string key);
    }
}