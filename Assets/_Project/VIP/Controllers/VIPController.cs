using System;
using Core.Interfaces;
using VIP.Data;

namespace VIP.Controllers
{
    public class VIPController
    {
        private readonly IPlayerData _playerData;

        public VIPController(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        public void Initialize()
        {
            _playerData.Register<TimeSpan>(VIPKeys.VIP, VIPKeys.DefaultValue);
        }

        public void AddTime(int seconds)
        {
            var property = _playerData.GetProperty<TimeSpan>(VIPKeys.VIP);
            property.Value += TimeSpan.FromSeconds(seconds);
        }
    }
}