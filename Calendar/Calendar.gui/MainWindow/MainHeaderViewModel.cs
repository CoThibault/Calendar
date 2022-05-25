using System.Collections.ObjectModel;
using System.ComponentModel;
using Calendar.gui.Adapters;
using PRF.WPFCore.CustomCollections;
using TPP.AppBase;

namespace Calendar.gui.MainWindow
{
    public interface IMainHeaderViewModel
    {
    }

    internal sealed class MainHeaderViewModel : ViewModelBase, IMainHeaderViewModel
    {
        public ICollectionView AvailableScheduleViews { get; }

        public MainHeaderViewModel(DayScheduleButtonAdapter daySchedule, WeekScheduleButtonAdapter weekSchedule)
        {
            var availableScheduleViews = new ObservableCollection<IScheduleSelectorButtonAdapter>()
            {
                daySchedule,
                weekSchedule
            };
            AvailableScheduleViews = ObservableCollectionSource.GetDefaultView(availableScheduleViews);
        }
    }
}