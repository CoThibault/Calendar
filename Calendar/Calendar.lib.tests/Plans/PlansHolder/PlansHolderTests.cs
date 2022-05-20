using System;
using Calendar.lib.Plans;
using Calendar.lib.Plans.PlansHolder;
using Moq;
using NUnit.Framework;

namespace Calendar.lib.tests.Plans.PlansHolder
{
    [TestFixture]
    internal sealed class PlansHolderTests
    {
        private IPlansHolder _sut;

        [SetUp]
        public void TestInitialize()
        {
            // mock:
            
            // software under test:
            _sut = new lib.Plans.PlansHolder.PlansHolder(Array.Empty<IPlan>());
        }

        [Test]
        public void Ctor_initialises_with_plans_list()
        {
            //Arrange
            var start1 = DateTime.Today;
            var end1 = DateTime.Today + TimeSpan.FromDays(1);
            var id1 = Guid.NewGuid();
            var plan1 = new Mock<IPlan>();
            plan1.Setup(o => o.StartTime).Returns(start1);
            plan1.Setup(o => o.EndTime).Returns(end1);
            plan1.Setup(o => o.PlanId).Returns(id1);
            
            var start2 = DateTime.Today;
            var end2 = DateTime.Today + TimeSpan.FromDays(2);
            var id2 = Guid.NewGuid();
            var plan2 = new Mock<IPlan>();
            plan2.Setup(o => o.StartTime).Returns(start2);
            plan2.Setup(o => o.EndTime).Returns(end2);
            plan2.Setup(o => o.PlanId).Returns(id2);

            var plans = new[]
            {
                plan1.Object,
                plan2.Object
            };

            //Act
            var sut = new lib.Plans.PlansHolder.PlansHolder(plans);

            //Assert
            Assert.AreEqual(2, sut.GetAllPlans().Count);
        }

        [Test]
        public void Ctor_throws_with_null_plan()
        {
            //Arrange
            var start1 = DateTime.Today;
            var end1 = DateTime.Today + TimeSpan.FromDays(1);
            var id1 = Guid.NewGuid();
            var plan1 = new Mock<IPlan>();
            plan1.Setup(o => o.StartTime).Returns(start1);
            plan1.Setup(o => o.EndTime).Returns(end1);
            plan1.Setup(o => o.PlanId).Returns(id1);

            var plans = new[]
            {
                plan1.Object,
                null
            };

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var sut = new lib.Plans.PlansHolder.PlansHolder(plans);
            });
        }
        
        [Test]
        public void Ctor_throws_if_end_is_same_than_start()
        {
            //Arrange
            var start1 = DateTime.Today;
            var id1 = Guid.NewGuid();
            var plan1 = new Mock<IPlan>();
            plan1.Setup(o => o.StartTime).Returns(start1);
            plan1.Setup(o => o.EndTime).Returns(start1);
            plan1.Setup(o => o.PlanId).Returns(id1);

            var plans = new[]
            {
                plan1.Object,
            };

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new lib.Plans.PlansHolder.PlansHolder(plans);
            });
        }

        [Test]
        public void Ctor_throws_if_end_is_earlier_than_start()
        {
            //Arrange
            var start1 = DateTime.Today;
            var end1 = DateTime.Today - TimeSpan.FromDays(1);
            var id1 = Guid.NewGuid();
            var plan1 = new Mock<IPlan>();
            plan1.Setup(o => o.StartTime).Returns(start1);
            plan1.Setup(o => o.EndTime).Returns(end1);
            plan1.Setup(o => o.PlanId).Returns(id1);

            var plans = new[]
            {
                plan1.Object,
            };

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new lib.Plans.PlansHolder.PlansHolder(plans);
            });
        }
        
        [Test]
        public void Ctor_throws_if_two_plans_have_same_id()
        {
            //Arrange
            var start1 = DateTime.Today;
            var end1 = DateTime.Today + TimeSpan.FromDays(1);
            var id1 = Guid.NewGuid();
            var plan1 = new Mock<IPlan>();
            plan1.Setup(o => o.StartTime).Returns(start1);
            plan1.Setup(o => o.EndTime).Returns(end1);
            plan1.Setup(o => o.PlanId).Returns(id1);
            
            var start2 = DateTime.Today;
            var end2 = DateTime.Today + TimeSpan.FromDays(2);
            var plan2 = new Mock<IPlan>();
            plan2.Setup(o => o.StartTime).Returns(start2);
            plan2.Setup(o => o.EndTime).Returns(end2);
            plan2.Setup(o => o.PlanId).Returns(id1);

            var plans = new[]
            {
                plan1.Object,
                plan2.Object
            };

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new lib.Plans.PlansHolder.PlansHolder(plans);
            });
        }

        [Test]
        public void TryAddNewPlan_returns_true_for_new_id()
        {
            //Arrange
            var id1 = Guid.NewGuid();
            var plan1 = new Mock<IPlan>();
            plan1.Setup(o => o.PlanId).Returns(id1);

            //Act
            var res = _sut.TryAddNewPlan(plan1.Object);
            
            //Assert
            Assert.IsTrue(res);
        }

        [Test]
        public void TryAddNewPlan_returns_false_for_already_added_id()
        {
            //Arrange
            var start1 = DateTime.Today;
            var end1 = DateTime.Today + TimeSpan.FromDays(1);
            var id1 = Guid.NewGuid();
            var plan1 = new Mock<IPlan>();
            plan1.Setup(o => o.StartTime).Returns(start1);
            plan1.Setup(o => o.EndTime).Returns(end1);
            plan1.Setup(o => o.PlanId).Returns(id1);
            
            var start2 = DateTime.Today;
            var end2 = DateTime.Today + TimeSpan.FromDays(2);
            var plan2 = new Mock<IPlan>();
            plan2.Setup(o => o.StartTime).Returns(start2);
            plan2.Setup(o => o.EndTime).Returns(end2);
            plan2.Setup(o => o.PlanId).Returns(id1);

            var plans = new[]
            {
                plan1.Object,
                plan2.Object
            };

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var sut = new lib.Plans.PlansHolder.PlansHolder(plans);
            });
        }

        [Test]
        public void TryRemovePlan_returns_false_if_plan_does_not_exist()
        {
            //Arrange
            
            //Act
            var res = _sut.TryRemovePlan(Guid.NewGuid());

            //Assert
            Assert.IsFalse(res);
        }

        [Test]
        public void TryRemovePlan_returns_true_if_plan_is_removed()
        {
            //Arrange
            var start1 = DateTime.Today;
            var end1 = DateTime.Today + TimeSpan.FromDays(1);
            var id1 = Guid.NewGuid();
            var plan1 = new Mock<IPlan>();
            plan1.Setup(o => o.StartTime).Returns(start1);
            plan1.Setup(o => o.EndTime).Returns(end1);
            plan1.Setup(o => o.PlanId).Returns(id1);
            _sut.TryAddNewPlan(plan1.Object);

            //Act
            var res = _sut.TryRemovePlan(plan1.Object.PlanId);

            //Assert
            Assert.IsTrue(res);
            Assert.AreEqual(0, _sut.GetAllPlans().Count);
        }


    }
}