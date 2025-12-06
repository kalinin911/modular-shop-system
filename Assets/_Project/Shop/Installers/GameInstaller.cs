using System;
using Core.Data;
using Core.Interfaces;
using Gold.Controllers;
using Gold.Views;
using Health.Controllers;
using Health.Views;
using Location.Controllers;
using Location.Views;
using Shop.Config;
using Shop.Controllers;
using Shop.Services;
using Shop.Views;
using UnityEngine;
using VIP.Controllers;
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

            SubscribeToDataChanges(playerData, shopController);
        }

        private void SubscribeToDataChanges(IPlayerData playerData, ShopController shopController)
        {
            playerData.GetProperty<int>("health").OnChanged += _ => shopController.NotifyAffordabilityChanged();
            playerData.GetProperty<int>("gold").OnChanged += _ => shopController.NotifyAffordabilityChanged();
            playerData.GetProperty<string>("location").OnChanged += _ => shopController.NotifyAffordabilityChanged();
            playerData.GetProperty<TimeSpan>("vip").OnChanged += _ => shopController.NotifyAffordabilityChanged();
        }
    }
}