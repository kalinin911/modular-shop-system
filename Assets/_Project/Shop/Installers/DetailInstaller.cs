using Core.Data;
using Gold.Controllers;
using Health.Controllers;
using Location.Controllers;
using Shop.Controllers;
using Shop.Services;
using Shop.Views;
using UnityEngine;
using UnityEngine.UI;
using VIP.Controllers;

namespace Shop.Installers
{
    public class DetailInstaller : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Transform _cardContainer;
        [SerializeField] private BundleCardView _bundleCardPrefab;

        private void Awake()
        {
            var bundle = SceneNavigator.SelectedBundle;

            if (bundle == null)
            {
                SceneNavigator.ReturnToShopList();
                return;
            }

            var playerData = new PlayerDataRepository();

            var healthController = new HealthController(playerData);
            healthController.Initialize();

            var goldController = new GoldController(playerData);
            goldController.Initialize();

            var locationController = new LocationController(playerData);
            locationController.Initialize();

            var vipController = new VIPController(playerData);
            vipController.Initialize();

            var purchaseService = new PurchaseService(playerData);
            var shopController = new ShopController(null, purchaseService);

            var card = Instantiate(_bundleCardPrefab, _cardContainer);
            card.Initialize(bundle, shopController);
            card.HideInfoButton();

            _backButton.onClick.AddListener(SceneNavigator.ReturnToShopList);
        }
    }
}