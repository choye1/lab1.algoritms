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
using ScottPlot;
using static AlgLogic.AlgorithmClassicPow;

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
            Graph.Plot.Axes.SetLimits(0, 10000);
            Graph.Plot.Axes.SetLimitsY(0, 10000);
            SelectAlg.SelectedIndex = 0;
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
                    Output(Slise(result), dataX);
                }
              
            }

            catch
            {
                throw;
            }
        }

        private void Output(List<List<float>> resultList, List<float> dataX)
        { 
            string[] numGraphs = TbNumGraphs.Text.Split(',');
            foreach(var i in numGraphs)
            {
                if(i.Split('-').Length == 2)
                {
                    for (int j = Convert.ToInt32(i.Split('-')[0]); j <= Convert.ToInt32(i.Split("-")[1]); j++) 
                    {
                        List<float> dataY = resultList[j].ToList();
                        Graph.Plot.Add.Scatter(dataX, dataY);
                        Graph.Refresh();
                    }
                }

                else
                {
                    List<float> dataY = resultList[int.Parse(i)-1].ToList();
                    Graph.Plot.Add.Scatter(dataX, dataY);
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


            Output(Slise(res.ToArray()),dataX);


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
                    return new AlgorithmTimSort(); //вот тут что то не то, он должен принимать вектор, а он отказывается

                case ("Возведение в степень"):
                    return new AlgorithmClassicPow(p);

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

        
    }
}
