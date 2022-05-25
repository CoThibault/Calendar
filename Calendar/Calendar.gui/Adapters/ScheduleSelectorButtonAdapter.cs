using System;
using PRF.WPFCore;

namespace Calendar.gui.Adapters
{
    public interface IScheduleSelectorButtonAdapter
    {
        /// <summary>
        /// If the concerned schedule view button is selected
        /// </summary>
        bool IsSelected { get; set; }
        
        /// <summary>
        /// Name displayed on button
        /// </summary>
        string DisplayName { get; }
    }

    internal sealed class DayScheduleButtonAdapter : ViewModelBase, IScheduleSelectorButtonAdapter
    {
        public event Action<bool> OnDayScheduleSelected;
        private bool _isSelected = true;
        private string _displayName = "By Day";

        /// <inheritdoc />
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (SetProperty(ref _isSelected, value))
                {
                    RaiseOnDayScheduleSelected(_isSelected);
                }
            }
        }

        /// <inheritdoc />
        public string DisplayName => _displayName;

        private void RaiseOnDayScheduleSelected(bool isSelected)
        {
            OnDayScheduleSelected?.Invoke(isSelected);
        }
    }

    internal sealed class WeekScheduleButtonAdapter : ViewModelBase, IScheduleSelectorButtonAdapter
    {
        public event Action<bool> OnWeekScheduleSelected;
        private bool _isSelected;
        private readonly string _displayName = "By Week";

        /// <inheritdoc />
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (SetProperty(ref _isSelected, value))
                {
                    RaiseOnWeekScheduleSelected(_isSelected);
                }
            }
        }

        /// <inheritdoc />
        public string DisplayName => _displayName;

        private void RaiseOnWeekScheduleSelected(bool isSelected)
        {
            OnWeekScheduleSelected?.Invoke(isSelected);
        }
    }
}