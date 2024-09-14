using System.Diagnostics;
using System.Drawing;

namespace AlgLogic
{
    public interface AlgorithmItnerface
    {
        int ExecuteAlgorithm(float[] vector);
    }
    public class Test
    {
        int rangeOfRandomNumbers{ set; get; }
        int vectorLength { set; get; }
        int numberOfStarts { set; get; }
        float[] vector {  set; get; }
        public Test(int rangeOfRandomNumbers, int vectorLength, int numberOfStarts)
        {
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            this.vectorLength = vectorLength;
            this.numberOfStarts = numberOfStarts;
            vector = new Vector(vectorLength, rangeOfRandomNumbers).GenerateRandomVector(); 
        }

    }

    class Vector
    {
        int vectorLength { set; get; }
        int rangeOfRandomNumbers { set; get; }

        public Vector(int vectorLength, int rangeOfRandomNumbers)
        {
            this.vectorLength = vectorLength;
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
        }
        public float[] GenerateRandomVector()
        {
            float[] vector = new float[vectorLength];
            Random random = new Random();

            for (int i = 0; i < vectorLength; i++)
            {
                vector[i] = (float) (random.NextDouble() * rangeOfRandomNumbers); 
            }

            return vector;
        }
        public float[] GenerateShuffleVector()
        {
            float[] vector = new float[vectorLength];

            for (int i = 0; i < vectorLength; i++)
            {
                vector[i] = i;
            }

            return Shuffle(vector);

        }
        static float[] Shuffle(float[] vector)
        {
            Random rng = new Random();
            int n = vector.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                float value = vector[k];
                vector[k] = vector[n];
                vector[n] = value;               
            }
            return vector;
        }
    }

    public class Timer
    {
        List<Point> points = new List<Point>();
        float timeOFAlg { set; get; }
        int currentNumberOfIterations { set; get; }
        public Timer(int currentNumberOfIterations)
        {
            this.currentNumberOfIterations = currentNumberOfIterations;
        }
        float CalculateTime()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Начинаем измерение времени
            stopwatch.Start();

            // Выполняем какую-то работу
            

            // Останавливаем измерение времени
            stopwatch.Stop();

            // Получаем время выполнения в миллисекундах
            float elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            return elapsedMilliseconds;
        }
    }

    public class Algorithm1: AlgorithmItnerface
    {
        float[] vector { set; get; }
        public Algorithm1(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            return 1;
        }
    }
}
