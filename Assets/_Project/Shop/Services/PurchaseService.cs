using System;
using System.Threading;
using Core.Interfaces;
using Cysharp.Threading.Tasks;
using Shop.Config;

namespace Shop.Services
{
    public class PurchaseService
    {
        private readonly IPlayerData _playerData;

        public PurchaseService(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        public bool CanPurchase(BundleConfig bundle)
        {
            foreach (var cost in bundle.Costs)
            {
                if (!cost.CanApply(_playerData))
                    return false;
            }
            
            return true;
        }

        public async UniTask<bool> TryPurchaseAsync(BundleConfig bundle, CancellationToken ct = default)
        {
            if (!CanPurchase(bundle))
                return false;
            
            await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: ct);
            
            if(!CanPurchase(bundle))
                return false;
            
            foreach(var cost in bundle.Costs)
                cost.Apply(_playerData);

            foreach (var reward in bundle.Rewards)
            {
                reward.Apply(_playerData);
            }

            return true;
        }
    }
}