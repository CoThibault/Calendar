namespace Calendar.gui.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindowView
    {
        public MainWindowView(MainWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}