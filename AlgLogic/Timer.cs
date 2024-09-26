using System.Diagnostics;

namespace AlgLogic
{
    public class Timer
    {
        public AlgorithmItnerface Instance { set; get; }
        public Timer(AlgorithmItnerface Instance)
        {
            this.Instance = Instance;
        }
        public float CalculateTime(int[] vector)
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

}
