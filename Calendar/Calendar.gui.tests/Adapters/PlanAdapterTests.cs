using System;
using System.Windows.Media;
using Calendar.gui.Adapters;
using NUnit.Framework;

namespace Calendar.Tests.CalendarGui.Adapters
{
    [TestFixture]
    internal sealed class PlanAdapterTests
    {
        [Test]
        public void Ctor()
        {
            //Arrange
            var start = DateTime.Now;
            var planId = Guid.NewGuid();
            
            //Act
            var plan = new PlanAdapter(start, DateTime.MaxValue, Brushes.Aqua, planId);

            //Assert
            Assert.AreEqual(start, plan.PlanStartTime);
            Assert.AreEqual(DateTime.MaxValue, plan.PlanEndTime);
            Assert.AreEqual(Brushes.Aqua, plan.BackgroundColor);
            Assert.AreEqual(planId, plan.PlanId);
        }

    }
}