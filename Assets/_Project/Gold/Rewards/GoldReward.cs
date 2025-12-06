using Core.Base;
using Core.Interfaces;
using Gold.Data;
using UnityEngine;

namespace Gold.Rewards
{
    [CreateAssetMenu(menuName = "Shop/Rewards/Gold Reward")]
    public class GoldReward : RewardBase
    {
        [SerializeField] private int _amount;

        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<int>(GoldKeys.Gold);
            property.Value += _amount;
        }
    }
}