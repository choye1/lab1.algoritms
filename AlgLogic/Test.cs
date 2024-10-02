using System;
using System.IO;
using System.Security.AccessControl;

namespace AlgLogic
{
    public class Test
    {
        public AlgorithmInterface Instance { set; get; }
        int rangeOfRandomNumbers { set; get; }
        int vectorLength { set; get; }
        int numberOfStarts { set; get; }

        int[] vector { set; get; }
        public Test(AlgorithmInterface Instance, int rangeOfRandomNumbers, int vectorLength, int numberOfStarts)
        {
            this.Instance = Instance;
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            this.vectorLength = vectorLength;
            this.numberOfStarts = numberOfStarts;
            vector = new Vector(vectorLength, rangeOfRandomNumbers).GenerateRandomVector();
        }

        public float[] StartAlgorithm()
        {
            List<float> points = new List<float>();
            float algorithmExecutionTime;
            string algorithmName = "Задача о разбиении множества"; // надо будет потом сделать так чтобы при вызове теста для опр алгоса записывалось имя алгоса
            for (int i = 0; i < numberOfStarts; i++)
            {
                for (int j = 1; j < vectorLength; j++)
                {
                    Timer timer = new Timer(Instance);
                    algorithmExecutionTime = timer.CalculateTime(vector.Take(j).ToArray());
                    points.Add(algorithmExecutionTime*100);
                }

                points.Add(-1); // Максон, смотри если ты встречаешь ноль то ты дорисовал график и надо не удаляя текущий начать рисовать следующий поверх
            }

            //WriteFile(points, algorithmName);

            return points.ToArray();
        }

        private void WriteFile(List<float> points,string algorithmName) 
        {
            string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).FullName).FullName;
            СheckingExistenceDirectory(path);
            path += "\\launches";

            CheckingExistenceFile(path, algorithmName);
            path += "\\" + algorithmName + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                
                foreach (float value in points) { writer.WriteLine(value);}
            }
        }

        private void СheckingExistenceDirectory(string path)
        {
            if (!Array.Exists(Directory.GetDirectories(path), element => element == "launches"))
            {
                Directory.CreateDirectory(path+"\\launches");
            }
        }

        private void CheckingExistenceFile(string path, string algorithmName)
        {  
            if (!File.Exists(path + "\\" + algorithmName + ".txt"))
            {
                FileStream file = File.Create(path + "\\" + algorithmName + ".txt");
                file.Close();
            } 
        }



    }

}
