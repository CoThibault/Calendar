using Calendar.gui.Adapters;
using Calendar.gui.Plans;
using Calendar.gui.Plans.Day;
using Calendar.gui.Plans.Week;
using PRF.WPFCore;

namespace Calendar.gui.MainWindow
{
    internal sealed class MainWindowViewModel : ViewModelBase
    {
        private readonly DayView _dayView;
        private readonly WeekView _weekView;
        private IScheduleView _mainPanel;

        public MainWindowViewModel(
            MainHeaderView mainHeader,
            DayView dayView,
            WeekView weekView,
            DayScheduleButtonAdapter dayScheduleButtonAdapter,
            WeekScheduleButtonAdapter weekScheduleButtonAdapter)
        {
            _dayView = dayView;
            _weekView = weekView;
            MainHeader = mainHeader;
            _mainPanel = dayView;

            dayScheduleButtonAdapter.OnDayScheduleSelected += OnDayScheduleSelected;
            weekScheduleButtonAdapter.OnWeekScheduleSelected += OnWeekScheduleSelected;
        }

        private void OnWeekScheduleSelected(bool isSelected)
        {
            if (isSelected)
            {
                MainPanel = _weekView;
            }
        }

        private void OnDayScheduleSelected(bool isSelected)
        {
            if (isSelected)
            {
                MainPanel = _dayView;
            }
        }

        public MainHeaderView MainHeader { get; }

        public IScheduleView MainPanel
        {
            get => _mainPanel;
            private set => SetProperty(ref _mainPanel, value);
        }
    }
}