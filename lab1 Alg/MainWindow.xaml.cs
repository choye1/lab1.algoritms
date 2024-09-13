using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScottPlot;


namespace lab1_Alg
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void I_Click(object sender, RoutedEventArgs e)
        {
            I window = new I();
            window.Show();
        }

        private void II_Click(object sender, RoutedEventArgs e)
        {
            II window = new II();
            window.Show();
        }

        private void III_Click(object sender, RoutedEventArgs e)
        {
            III window = new III();
            window.Show();
        }
    }
}