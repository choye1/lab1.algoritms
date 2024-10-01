using System.Diagnostics;

namespace DijkstraAlgorithm
{
    public class GraphTimer
    {
        public GraphTimer() { }
        public float CalculateTime(Graph graph, int[,] graphData)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Начинаем измерение времени
            stopwatch.Start();

            // Выполняем какую-то работу
            int[] result = graph.Dijkstra(graphData, 0);

            // Останавливаем измерение времени
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            stopwatch.Reset();

            // Получаем время выполнения в миллисекундах
            return (float)timeSpan.TotalMilliseconds;
        }

    }

}