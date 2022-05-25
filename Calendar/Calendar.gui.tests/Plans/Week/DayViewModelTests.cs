using Calendar.gui.Plans.Day;
using Calendar.lib.Plans.PlansManager;
using Moq;
using NUnit.Framework;

namespace Calendar.gui.tests.Plans.Week
{
    [TestFixture]
    internal sealed class DayViewModelTests
    {
        private IDayViewModel _sut;
        private Mock<IPlansManager> _plansManager;

        [SetUp]
        public void TestInitialize()
        {
            // mock:
            _plansManager = new Mock<IPlansManager>();
            

            // software under test:
            _sut = new DayViewModel();
        }
    }
}