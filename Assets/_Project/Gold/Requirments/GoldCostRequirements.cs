using Core.Base;
using Core.Interfaces;
using Gold.Data;
using UnityEngine;

namespace Gold.Requirments
{
    [CreateAssetMenu(menuName = "Shop/Requirements/Gold Cost")]
    public class GoldCostRequirement : RequirementBase
    {
        [SerializeField] private int _amount;

        public override bool CanApply(IPlayerData playerData)
        {
            var current = playerData.GetProperty<int>(GoldKeys.Gold).Value;
            return current >= _amount;
        }

        public override void Apply(IPlayerData playerData)
        {
            var property = playerData.GetProperty<int>(GoldKeys.Gold);
            property.Value -= _amount;
        }
    }
}