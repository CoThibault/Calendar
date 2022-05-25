using System.Windows.Controls;

namespace Calendar.gui.Plans.Week
{
    public partial class WeekView : UserControl, IScheduleView
    {
        public WeekView(IWeekViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}