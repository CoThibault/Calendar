using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Calendar.gui.Adapters;
using TPP.AppBase;

namespace Calendar.gui.Day
{
    public interface IDayViewModel
    {
    }

    internal sealed class DayViewModel : ViewModelBase, IDayViewModel
    {
        private ObservableCollection<IPlanAdapter> _plansList;

        public DayViewModel()
        {
            _plansList = new ObservableCollection<IPlanAdapter>
            {
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Aqua),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Gray),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Green),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Red),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Orange),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Yellow),
            };
        }

        public ObservableCollection<IPlanAdapter> PlansList
        {
            get => _plansList;
        }
    }
}