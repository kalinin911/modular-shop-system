using System;
using Core.Base;
using Core.Interfaces;
using UnityEngine;
using VIP.Data;

namespace VIP.Rewards
{
    [CreateAssetMenu(menuName = "Shop/Rewards/VIP Reward")]
    public class VIPRewards : RewardBase
    {
        [SerializeField] private int _seconds;

        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<TimeSpan>(VIPKeys.VIP);
            property.Value += TimeSpan.FromSeconds(_seconds);
        }
    }
}