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
            Graph3.Plot.Axes.SetLimits(0, 10000);
            Graph3.Plot.Axes.SetLimitsY(0, 1000);
        }

        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph3.Plot.Clear();
            Graph3.Refresh();

        }

        private void Load(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).FullName).FullName;
            path += "\\launches\\Dextra.txt";
            string[] result = File.ReadAllLines(path);
            List<float> res = new List<float>();
            List<float> dataX = new List<float>();
            foreach (var item in result)
            {
                res.Add((float)Convert.ToDouble(item));

            }

            for (int i = 0; i < res.Count; i++) { dataX.Add(i); }


            Output(Slise(res.ToArray()), dataX, false);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int b = (int)SlGraphSize.Value;
            int a = (int)SlMaxVal.Value;
            int c = (int)SlCountStart.Value;
            List<float> dataX = new List<float>();

             

            GraphTest graphTest = new GraphTest(a,b,c);
            float[] result = graphTest.StartAlgorithm();
            for (int i = 0; i <= result.Length; i++) { dataX.Add(i); }
            Output(Slise(result), dataX, false);
        }
        private void Output(List<List<float>> resultList, List<float> dataX, bool fl)
        {
            string[] numGraphs = TbNumGraph2.Text.Split(',');
            foreach (var i in numGraphs)
            {
                if (i.Split('-').Length == 2)
                {
                    for (int j = Convert.ToInt32(i.Split('-')[0]); j <= Convert.ToInt32(i.Split("-")[1]); j++)
                    {
                        List<float> dataY = resultList[j-1].ToList();
                        Graph3.Plot.Add.Scatter(dataX, dataY);
                        Graph3.Refresh();
                    }
                }

                else
                {
                    List<float> dataY = resultList[int.Parse(i)-1].ToList();
                    var gr = Graph3.Plot.Add.Scatter(dataX, dataY);
                    
                    if (fl)
                    {
                        gr.MarkerSize = 10;

                    }
                    Graph3.Refresh();


                }
            }
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
