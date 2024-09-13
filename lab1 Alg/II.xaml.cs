using ScottPlot;
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

namespace lab1_Alg
{
    /// <summary>
    /// Логика взаимодействия для II.xaml
    /// </summary>
    public partial class II : Window
    {
        public II()
        {
            InitializeComponent();
            Plot plot = new Plot();
            List<int> dataX = new List<int>();
            List<int> dataY = new List<int>();
            Graph2.Plot.Add.Scatter(dataX, dataY);
        }

        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph2.Plot.Clear();
        }
    }
}
