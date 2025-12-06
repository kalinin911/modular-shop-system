using System;
using Core.Base;
using Core.Interfaces;
using UnityEngine;
using VIP.Data;

namespace VIP.Requirments
{
    [CreateAssetMenu(menuName = "Shop/Requirements/VIP Cost")]
    public class VIPCostRequirement : RequirementBase
    {
        [SerializeField] private int _seconds;

        public override bool CanApply(IPlayerData playerData)
        {
            var current = playerData.GetProperty<TimeSpan>(VIPKeys.VIP).Value;
            return current.TotalSeconds >= _seconds;
        }

        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<TimeSpan>(VIPKeys.VIP);
            property.Value = TimeSpan.FromSeconds(_seconds);
        }
    }
}