using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Printing;
using System.Security.Cryptography;
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
using AlgLogic;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;
using ScottPlot;
using static AlgLogic.AlgorithmClassicPow;
using MathNet.Numerics.LinearAlgebra;






namespace lab1_Alg
{
    public partial class I : System.Windows.Window
    {
        public I()
        {
            InitializeComponent();
            Graph.Plot.Axes.SetLimits(0, 10000);
            Graph.Plot.Axes.SetLimitsY(0, 1000);
            Graph.Plot.XLabel("Длина вектора");
            Graph.Plot.YLabel("Время мс*100");
            SelectAlg.SelectedIndex = 0;
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
            Polynomial polynomial = new (Fit.Polynomial(xData, yData, 2));


            // Вычисление значений аппроксимированной функции
            foreach (double i in x)
            {
                floats.Add((float)polynomial.Evaluate(i));
            }

            OutAverage(Slise(floats.ToArray(), true), dataX);

            //Output(Slise(floats.ToArray()), dataX, true);
        }

        private void BtStart(object sender, RoutedEventArgs e)
        {
            List<float> dataX = new List<float>();
            for (int i = 0; i < (int)SlVectorLength.Value-2; i++) { dataX.Add(i); }


            try
            {
                int p = Convert.ToInt32(TbPow.Text);
                int maxValRandNum = (int)SlMaxVal.Value;
                int countStart = (int)SlCountStart.Value;
                int vectorLength = (int)SlVectorLength.Value;


                ComboBoxItem typeItem = (ComboBoxItem)SelectAlg.SelectedItem;
                string nameAlg = typeItem.Content.ToString();
                AlgorithmInterface algorithm = CreateInstanseAlg(nameAlg, p);

                if (CbLoad.IsChecked == true)
                {
                    Load(nameAlg, CbAprox.IsChecked == true);

                }

                else
                {
                    Test test = new Test(algorithm, maxValRandNum, vectorLength, countStart);
                    float[] result = test.StartAlgorithm();
                    OutAverage(Slise(result), dataX,false);
                    //Output(Slise(result), dataX, false);

                    //test.WriteFile(result.ToList(),"");  // запись в файл

                    if (CbAprox.IsChecked == true)
                    {
                        OutAverage(Slise(result), dataX, true);
                    }
                }

            }

            catch
            {
                throw;
            }
        }

        private List<float> OutAverage(List<List<float>> resultList, List<float> dataX, bool fl)
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

            if (fl)
            {
                Approximation(dataX, result.ToArray());
            }

            
            var cal = new ScottPlot.Color(255, 255, 255, 255);
            var gr = Graph.Plot.Add.Scatter(dataX, result);
            gr.LineColor = cal;
            Graph.Refresh();
            return result;
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
            var gr = Graph.Plot.Add.Scatter(dataX, result);
            gr.LineColor = cal;
            gr.MarkerSize = 7;
            Graph.Refresh();
            return result;
        }

        //private void Output(List<List<float>> resultList, List<float> dataX, bool fl)
        //{ 
        //    string[] numGraphs = TbNumGraphs.Text.Split(',');
        //    foreach(var i in numGraphs)
        //    {
        //        if(i.Split('-').Length == 2)
        //        {
        //            for (int j = Convert.ToInt32(i.Split('-')[0]); j <= Convert.ToInt32(i.Split("-")[1]); j++) 
        //            {
        //                List<float> dataY = resultList[j-1].ToList();
        //                var gr = Graph.Plot.Add.Scatter(dataX, dataY);
        //                if(fl)
        //                {
        //                    gr.MarkerSize = 1000;
        //                }

        //                Graph.Refresh();
        //            }
        //        }

        //        else
        //        {
        //            List<float> dataY = resultList[int.Parse(i)-1].ToList();
        //            var gr = Graph.Plot.Add.Scatter(dataX, dataY);
        //            if (fl)
        //            {
        //                gr.MarkerSize = 10;

