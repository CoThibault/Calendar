using Calendar.gui.Day;
using NUnit.Framework;

namespace Calendar.Tests.CalendarGui.Plans.Week
{
    [TestFixture]
    internal sealed class DayViewModelTests
    {
        private IDayViewModel _sut;

        [SetUp]
        public void TestInitialize()
        {
            // mock:

            // software under test:
            _sut = new DayViewModel();
        }
    }
}