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
                double maxValRandNum = SlMaxVal.Value;
                int countStart = Convert.ToInt32(TbCountStart.Text);
                ComboBoxItem typeItem = (ComboBoxItem)SelectAlg.SelectedItem;
                string nameAlg = typeItem.Content.ToString();
                int vectorLength = 1;
                int rangeOfRandomNumbers = 2;
                Vector vector = new Vector(vectorLength, rangeOfRandomNumbers);
                
                CreateInstanseAlg(nameAlg, );
            }

            catch { }

        }

        private AlgorithmItnerface CreateInstanseAlg(string nameAlg, int[] vector)
        {
            switch (nameAlg)
            {
                case ("Постоянная ф-я"):
                    return new Algorithm1(vector);
                 
                case ("Сумма элементов"):
                    return new Algorithm2(vector);

                case ("Произведение эл-тов"): 
                    return new Algorithm3(vector);

                case ("Метод Горнера"):
                    return new AlgorithmPolynomeHorner(vector);

                case ("Bubble Sort"):
                    return new AlgorithmBubbleSort(vector);

                case ("Quick Sort"):
                    return new AlgorithmQuickSort(vector);

                case ("Tim Sort"):
                    return new AlgorithmTimSort(); //вот тут что то не то, он должен принимать вектор, а он отказывается

                case ("Возведение в степень"):
                    return new AlgorithmClassicPow(vector);

                default: return new Algorithm1(vector); 


            }
        }


        private void ClearPlot(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Clear();

        }

        
    }
}
