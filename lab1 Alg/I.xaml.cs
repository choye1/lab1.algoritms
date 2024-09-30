using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Printing;
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

                Test test = new Test(algorithm, maxValRandNum, vectorLength, countStart);
                float[] result = test.StartAlgorithm();
                Output(Slise(result), dataX);
                //dataY = result.ToList();
                //Graph.Plot.Add.Scatter(dataX, dataY);
                //Graph.Refresh();
            }

            catch
            {
                throw;
            }
        }

        private void Output(Dictionary<int, float[]> resultDic, List<float> dataX)
        { 
            string[] numGraphs = TbNumGraphs.Text.Split(',');
            foreach(var item in numGraphs)
            {
                if(item.Split('-').Length == 2)
                {
                    for (int i = Convert.ToInt32(item.Split('-')[0]); i <= Convert.ToInt32(item.Split("-")[1]); i++) 
                    {
                        List<float> dataY = resultDic[i].ToList();
                        Graph.Plot.Add.Scatter(dataX, dataY);
                        Graph.Refresh();
                    }
                }

                else
                {
                    List<float> dataY = resultDic[Convert.ToInt32(item)].ToList();
                    Graph.Plot.Add.Scatter(dataX, dataY);
                    Graph.Refresh();

                }
            }
        }

        private Dictionary<int, float[]> Slise(float[] result) 
        {
            int i = 1;
            int j = 0;
            Dictionary<int, List<float>> keyValuePairs = new Dictionary<int, List<float>>();
            List<float> data = new List<float>();
            foreach (var item in result) 
            {
                if (item == -1)
                {
                    keyValuePairs.Add(i, Array.Copy(data.ToArray(), new List<float>(), data.ToArray().Length));
                    data.Clear();
                    i++;
                    j++;

                }

                else
                {
                    data.Add(item);
                    j++;
                }
            }

            Dictionary<int, float[]> resultDic = new Dictionary<int, float[]>();
            foreach(var item in keyValuePairs.Keys)
            {
                resultDic.Add(item, keyValuePairs[item].ToArray());
            }

            return resultDic;
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
