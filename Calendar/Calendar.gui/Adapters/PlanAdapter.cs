using System;
using System.Windows.Media;
using TPP.AppBase;

namespace Calendar.gui.Adapters
{
    internal interface IPlanAdapter
    {
        DateTime PlanStartTime { get; }
        DateTime PlanEndTime { get; }
        SolidColorBrush BackgroundColor { get; }
    }

    internal sealed class PlanAdapter : ViewModelBase, IPlanAdapter
    {
        public PlanAdapter(DateTime planStartTime, DateTime planEndTime, SolidColorBrush background)
        {
            PlanStartTime = planStartTime;
            PlanEndTime = planEndTime;
            BackgroundColor = background;
        }

        public DateTime PlanStartTime { get; }

        public DateTime PlanEndTime { get; }

        public SolidColorBrush BackgroundColor { get; }
    }
}