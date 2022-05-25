using System.Windows.Controls;

namespace Calendar.gui.Plans.Day
{
    public partial class DayView : UserControl, IScheduleView
    {
        public DayView(IDayViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}