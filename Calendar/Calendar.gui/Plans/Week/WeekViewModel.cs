using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using Calendar.gui.Adapters;
using PRF.WPFCore.CustomCollections;
using TPP.AppBase;

namespace Calendar.gui.Plans.Week
{
    public interface IWeekViewModel : IPlansViewModel
    {
    }

    internal sealed class WeekViewModel : ViewModelBase, IWeekViewModel
    {
        private readonly ObservableCollection<IPlanAdapter> _allPlans;
        private ICollectionView _displayedPlans;
        
        public WeekViewModel()
        {
            _allPlans = new ObservableCollection<IPlanAdapter>
            {
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Aqua, Guid.NewGuid()),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Gray, Guid.NewGuid()),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Green, Guid.NewGuid()),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Red, Guid.NewGuid()),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Orange, Guid.NewGuid()),
                new PlanAdapter(DateTime.Now, DateTime.MaxValue, Brushes.Yellow, Guid.NewGuid()),
            };
            DisplayedPlans = ObservableCollectionSource.GetDefaultView(_allPlans);
        }
        
        public ICollectionView DisplayedPlans
        {
            get => _displayedPlans;
            set => SetProperty(ref _displayedPlans, value);
        }

        /// <inheritdoc />
        public void DisplayAllPlans()
        {
            DisplayedPlans = ObservableCollectionSource.GetDefaultView(_allPlans);
            var toto = DateTime.Today;
        }
    }
}