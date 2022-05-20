using Calendar.lib.Plans.PlanFactory;
using Calendar.lib.Plans.PlansManager;
using SimpleInjector;
using TPP.AppBase;

namespace Calendar.lib.BootStrap
{
    public sealed class CalendarLibBootstrapper : IBootStrapper
    {
        public void Register(Container container)
        {
            container.Register<IPlanFactory, PlanFactory>(Lifestyle.Singleton);
            container.Register<IPlansManager, PlansManager>(Lifestyle.Singleton);
        }
    }
}