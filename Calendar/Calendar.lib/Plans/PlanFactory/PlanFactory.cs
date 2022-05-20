using System;

namespace Calendar.lib.Plans.PlanFactory
{
    internal interface IPlanFactory
    {
        IPlan CreatePlan(DateTime startTime, DateTime endTime);
    }

    internal sealed class PlanFactory : IPlanFactory
    {
        /// <inheritdoc />
        public IPlan CreatePlan(DateTime startTime, DateTime endTime)
        {
            return new Plan(startTime, endTime, Guid.NewGuid());
        }
    }
}