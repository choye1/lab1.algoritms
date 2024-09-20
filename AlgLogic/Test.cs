namespace AlgLogic
{
    public class Test
    {
        public AlgorithmItnerface Instance { set; get; }
        int rangeOfRandomNumbers { set; get; }
        int vectorLength { set; get; }
        int numberOfStarts { set; get; }

        int powNumber { set; get; }
        float[] vector { set; get; }
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
            for (int i = 0; i < numberOfStarts; i++)
            {
                for (int j = 0; j < vectorLength; j++)
                {
                    Timer timer = new Timer(Instance);
                    algorithmExecutionTime = timer.CalculateTime((float[])vector.Take(j));
                    points.Add(algorithmExecutionTime);
                }
                points.Add(0); // Максон, смотри если ты встречаешь ноль то ты дорисовал график и надо не удаляя текущий начать рисовать следующий поверх
            }
            return points.ToArray();
        }

    }

}
