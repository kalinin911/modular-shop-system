using Core.Reactive;
using NUnit.Framework;

namespace Tests
{
    public class ReactivePropertyTests
    {
        [Test]
        public void Value_SetNew_TriggersOnChanged()
        {
            var property = new ReactiveProperty<int>(100);
            int receivedValue = 0;
            property.OnChanged += v => receivedValue = v;

            property.Value = 50;

            Assert.AreEqual(50, receivedValue);
        }

        [Test]
        public void Value_SetSame_DoesNotTriggerOnChanged()
        {
            var property = new ReactiveProperty<int>(100);
            int callCount = 0;
            property.OnChanged += _ => callCount++;

            property.Value = 100;

            Assert.AreEqual(0, callCount);
        }

        [Test]
        public void SetValueAndForceNotify_AlwaysTriggers()
        {
            var property = new ReactiveProperty<int>(100);
            int callCount = 0;
            property.OnChanged += _ => callCount++;

            property.SetValueAndForceNotify(100);

            Assert.AreEqual(1, callCount);
        }
    }
}