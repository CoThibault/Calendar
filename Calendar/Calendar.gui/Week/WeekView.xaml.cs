using System.Windows.Controls;

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