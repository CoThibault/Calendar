using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using Calendar.gui.Adapters;
using PRF.WPFCore.CustomCollections;
using TPP.AppBase;

namespace Calendar.gui.Plans.Day
{
    public interface IDayViewModel : IPlansViewModel
    {
    }
    
    internal sealed class DayViewModel : ViewModelBase, IDayViewModel
    {
        private readonly IEnumerable<IPlanAdapter> _allPlans;
        private ICollectionView _displayedPlans;

        public DayViewModel()
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
            private set => SetProperty(ref _displayedPlans, value);
        }

        /// <inheritdoc />
        public void DisplayAllPlans()
        {
            DisplayedPlans = ObservableCollectionSource.GetDefaultView(_allPlans);
        }
    }
}