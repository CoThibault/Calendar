using Calendar.gui.Day;
using TPP.AppBase;

namespace Calendar.gui.MainWindow
{
    internal sealed class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(DayView dayView)
        {
            MainPanel = dayView;
        }

        public DayView MainPanel { get; }
    }
}