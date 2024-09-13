using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ScottPlot;

namespace lab1_Alg
{
    /// <summary>
    /// Логика взаимодействия для I.xaml
    /// </summary>
    public partial class I : Window
    {
        public I()
        {
            InitializeComponent();
            List<int> dataX = new List<int>();
            List<int> dataY = new List<int>();
            Graph.Plot.Add.Scatter(dataX, dataY);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Clear();

        }
    }
}
