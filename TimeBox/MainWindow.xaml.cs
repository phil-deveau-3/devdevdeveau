using System.Windows;
using System.Windows.Input;

namespace TimeBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Activated += (sender, args) =>
            {
                Topmost = AlwaysOnTop.IsChecked ?? false;
            };

            Deactivated += (sender, args) =>
            {
                Topmost = AlwaysOnTop.IsChecked ?? false;
                if (Topmost)
                    Activate();
            };
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
