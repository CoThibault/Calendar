using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar.lib.Plans.PlansHolder
{
    internal interface IPlansHolder
    {
        IReadOnlyCollection<IPlan> GetAllPlans();
        
        bool TryAddNewPlan(IPlan newPlan);
        
        bool TryRemovePlan(Guid planId);
    }

    internal sealed class PlansHolder : IPlansHolder
    {
        private readonly Dictionary<Guid, IPlan> _allPlans = new();

        public PlansHolder(IEnumerable<IPlan> initialPlans)
        {
            foreach (var plan in initialPlans)
            {
                AddPlan(plan);
            }
        }

        private void AddPlan(IPlan plan)
        {
            if (plan == null)
            {
                throw new ArgumentNullException("A null plan cannot be added.");
            }

            var timeComp = DateTime.Compare(plan.StartTime, plan.EndTime);
            if (timeComp == 0)
            {
                throw new ArgumentException("Starting and end time cannot be the same.");
            }
            if (timeComp > 0)
            {
                throw new ArgumentException("End time cannot be anterior to starting time.");
            }

            if (!_allPlans.TryAdd(plan.PlanId, plan))
            {
                throw new ArgumentException($"A plan with ID {plan.PlanId} already exists.");
            }
        }

        /// <inheritdoc />
        public IReadOnlyCollection<IPlan> GetAllPlans()
        {
            return _allPlans.Values.ToArray();
        }

        /// <inheritdoc />
        public bool TryAddNewPlan(IPlan newPlan)
        {
            if (!_allPlans.ContainsKey(newPlan.PlanId))
            {
                _allPlans.Add(newPlan.PlanId, newPlan);
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool TryRemovePlan(Guid planId)
        {
            return _allPlans.Remove(planId);
        }
    }
}