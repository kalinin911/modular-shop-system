using System;
using Shop.Config;
using Shop.Services;
using Cysharp.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopController
    {
        private readonly ShopConfig _config;
        private readonly PurchaseService _purchaseService;

        public event Action<BundleConfig> OnPurchaseStarted;
        public event Action<BundleConfig, bool> OnPurchaseCompleted;
        public event Action OnAffordabilityChanged;

        public ShopController(ShopConfig config, PurchaseService purchaseService)
        {
            _config = config;
            _purchaseService = purchaseService;
        }
        
        public BundleConfig[] GetBundles() => _config.Bundles;

        public bool CanAfford(BundleConfig bundle) => _purchaseService.CanPurchase(bundle);

        public async UniTaskVoid TryPurchase(BundleConfig bundle)
        {
            OnPurchaseStarted?.Invoke(bundle);

            var success = await _purchaseService.TryPurchaseAsync(bundle);
            
            OnPurchaseCompleted?.Invoke(bundle, success);
            OnAffordabilityChanged?.Invoke();
        }

        public void NotifyAffordabilityChanged()
        {
            OnAffordabilityChanged?.Invoke();
        }
    }
}