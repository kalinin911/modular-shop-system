using Core.Base;
using Core.Interfaces;
using Health.Data;
using UnityEngine;

namespace Health.Requirements
{
    [CreateAssetMenu(menuName = "Shop/Requirements/Health Percent Cost")]
    public class HealthPercentCostRequirement : RequirementBase
    {
        [SerializeField, Range(0, 100)] private int _percent;

        public override bool CanApply(IPlayerData playerData)
        {
            var current = playerData.GetProperty<int>(HealthKeys.Health).Value;
            return current >= 0;
        }

        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<int>(HealthKeys.Health);
            var toDeduct = Mathf.CeilToInt(property.Value * _percent/100f);
            property.Value -= toDeduct;
        }
    }
}