using Core.Base;
using Core.Interfaces;
using Health.Data;
using UnityEngine;

namespace _Project.Health.Rewards
{
    [CreateAssetMenu(menuName = "Shop/Rewards/Health Reward")]
    public class HealthReward : RewardBase
    {
        [SerializeField] private int _amount;

        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<int>(HealthKeys.Health);
            property.Value += _amount;
        }
    }
}