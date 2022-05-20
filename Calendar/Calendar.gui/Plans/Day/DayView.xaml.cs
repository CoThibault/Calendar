using System.Windows.Controls;

namespace Calendar.gui.Day
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