using System;
using System.Collections.Generic;
using Calendar.lib.Plans.PlanFactory;
using Calendar.lib.Plans.PlansHolder;

namespace Calendar.lib.Plans.PlansManager
{
    public interface IPlansManager
    {
        IReadOnlyCollection<IPlan> GetAllPlans();

        IPlan CreateNewPlan(DateTime startTime, DateTime endTime);

        void RemovePlan(Guid planId);
    }
    
    internal sealed class PlansManager : IPlansManager
    {
        private readonly IPlanFactory _planFactory;
        private readonly IPlansHolder _plansHolder;

        public PlansManager(IPlanFactory planFactory, IPlansHolder plansHolder)
        {
            _planFactory = planFactory;
            _plansHolder = plansHolder;
            for (var i = 0; i < 10; i++)
            {
                CreateNewPlan(DateTime.Now, DateTime.MaxValue);
            }
        }

        /// <inheritdoc />
        public IReadOnlyCollection<IPlan> GetAllPlans()
        {
            return _plansHolder.GetAllPlans();
        }

        /// <inheritdoc />
        public IPlan CreateNewPlan(DateTime startTime, DateTime endTime)
        {
            var plan = _planFactory.CreatePlan(startTime, endTime);
            _plansHolder.TryAddNewPlan(plan);
            return plan;
        }

        /// <inheritdoc />
        public void RemovePlan(Guid planId)
        {
            _plansHolder.TryRemovePlan(planId);
        }
    }
}