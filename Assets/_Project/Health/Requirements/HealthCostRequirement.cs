using Core.Base;
using Core.Interfaces;
using Health.Data;
using UnityEngine;

namespace Health.Requirments
{
    [CreateAssetMenu(menuName = "Shop/Requirements/Health Cost")]
    public class HealthCostRequirement : RequirementBase
    {
        [SerializeField] private int _amount;

        public override bool CanApply(IPlayerData playerData)
        {
            var current = playerData.GetProperty<int>(HealthKeys.Health).Value;
            return current >= _amount;
        }

        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<int>(HealthKeys.Health);
            property.Value -= _amount;
        }
    }
}