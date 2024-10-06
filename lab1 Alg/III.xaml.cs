using MatrixEntities;
using DijkstraAlgorithm;
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
using System.IO;


namespace lab1_Alg
{
    public partial class III : Window
    {
        public III()
        {
            InitializeComponent();
            Graph3.Plot.Axes.SetLimits(-40, 2500);
            Graph3.Plot.Axes.SetLimitsY(-1, 40);
            Graph3.Plot.XLabel("Длина вектора");
            Graph3.Plot.YLabel("Время мс*100");
        }

        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph3.Plot.Clear();
            Graph3.Refresh();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Out ret = new Out();

            int b = (int)SlGraphSize.Value;
            int a = (int)SlMaxVal.Value;
            int c = (int)SlCountStart.Value;
            List<float> dataX = new List<float>();
            for (int i = 0; i < b-2; i++) { dataX.Add(i); }



            if (CbLoad.IsChecked == true)
            {
                ret.Load("Dextra", Graph3, CbAprox.IsChecked == true);

            }

            else
            {
                GraphTest graphTest = new GraphTest(a, b, c);
                float[] result = graphTest.StartAlgorithm();
                ret.dataX = dataX;
                ret.dataY = result.ToList();
                ret.Ret(CbAprox.IsChecked == true, Graph3);
            }
        }
      


    }
}
