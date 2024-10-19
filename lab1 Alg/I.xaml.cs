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

        

        private void BtStart(object sender, RoutedEventArgs e)
        {
            List<float> dataX = new List<float>();
            for (int i = 0; i < (int)SlVectorLength.Value-2; i++) { dataX.Add(i); }


            try
            {
                Out ret = new Out();
                int p = Convert.ToInt32(TbPow.Text);
                int maxValRandNum = (int)SlMaxVal.Value;
                int countStart = (int)SlCountStart.Value;
                int vectorLength = (int)SlVectorLength.Value;


                ComboBoxItem typeItem = (ComboBoxItem)SelectAlg.SelectedItem;
                string nameAlg = typeItem.Content.ToString();
                AlgorithmInterface algorithm = CreateInstanseAlg(nameAlg, p);

                if (CbLoad.IsChecked == true)
                {
                    ret.Load(nameAlg, Graph, CbAprox.IsChecked == true);

                }

                else
                {
                    Test test = new Test(algorithm, maxValRandNum, vectorLength, countStart);
                    float[] result = test.StartAlgorithm();
                    ret.dataX = dataX; 
                    ret.dataY = result.ToList();
                    ret.Ret(CbAprox.IsChecked == true, Graph);
                    
                   // test.WriteFile(result.ToList(),"Bubble Sort");  // запись в файл

                }
            }

            catch
            {
                throw;
            }
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
                    return new AlgorithmQuickPow();

                case ("Quick pow 2"):
                    return new AlgorithmQuickPow2();

                case ("Rec pow"):
                    return new AlgorithmRecPow();

                case ("Classic pow"):
                    return new AlgorithmClassicPow();

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
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Сумма элементов"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Произведение эл-тов"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Метод Горнера"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-2000, 100000, -10, 200);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Bubble Sort"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-100, 3000, -50, 600);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 3000;

                    break;

                case ("Quick Sort"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-400, 14800, -10, 300);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 1000;

                    break;

                case ("Tim Sort"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-400, 14800, -10, 300);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 1000;
                    break;

                case ("Quick pow"):
                    Graph.Plot.Axes.SetLimits(-500, 16000, -10, 75);
                    Graph.Plot.YLabel("Шаги");
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Quick pow 2"):
                    Graph.Plot.Axes.SetLimits(-500, 16000, -10, 80);
                    Graph.Plot.YLabel("Шаги");
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Rec pow"):
                    Graph.Plot.Axes.SetLimits(-500, 17000, 0, 90);
                    Graph.Plot.YLabel("Шаги");
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Classic pow"):
                    Graph.Plot.YLabel("Шаги");
                    Graph.Plot.Axes.SetLimits(-1000, 15000, -1000, 61000);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Полином"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-500, 20000, -20, 300);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 15000;
                    break;

                case ("Сортировка слиянием"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-400, 16800, -8, 260);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 1000;
                    break;

                case ("Задача о разбиении множества"):
                    Graph.Plot.YLabel("Время мс*100");
                    Graph.Plot.Axes.SetLimits(-10, 550, -1000, 30000);
                    Graph.Refresh();
                    SlVectorLength.Maximum = 1500;
                    SlMaxVal.Maximum = 1000;
                    break;


                default: return;

            }
        }
    }
}
