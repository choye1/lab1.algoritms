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
        private void Approximation(List<float> dataX, float[] dataY)
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            foreach (float i in dataX) { x.Add(i); }
            foreach (float i in dataY) { y.Add(i); }
            double[] xData = x.ToArray();
            double[] yData = y.ToArray();
            List<float> floats = new List<float>();


            // Аппроксимация данных полиномиальной функцией
            Polynomial polynomial = new(Fit.Polynomial(xData, yData, 2));


            // Вычисление значений аппроксимированной функции
            foreach (double i in x)
            {
                floats.Add((float)polynomial.Evaluate(i));
            }

            OutAverage(Slise(floats.ToArray(), true), dataX);

            //Output(Slise(floats.ToArray()), dataX, true);
        }

        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph2.Plot.Clear();
            Graph2.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int b = (int) SlMarixSize.Value;
            int a = (int)SlMaxVal.Value;
            int c = (int)SlCountStart.Value;
            List<float> dataX = new List<float>();
            MatrixTest matrixTest = new MatrixTest(a, b, c);
            float[] result = matrixTest.StartAlgorithm();
            for (int i = 0; i<result.Length; i++) { dataX.Add(i) ; }

            if (CbAprox.IsChecked == true)
            {
                Approximation(dataX, result);
            }

            Output(Slise(result),dataX,false);
            

        }

        private void Load(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).FullName).FullName;
            path += "\\launches\\Matrix.txt";
            string[] result = File.ReadAllLines(path);
            List<float> res = new List<float>();
            List<float> dataX = new List<float>();
            foreach (var item in result)
            {
                res.Add((float)Convert.ToDouble(item));

            }

            for (int i = 0; i < res.Count; i++) { dataX.Add(i); }


            OutAverage(Slise(res.ToArray()), dataX);
        }



        private List<float> OutAverage(List<List<float>> resultList, List<float> dataX)
        {
            int len = resultList[0].Count - 1;
            int k = resultList.Count - 1;
            List<float> result = new List<float>() { };

            for (int j = 0; j < len; j++)
            {
                float d = resultList[0][j];
                for (int i = 1; i <= k; i++)
                {
                    d += resultList[i][j];
                    d /= 2;
                }

                result.Add(d);
            }



            var cal = new ScottPlot.Color(255, 255, 255, 255);
            var gr = Graph2.Plot.Add.Scatter(dataX, result);
            gr.LineColor = cal;
            Graph2.Refresh();
            return result;
        }

        private void Output(List<List<float>> resultList, List<float> dataX,bool fl)
        {
            string[] numGraphs = TbNumGraph2.Text.Split(',');
            foreach (var i in numGraphs)
            {
                if (i.Split('-').Length == 2)
                {
                    for (int j = Convert.ToInt32(i.Split('-')[0]); j <= Convert.ToInt32(i.Split("-")[1]); j++)
                    {
                        List<float> dataY = resultList[j-1].ToList();
                        var gr = Graph2.Plot.Add.Scatter(dataX, dataY);
                        if (fl)
                        {
                            gr.MarkerSize = 1000;
                        }
                        Graph2.Refresh();
                    }
                }

                else
                {
                    List<float> dataY = resultList[int.Parse(i)-1].ToList();
                    Graph2.Plot.Add.Scatter(dataX, dataY);
                    Graph2.Refresh();

                }
            }
        }

        private List<List<float>> Slise(float[] result, bool fl)
        {
            int i = 0;
            List<List<float>> resultList = new List<List<float>>() { };
            resultList.Add(new List<float>());
            foreach (var item in result)
            {
                if (item == -1)
                {
                    i++;
                    resultList.Add(new List<float>());
                }

                else
                {
                    resultList[i].Add(item);
                }
            }

            return resultList;
        }

        private List<List<float>> Slise(float[] result)
        {
            int i = 0;
            List<List<float>> resultList = new List<List<float>>() { };
            resultList.Add(new List<float>());
            foreach (var item in result)
            {
                if (item == -1)
                {
                    i++;
                    resultList.Add(new List<float>());
                }

                else
                {
                    resultList[i].Add(item);
                }
            }

            return resultList;
        }
    }
}
