using System;
using Core.Base;
using Core.Data;
using Gold.Data;
using Health.Data;
using NUnit.Framework;
using Shop.Config;
using Shop.Services;
using UnityEngine;

namespace Tests
{
    public class PurchaseServiceTests
    {
        private PlayerDataRepository _playerData;
        private PurchaseService _purchaseService;

        [SetUp]
        public void SetUp()
        {
            _playerData = new PlayerDataRepository();
            _playerData.Register<int>(HealthKeys.Health, 100);
            _playerData.Register<int>(GoldKeys.Gold, 100);
            _purchaseService = new PurchaseService(_playerData);
        }

        [Test]
        public void CanPurchase_EmptyCosts_ReturnsTrue()
        {
            var bundle = CreateBundle(new RequirementBase[0], new RewardBase[0]);

            Assert.IsTrue(_purchaseService.CanPurchase(bundle));
        }

        [Test]
        public void CanPurchase_AffordableCost_ReturnsTrue()
        {
            var healthCost = ScriptableObject.CreateInstance<Health.Requirements.HealthCostRequirement>();
            SetPrivateField(healthCost, "_amount", 50);

            var bundle = CreateBundle(new RequirementBase[] { healthCost }, new RewardBase[0]);

            Assert.IsTrue(_purchaseService.CanPurchase(bundle));
        }

        [Test]
        public void CanPurchase_UnaffordableCost_ReturnsFalse()
        {
            var healthCost = ScriptableObject.CreateInstance<Health.Requirements.HealthCostRequirement>();
            SetPrivateField(healthCost, "_amount", 150);

            var bundle = CreateBundle(new RequirementBase[] { healthCost }, new RewardBase[0]);

            Assert.IsFalse(_purchaseService.CanPurchase(bundle));
        }

        private BundleConfig CreateBundle(RequirementBase[] costs, RewardBase[] rewards)
        {
            var bundle = ScriptableObject.CreateInstance<BundleConfig>();
            SetPrivateField(bundle, "_name", "Test Bundle");
            SetPrivateField(bundle, "_costs", costs);
            SetPrivateField(bundle, "_rewards", rewards);
            return bundle;
        }

        private void SetPrivateField(object obj, string fieldName, object value)
        {
            var field = obj.GetType().GetField(fieldName,
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            field.SetValue(obj, value);
        }
    }
}