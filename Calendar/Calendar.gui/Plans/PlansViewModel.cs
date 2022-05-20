using System.ComponentModel;

namespace Calendar.gui.Plans
{
    public interface IPlansViewModel
    {
        /// <summary>
        /// The list of currently displayed plans
        /// </summary>
        ICollectionView DisplayedPlans { get; }

        /// <summary>
        /// Clears all filters applied on displayed plans to display all available plans 
        /// </summary>
        void DisplayAllPlans();
    }
}