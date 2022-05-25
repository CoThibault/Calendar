using System;

namespace Calendar.lib.Plans
{
    public interface IPlan
    {
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        Guid PlanId { get; }
    }

    internal sealed class Plan : IPlan
    {
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public Guid PlanId { get; }

        public Plan(DateTime startTime, DateTime endTime, Guid planId)
        {
            StartTime = startTime;
            EndTime = endTime;
            PlanId = planId;
        }
    }
}