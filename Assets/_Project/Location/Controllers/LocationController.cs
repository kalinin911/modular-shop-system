using Core.Interfaces;
using Location.Data;

namespace Location.Controllers
{
    public class LocationController
    {
        private readonly IPlayerData _playerData;

        public LocationController(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        public void Initialize()
        {
            _playerData.Register<string>(LocationKeys.Location, LocationKeys.DefaultValue);
        }

        public void ResetToDefault()
        {
            var property = _playerData.GetProperty<string>(LocationKeys.Location);
            property.Value = LocationKeys.DefaultValue;
        }
    }
}