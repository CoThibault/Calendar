namespace Calendar.gui.MainWindow
{
    public partial class MainHeaderView
    {
        public MainHeaderView(IMainHeaderViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}