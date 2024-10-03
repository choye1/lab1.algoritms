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






namespace lab1_Alg
{
    public partial class I : System.Windows.Window
    {
        public I()
        {
            InitializeComponent();
            Graph.Plot.Axes.SetLimits(0, 10000);
            Graph.Plot.Axes.SetLimitsY(0, 1000);
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

            foreach (float i in dataY) 
            { 
                var spline = Interpolate.CubicSpline(xData, yData);
                double interpolatedValue = spline.Interpolate(i);
                floats.Add((float)interpolatedValue);
            }

            Output(Slise(floats.ToArray()), dataX, true);
        }

        private void BtStart(object sender, RoutedEventArgs e)
        {
            List<float> dataX = new List<float>();
            for (int i = 0; i < (int)SlVectorLength.Value; i++) { dataX.Add(i); }
            

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
                    Load(nameAlg);

                }

                else
                {
                    Test test = new Test(algorithm, maxValRandNum, vectorLength, countStart);
                    float[] result = test.StartAlgorithm();
                    Average(Slise(result), dataX);
                    //Output(Slise(result), dataX, false);

                    //test.WriteFile(result.ToList(),"");  // запись в файл

                    if (CbAprox.IsChecked == true)
                    {
                        Approximation(dataX, result);
                    }
                }
              
            }

            catch
            {
                throw;
            }
        }

        private List<float> Average(List<List<float>> resultList, List<float> dataX)
        {
            int len = resultList[0].Count-1;
            int k = resultList.Count - 1;
            List<float> result = new List<float>() {  };

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
            Graph.Refresh();
            return result;
        }

        private void Output(List<List<float>> resultList, List<float> dataX, bool fl)
        { 
            string[] numGraphs = TbNumGraphs.Text.Split(',');
            foreach(var i in numGraphs)
            {
                if(i.Split('-').Length == 2)
                {
                    for (int j = Convert.ToInt32(i.Split('-')[0]); j <= Convert.ToInt32(i.Split("-")[1]); j++) 
                    {
                        List<float> dataY = resultList[j-1].ToList();
                        var gr = Graph.Plot.Add.Scatter(dataX, dataY);
                        if(fl)
                        {
                            gr.MarkerSize = 1000;
                        }

                        Graph.Refresh();
                    }
                }

                else
                {
                    List<float> dataY = resultList[int.Parse(i)-1].ToList();
                    var gr = Graph.Plot.Add.Scatter(dataX, dataY);
                    if (fl)
                    {
                        gr.MarkerSize = 10;
                        
                    }
                    Graph.Refresh();

                }
            }
        }

        private List<List<float>> Slise(float[] result) 
        {
            int i = 0;
            List <List<float>> resultList  = new List<List<float>>() { };
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

        private void Load(string name)
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


            Output(Slise(res.ToArray()),dataX, false);


        }


        private AlgorithmInterface CreateInstanseAlg(string nameAlg, int p)
        {
            switch (nameAlg)
            {
                case ("Постоянная ф-я"):
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    return new Algorithm1();
                 
                case ("Сумма элементов"):
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    return new Algorithm2();

                case ("Произведение эл-тов"):
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    return new Algorithm3();

                case ("Метод Горнера"):
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    return new AlgorithmPolynomeHorner();

                case ("Bubble Sort"):
                    Graph.Plot.Axes.SetLimits(-400, 7600, -50, 800);
                    Graph.Refresh();
                    return new AlgorithmBubbleSort();

                case ("Quick Sort"):
                    Graph.Plot.Axes.SetLimits(-400, 14800, -10, 300);
                    Graph.Refresh();
                    return new AlgorithmQuickSort();

                case ("Tim Sort"):
                    Graph.Plot.Axes.SetLimits(-400, 14800, -10, 300);
                    Graph.Refresh();
                    return new AlgorithmTimSort(); 

                case ("Quick pow"):
                    Graph.Plot.Axes.SetLimits(-1000, 22000, -1, 30);
                    Graph.Refresh();
                    return new AlgorithmQuickPow(p);

                case ("Quick pow 2"):
                    Graph.Plot.Axes.SetLimits(-1000, 22000, -1, 30);
                    Graph.Refresh();
                    return new AlgorithmQuickPow2(p);

                case ("Rec pow"):
                    Graph.Plot.Axes.SetLimits(-1000, 22000, -1, 30);
                    Graph.Refresh();
                    return new AlgorithmRecPow(p);

                case ("Classic pow"):
                    Graph.Plot.Axes.SetLimits(-1000, 22000, -1, 30);
                    Graph.Refresh();
                    return new AlgorithmClassicPow(p);

                case ("Полином"):
                    Graph.Plot.Axes.SetLimits(-500, 20000, -20, 300);
                    Graph.Refresh();
                    return new AlgorithmPolynome();

                case ("Сортировка слиянием"):
                    Graph.Plot.Axes.SetLimits(-400, 16800, -8, 260);
                    Graph.Refresh();
                    return new AlgorithmMerge();

                case ("Задача о разбиении множества"):
                    Graph.Plot.Axes.SetLimits(-10, 550, -1000, 30000);
                    Graph.Refresh();
                    return new ALgorithmNumberPartitioning();


                default: return null; 


            }
        }


        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Clear();
            Graph.Refresh();

        }

        
    }
}
