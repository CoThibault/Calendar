using System.Windows.Controls;
using Calendar.gui.Day;

namespace Calendar.gui.Plans.Day
{
    public partial class DayView : UserControl
    {
        public DayView(IDayViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}