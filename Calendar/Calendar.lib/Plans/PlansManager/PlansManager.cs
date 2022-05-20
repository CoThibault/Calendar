using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Calendar.lib.Plans.PlanFactory;

namespace Calendar.lib.Plans.PlansManager
{
    internal interface IPlansManager
    {
        IReadOnlyCollection<IPlan> GetAllPlans();

        IPlan CreateNewPlan(DateTime startTime, DateTime endTime);

        void RemovePlan(Guid planId);
    }
    
    internal sealed class PlansManager : IPlansManager
    {
        private readonly IPlanFactory _planFactory;
        private readonly Dictionary<Guid, IPlan> _allPlans = new();

        public PlansManager(IPlanFactory planFactory)
        {
            _planFactory = planFactory;
            for (var i = 0; i < 10; i++)
            {
                CreateNewPlan(DateTime.Now, DateTime.MaxValue);
            }
        }

        /// <inheritdoc />
        public IReadOnlyCollection<IPlan> GetAllPlans()
        {
            return _allPlans.Values.ToArray();
        }

        /// <inheritdoc />
        public IPlan CreateNewPlan(DateTime startTime, DateTime endTime)
        {
            var plan = _planFactory.CreatePlan(startTime, endTime);
            _allPlans.Add(plan.PlanId, plan);
            return plan;
        }

        /// <inheritdoc />
        public void RemovePlan(Guid planId)
        {
            if (_allPlans.ContainsKey(planId))
            {
                _allPlans.Remove(planId);
            }
        }
    }
}