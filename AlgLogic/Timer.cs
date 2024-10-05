using System.Configuration.Assemblies;
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
            if (Instance is AlgorithmClassicPow || Instance is AlgorithmRecPow || Instance is AlgorithmQuickPow || Instance is AlgorithmQuickPow2)
            {
                return Instance.ExecuteAlgorithm(vector);
            }

            else
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
                return (float)timeSpan.TotalMilliseconds * 100;
            }
        }

    }

}
