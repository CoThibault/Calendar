using System;
using System.Windows.Media;
using TPP.AppBase;

namespace Calendar.gui.Adapters
{
    public interface IPlanAdapter
    {
        DateTime PlanStartTime { get; }
        DateTime PlanEndTime { get; }
        SolidColorBrush BackgroundColor { get; }
        Guid PlanId { get; }
    }

    internal sealed class PlanAdapter : ViewModelBase, IPlanAdapter
    {
        public PlanAdapter(DateTime planStartTime, DateTime planEndTime, SolidColorBrush background, Guid planId)
        {
            PlanStartTime = planStartTime;
            PlanEndTime = planEndTime;
            BackgroundColor = background;
            PlanId = planId;
        }

        public DateTime PlanStartTime { get; }

        public DateTime PlanEndTime { get; }

        public SolidColorBrush BackgroundColor { get; }

        /// <inheritdoc />
        public Guid PlanId { get; }
    }
}