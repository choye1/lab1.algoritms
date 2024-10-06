using MathNet.Numerics;
using ScottPlot.Plottables;
using ScottPlot.WPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Alg
{
    public class Out
    {
        public List<float> dataX {  get; set; }
        public List<float> dataY { get; set; }
        

        public void Ret(bool aproximation, WpfPlot plot)
        {
            Output(Average(Slise(dataY)), plot);
            List<float> data = new List<float>();
            if ( aproximation )
            {
                data = Approximation(Average(Slise(dataY)));
                Output(data, plot, true);
            }

            
        }


        public List<float> Approximation( List<float> dataY)
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

            return(floats);


        }

        private List<float> Average(List<List<float>> resultList)
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

            return result;
        }

        private void Output(List<float> dataY, WpfPlot plot)
        {
            var pl = plot.Plot.Add.Scatter(dataX, dataY);
            var cal = new ScottPlot.Color(255, 255, 255, 255);
            pl.LineColor = cal;
            plot.Refresh();

        }

        private void Output(List<float> dataY, WpfPlot plot,bool fl)
        {
            var pl = plot.Plot.Add.Scatter(dataX, dataY);
            var cal = new ScottPlot.Color(255, 255, 255, 255);
            pl.LineColor = cal;
            pl.MarkerSize = 10;
            plot.Refresh();

        }


        private List<List<float>> Slise(List<float> dataY)
        { 
            List<List<float>> result = new List<List<float>>();
            List<float> floats = new List<float>();
            foreach (float f in dataY)
            {
                if (f == -1)
                {
                    result.Add(floats.ToList());
                    floats.Clear();

                }

                else
                {
                    floats.Add(f);
                }
            }

            return result;
        
        }

        public void Load(string name, WpfPlot plot, bool fl)
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

            if (fl)
            {
                Output(Approximation(res), plot);
            }

            Output(res, plot);
        }


    }

}
