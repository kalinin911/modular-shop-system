using Core.Interfaces;
using Health.Data;

namespace Health.Controllers
{
    public class HealthController
    {
        private readonly IPlayerData _playerData;

        public HealthController(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        public void Initialize()
        {
            _playerData.Register<int>(HealthKeys.Health, HealthKeys.DefaultValue);
        }
        
        // Cheat button functionality
        public void AddHealth(int amount)
        {
            var property = _playerData.GetProperty<int>(HealthKeys.Health);
            property.Value += amount;
        }
    }
}