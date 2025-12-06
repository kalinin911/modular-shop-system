using Core.Base;
using Core.Interfaces;
using Location.Data;
using UnityEngine;

namespace Location.Rewards
{
    [CreateAssetMenu(menuName = "Shop/Rewards/Location Reward")]
    public class LocationReward : RewardBase
    {
        [SerializeField] private string _newLocation;

        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<string>(LocationKeys.Location);
            property.Value = _newLocation;
        }
    }
}