        //            }
        //            Graph.Refresh();

        //        }
        //    }
        //}

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

            resultList.RemoveAt(resultList.Count - 1);
            return resultList;
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

        private void Load(string name, bool fl)
        {
            string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).FullName).FullName;
            path += "\\" + "launches" + "\\" + name + ".txt";
            string[] result = File.ReadAllLines(path);
            List<float> res = new List<float>();
            List<float> dataX = new List<float>();
            foreach (var item in result)
            {
                res.Add((float)Convert.ToDouble(item));

            }

            for (int i = 0; i < res.Count; i++) { dataX.Add(i); }

            OutAverage(Slise(res.ToArray()), dataX, fl);
            //Output(Slise(res.ToArray()),dataX, false);


        }


        private AlgorithmInterface CreateInstanseAlg(string nameAlg, int p)
        {
            switch (nameAlg)
            {
                case ("Постоянная ф-я"):
                    return new Algorithm1();

                case ("Сумма элементов"):
                    return new Algorithm2();

                case ("Произведение эл-тов"):
                    return new Algorithm3();

                case ("Метод Горнера"):
                    return new AlgorithmPolynomeHorner();

                case ("Bubble Sort"):
                    return new AlgorithmBubbleSort();

                case ("Quick Sort"):
                    return new AlgorithmQuickSort();

                case ("Tim Sort"):
                    return new AlgorithmTimSort();

                case ("Quick pow"):
                    return new AlgorithmQuickPow(p);

                case ("Quick pow 2"):
                    return new AlgorithmQuickPow2(p);

                case ("Rec pow"):
                    return new AlgorithmRecPow(p);

                case ("Classic pow"):
                    return new AlgorithmClassicPow(p);

                case ("Полином"):
                    return new AlgorithmPolynome();

                case ("Сортировка слиянием"):
                    return new AlgorithmMerge();

                case ("Задача о разбиении множества"):
                    return new ALgorithmNumberPartitioning();


                default: return null;


            }
        }


        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Clear();
            Graph.Refresh();

        }

        private void SelectAlg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)SelectAlg.SelectedItem;
            string nameAlg = typeItem.Content.ToString();

            switch (nameAlg)
            {
                case ("Постоянная ф-я"):
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Сумма элементов"):
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Произведение эл-тов"):
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Метод Горнера"):
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Bubble Sort"):
                    Graph.Plot.Axes.SetLimits(-100, 3000, -50, 600);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 3000;

                    break;

                case ("Quick Sort"):
                    Graph.Plot.Axes.SetLimits(-400, 14800, -10, 300);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 1000;

                    break;

                case ("Tim Sort"):
                    Graph.Plot.Axes.SetLimits(-400, 14800, -10, 300);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 1000;
                    break;

                case ("Quick pow"):
                    Graph.Plot.Axes.SetLimits(-1000, 22000, -1, 30);
                    Graph.Plot.YLabel("Шаги");
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Quick pow 2"):
                    Graph.Plot.Axes.SetLimits(-1000, 22000, -1, 30);
                    Graph.Plot.YLabel("Шаги");
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Rec pow"):
                    Graph.Plot.Axes.SetLimits(-1000, 22000, -1, 30);
                    Graph.Plot.YLabel("Шаги");
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Classic pow"):
                    Graph.Plot.Axes.SetLimits(-1000, 22000, -1, 30);
                    Graph.Plot.YLabel("Шаги");
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Полином"):
                    Graph.Plot.Axes.SetLimits(-500, 20000, -20, 300);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Сортировка слиянием"):
                    Graph.Plot.Axes.SetLimits(-400, 16800, -8, 260);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 1000;
                    break;

                case ("Задача о разбиении множества"):
                    Graph.Plot.Axes.SetLimits(-10, 550, -1000, 30000);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 1500;
                    break;


                default: return;

            }
        }
    }
}
