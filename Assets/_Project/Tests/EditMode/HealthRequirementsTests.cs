using Core.Data;
using Health.Data;
using Health.Requirements;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class HealthRequirementsTests
    {
        private PlayerDataRepository _playerData;

        [SetUp]
        public void SetUp()
        {
            _playerData = new PlayerDataRepository();
            _playerData.Register<int>(HealthKeys.Health, 100);
        }

        [Test]
        public void HealthCostRequirement_CanApply_EnoughHealth_ReturnsTrue()
        {
            var requirement = ScriptableObject.CreateInstance<HealthCostRequirement>();
            SetPrivateField(requirement, "_amount", 50);

            Assert.IsTrue(requirement.CanApply(_playerData));
        }

        [Test]
        public void HealthCostRequirement_CanApply_NotEnoughHealth_ReturnsFalse()
        {
            var requirement = ScriptableObject.CreateInstance<HealthCostRequirement>();
            SetPrivateField(requirement, "_amount", 150);

            Assert.IsFalse(requirement.CanApply(_playerData));
        }

        [Test]
        public void HealthCostRequirement_Apply_DeductsHealth()
        {
            var requirement = ScriptableObject.CreateInstance<HealthCostRequirement>();
            SetPrivateField(requirement, "_amount", 30);

            requirement.Apply(_playerData);

            Assert.AreEqual(70, _playerData.GetProperty<int>(HealthKeys.Health).Value);
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