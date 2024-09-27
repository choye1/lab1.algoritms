using System;
using System.Collections.Generic;
using System.Data;
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
            List<int> dataX = new List<int>();
            List<int> dataY = new List<int>();
            Graph.Plot.Add.Scatter(dataX, dataY);
        }

        private void BtStart(object sender, RoutedEventArgs e)
        {
            try {
                int maxValRandNum = (int) SlMaxVal.Value;
                int countStart = Convert.ToInt32(TbCountStart.Text);
                int vectorLength = 0; // // // // //

                ComboBoxItem typeItem = (ComboBoxItem)SelectAlg.SelectedItem;
                string nameAlg = typeItem.Content.ToString();
                AlgorithmInterface algorithm =  CreateInstanseAlg(nameAlg);

                Test test = new Test(algorithm, vectorLength, maxValRandNum, countStart);
                test.StartAlgorithm();
                
            }

            catch {
                throw;
            }

        }

        private AlgorithmInterface CreateInstanseAlg(string nameAlg)
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
                    return new AlgorithmClassicPow();

                default: return null; 


            }
        }


        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Clear();

        }

        
    }
}
