using Core.Base;
using Core.Interfaces;
using Health.Data;
using UnityEngine;

namespace _Project.Health.Rewards
{
    [CreateAssetMenu(menuName = "Shop/Rewards/Health Percent Reward")]
    public class HealthPercentReward : RewardBase
    {
        [SerializeField, Range(0, 100)] private int _percent;
        
        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<int>(HealthKeys.Health);
            var toAdd = Mathf.CeilToInt(property.Value * _percent / 100f);
            property.Value += toAdd;
        }
    }
}