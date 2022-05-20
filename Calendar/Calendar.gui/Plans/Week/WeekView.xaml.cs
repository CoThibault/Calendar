using System.Windows.Controls;
using Calendar.gui.Plans.Week;

namespace Calendar.gui.Week
{
    public partial class WeekView : UserControl
    {
        public WeekView(IWeekViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}