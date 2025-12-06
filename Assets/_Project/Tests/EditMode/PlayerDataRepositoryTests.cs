using System;
using Core.Data;
using NUnit.Framework;

namespace Tests
{
    public class PlayerDataRepositoryTests
    {
        private PlayerDataRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new PlayerDataRepository();
        }

        [Test]
        public void Register_NewKey_CreatesProperty()
        {
            _repository.Register<int>("health", 100);

            Assert.IsTrue(_repository.HasKey("health"));
        }

        [Test]
        public void Register_DuplicateKey_ThrowsException()
        {
            _repository.Register<int>("health", 100);

            Assert.Throws<InvalidOperationException>(() => 
                _repository.Register<int>("health", 50));
        }

        [Test]
        public void GetProperty_ExistingKey_ReturnsCorrectValue()
        {
            _repository.Register<int>("gold", 500);

            var property = _repository.GetProperty<int>("gold");

            Assert.AreEqual(500, property.Value);
        }

        [Test]
        public void GetProperty_NonExistingKey_ThrowsException()
        {
            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => 
                _repository.GetProperty<int>("missing"));
        }

        [Test]
        public void GetProperty_WrongType_ThrowsException()
        {
            _repository.Register<int>("health", 100);

            Assert.Throws<InvalidCastException>(() => 
                _repository.GetProperty<string>("health"));
        }
    }
}