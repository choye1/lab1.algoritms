using System.Diagnostics;
using System.Timers;

namespace AlgLogic
{
    public class Timer
    {
        public AlgorithmInterface Instance { set; get; }
        public Timer(AlgorithmInterface Instance)
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
            TimeSpan timeSpan = stopwatch.Elapsed;
            stopwatch.Reset();

            // Получаем время выполнения в миллисекундах
            return (float)timeSpan.TotalMilliseconds;
        }

    }

}
