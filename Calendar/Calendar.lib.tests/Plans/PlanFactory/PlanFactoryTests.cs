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
    }
}