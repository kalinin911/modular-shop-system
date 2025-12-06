using System;
using Core.Data;
using Core.Interfaces;
using Gold.Controllers;
using Gold.Data;
using Gold.Views;
using Health.Controllers;
using Health.Data;
using Health.Views;
using Location.Controllers;
using Location.Data;
using Location.Views;
using Shop.Config;
using Shop.Controllers;
using Shop.Services;
using Shop.Views;
using UnityEngine;
using VIP.Controllers;
using VIP.Data;
using VIP.Views;

namespace Shop.Installers
{
    public class GameInstaller : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private ShopConfig _shopConfig;
        
        [Header("Resource Views")]
        [SerializeField] private HealthView _healthView;
        [SerializeField] private GoldView _goldView;
        [SerializeField] private LocationView _locationView;
        [SerializeField] private VIPView _vipView;
        
        [Header("Shop Views")]
        [SerializeField] private ShopView _shopView;

        void Awake()
        {
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
            var shopController = new ShopController(_shopConfig, purchaseService);
            
            _healthView.Initialize(playerData, healthController);
            _goldView.Initialize(playerData, goldController);
            _locationView.Initialize(playerData, locationController);
            _vipView.Initialize(playerData, vipController);
            _shopView.Initialize(shopController);
            
            _shopView.OnBundleInfoClicked += SceneNavigator.OpenBundleDetail;
            
            SubscribeToDataChanges(playerData, shopController);
        }

        private void SubscribeToDataChanges(IPlayerData playerData, ShopController shopController)
        {
            playerData.GetProperty<int>(HealthKeys.Health).OnChanged += _ => shopController.NotifyAffordabilityChanged();
            playerData.GetProperty<int>(GoldKeys.Gold).OnChanged += _ => shopController.NotifyAffordabilityChanged();
            playerData.GetProperty<string>(LocationKeys.Location).OnChanged += _ => shopController.NotifyAffordabilityChanged();
            playerData.GetProperty<TimeSpan>(VIPKeys.VIP).OnChanged += _ => shopController.NotifyAffordabilityChanged();
        }
    }
}