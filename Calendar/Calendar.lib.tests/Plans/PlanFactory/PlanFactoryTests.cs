using System;
using Calendar.lib.Plans.PlanFactory;
using NUnit.Framework;

namespace Calendar.lib.tests.Plans.PlanFactory
{
    [TestFixture]
    internal sealed class PlanFactoryTests
    {
        private IPlanFactory _sut;

        [SetUp]
        public void TestInitialize()
        {
            // mock:

            // software under test:
            _sut = new lib.Plans.PlanFactory.PlanFactory();
        }

        [Test]
        public void CreatePlan_assigns_correct_dates()
        {
            //Arrange
            var start = DateTime.Now;
            var end = DateTime.Now + TimeSpan.FromHours(1);

            //Act
            var res = _sut.CreatePlan(start, end);

            //Assert
            Assert.AreEqual(start, res.StartTime);
            Assert.AreEqual(end, res.EndTime);
            Assert.IsNotNull(res.PlanId);
        }

    }
}