using System;
using System.Diagnostics;
using System.Windows;
using Calendar.gui;
using Calendar.gui.BootStrap;
using Calendar.gui.MainWindow;
using SimpleInjector;

static class Startup
{
    [STAThread]
    static void Main()
    {
        RunApplication(MainBootStrapper.Bootstrap());
    }

    private static void RunApplication(Container container)
    {
        try
        {
            var app = new App
            {
                ShutdownMode = ShutdownMode.OnMainWindowClose
            };
            app.InitializeComponent();
            var mainWindow = container.GetInstance<MainWindowView>();
            app.Run(mainWindow);
        }
        catch (Exception e)
        {
            Debug.Fail($"Unhandled exception : {e}");
        }
    }
}