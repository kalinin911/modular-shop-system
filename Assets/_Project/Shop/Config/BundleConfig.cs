using Core.Base;
using UnityEngine;

namespace Shop.Config
{
    [CreateAssetMenu(menuName = "Shop/Bundle Config")]
    public class BundleConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private RequirementBase[] _costs;
        [SerializeField] private RewardBase[] _rewards;
        
        public string Name => _name;
        public RequirementBase[] Costs => _costs;
        public RewardBase[] Rewards => _rewards;
    }
}