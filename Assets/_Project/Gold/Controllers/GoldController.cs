using Core.Interfaces;
using Gold.Data;

namespace Gold.Controllers
{
    public class GoldController
    {
        private readonly IPlayerData _playerData;

        public GoldController(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        public void Initialize()
        {
            _playerData.Register<int>(GoldKeys.Gold, GoldKeys.DefaultValue);
        }
        
        // Cheat button functionality
        public void AddGold(int amount)
        {
            var property = _playerData.GetProperty<int>(GoldKeys.Gold);
            property.Value += amount;
        }
    }
}