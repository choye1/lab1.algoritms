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
        public AlgorithmItnerface Instance { set; get; }
        int rangeOfRandomNumbers{ set; get; }
        int vectorLength { set; get; }
        int numberOfStarts { set; get; }
        float[] vector {  set; get; }
        public Test(AlgorithmItnerface Instance, int rangeOfRandomNumbers, int vectorLength, int numberOfStarts)
        {
            this.Instance = Instance;
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            this.vectorLength = vectorLength;
            this.numberOfStarts = numberOfStarts;
            vector = new Vector(vectorLength, rangeOfRandomNumbers).GenerateRandomVector(); 
        }
        public float[] StartAlgorithm()
        {
            List<float> points = new List<float> ();
            float algorithmExecutionTime;
            for (int i = 0; i < numberOfStarts; i++)
            {
                for (int j = 0; j < vectorLength; j++)
                {
                    Timer timer = new Timer(Instance, vector);
                    algorithmExecutionTime = timer.CalculateTime();
                    points.Add(algorithmExecutionTime);
                }
                points.Add(0); // Максон, смотри если ты встречаешь ноль то ты дорисовал график и надо не удаляя текущий начать рисовать следующий поверх
            }
            return points.ToArray();
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
        float[] vector { set; get; }
        public AlgorithmItnerface Instance { set; get; }
        public Timer(AlgorithmItnerface Instance, float[] vector) 
        {
            this.Instance = Instance;

        }
        public float CalculateTime()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Начинаем измерение времени
            stopwatch.Start();

            // Выполняем какую-то работу
            Instance.ExecuteAlgorithm(vector);

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

    public class Algorithm2 : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public Algorithm2(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            int sum = 0;
            foreach (int v in vector)
            {
                sum += v;
            }
            return sum;
        }
    }

    public class Algorithm3 : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public Algorithm3(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            int mul = 0;
            foreach (int v in vector)
            {
                mul *= v;
            }
            return mul;
        }
    }

    public class AlgorithmBuble : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public AlgorithmBuble(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            float temp = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = i + 1; j < vector.Length; j++)
                {
                    if (vector[i] > vector[j])
                    {
                        temp = vector[i];
                        vector[i] = vector[j];
                        vector[j] = temp;
                    }
                }
            }
            return 0;
        }
    }
    public class AlgorithmQuick : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public AlgorithmQuick(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            float temp = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = i + 1; j < vector.Length; j++)
                {
                    if (vector[i] > vector[j])
                    {
                        temp = vector[i];
                        vector[i] = vector[j];
                        vector[j] = temp;
                    }
                }
            }
            return 0;
        }

    }
}
