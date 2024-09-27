namespace AlgLogic
{
    public class Test
    {
        public AlgorithmItnerface Instance { set; get; }
        int rangeOfRandomNumbers { set; get; }
        int vectorLength { set; get; }
        int numberOfStarts { set; get; }

        int powNumber { set; get; }
        int[] vector { set; get; }
        public Test(AlgorithmItnerface Instance, int rangeOfRandomNumbers, int vectorLength, int numberOfStarts)
        {
            this.Instance = Instance;
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            this.vectorLength = vectorLength;
            this.numberOfStarts = numberOfStarts;
            vector = new Vector(vectorLength, rangeOfRandomNumbers).GenerateRandomVector();
        }

        public Test(AlgorithmItnerface Instance, int rangeOfRandomNumbers, int vectorLength, int numberOfStarts, int powNum)
        {
            this.Instance = Instance;
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            this.vectorLength = vectorLength;
            this.numberOfStarts = numberOfStarts;
            vector = new Vector(vectorLength, rangeOfRandomNumbers).GenerateRandomVector();
            this.powNumber = powNum;
        }
        public float[] StartAlgorithm()
        {
            List<float> points = new List<float>();
            float algorithmExecutionTime;
            string algorithmName = ""; // надо будет потом сделать так чтобы при вызове теста для опр алгоса записывалось имя алгоса
            for (int i = 0; i < numberOfStarts; i++)
            {
                for (int j = 0; j < vectorLength; j++)
                {
                    Timer timer = new Timer(Instance);
                    algorithmExecutionTime = timer.CalculateTime(vector.Take(j).ToArray());
                    points.Add(algorithmExecutionTime);
                    string path = Path.Combine(Environment.CurrentDirectory, algorithmName);
                    File.WriteAllText(path, algorithmExecutionTime.ToString());
                }

                points.Add(0); // Максон, смотри если ты встречаешь ноль то ты дорисовал график и надо не удаляя текущий начать рисовать следующий поверх
            }

            return points.ToArray();
        }

    }

}
