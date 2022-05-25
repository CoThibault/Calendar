using System.Collections.Generic;
using Calendar.gui.Adapters;
using Calendar.gui.MainWindow;
using Calendar.gui.Plans;
using Calendar.gui.Plans.Day;
using Calendar.gui.Plans.Week;
using Calendar.lib.BootStrap;
using SimpleInjector;
using TPP.AppBase;

namespace Calendar.gui.BootStrap
{
    internal static class MainBootStrapper
    {
        private static readonly List<IBootStrapper> _bootStrappers = new List<IBootStrapper>
        {
            new CalendarLibBootstrapper()
        };

        public static Container Bootstrap()
        {
            //Create container
            var container = new Container
            {
                Options = { EnableAutoVerification = false }
            };
            
            //Register types
            container.Register<MainWindowView>(Lifestyle.Singleton);
            container.Register<MainWindowViewModel>(Lifestyle.Singleton);
            
            container.Register<MainHeaderView>(Lifestyle.Singleton);
            container.Register<IMainHeaderViewModel, MainHeaderViewModel>(Lifestyle.Singleton);
            
            container.Register<IDayViewModel, DayViewModel>(Lifestyle.Singleton);
            container.Register<DayView>(Lifestyle.Singleton);
            container.Register<IWeekViewModel, WeekViewModel>(Lifestyle.Singleton);
            container.Register<WeekView>(Lifestyle.Singleton);
            container.Collection.Register<IScheduleView>(typeof(WeekView), typeof(DayView));
            
            container.Register<DayScheduleButtonAdapter>(Lifestyle.Singleton);
            container.Register<WeekScheduleButtonAdapter>(Lifestyle.Singleton);
            container.Collection.Register<IScheduleSelectorButtonAdapter>(typeof(DayScheduleButtonAdapter), typeof(WeekScheduleButtonAdapter));
            
            foreach (var bootStrapper in _bootStrappers)
            {
                bootStrapper.Register(container);
            }
            return container;
        }
    }
}