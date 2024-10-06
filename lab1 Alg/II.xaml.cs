using MathNet.Numerics;
using MatrixEntities;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.IO;
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
using MathNet.Numerics.Interpolation;
using DijkstraAlgorithm;
using AlgLogic;
using ScottPlot.Colormaps;



namespace lab1_Alg
{
    /// <summary>
    /// Логика взаимодействия для II.xaml
    /// </summary>
    public partial class II : System.Windows.Window
    {
        public II()
        {
            InitializeComponent();
            Graph2.Plot.Axes.SetLimits(-20, 300);
            Graph2.Plot.Axes.SetLimitsY(-500, 12000);
            Graph2.Plot.XLabel("Длина вектора");
            Graph2.Plot.YLabel("Время мс*100");

        }
        

        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph2.Plot.Clear();
            Graph2.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Out Rat = new();
            int b = (int)SlMarixSize.Value;
            int a = (int)SlMaxVal.Value;
            int c = (int)SlCountStart.Value;
            List<float> dataX = new List<float>();

            for (int i = 0; i < b-2; i++) { dataX.Add(i); }



            if (CbLoad.IsChecked == true)
            {
                Rat.Load("Matrix", Graph2, CbAprox.IsChecked == true);
            }

            else
            {


                MatrixTest matrixTest = new MatrixTest(a, b, c);
                float[] result = matrixTest.StartAlgorithm();
                Rat.dataX = dataX;
                Rat.dataY = result.ToList();
                Rat.Ret(CbAprox.IsChecked == true, Graph2);
            }

            //test.WriteFile(result.ToList(),"");  // запись в файл
            
        }

    }

       



        

      
    
}
