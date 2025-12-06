using UnityEngine;

namespace Shop.Config
{
    [CreateAssetMenu(menuName = "Shop/Shop Config")]
    public class ShopConfig : ScriptableObject
    {
        [SerializeField] private BundleConfig[] _bundles;

        public BundleConfig[] Bundles => _bundles;
    }
}