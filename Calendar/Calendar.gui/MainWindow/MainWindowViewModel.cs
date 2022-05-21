using Calendar.gui.Plans.Day;
using TPP.AppBase;

namespace Calendar.gui.MainWindow
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(MainHeaderView mainHeader, DayView dayView)
        {
            MainHeader = mainHeader;
            MainPanel = dayView;
        }

        public MainHeaderView MainHeader { get; }
        public DayView MainPanel { get; }
    }
}