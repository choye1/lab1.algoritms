namespace DijkstraAlgorithm
{
    public class Graph
    {
        public int[,] graphData;
        int graphSize { get; set; }
        public Graph(int graphSize)
        {
            this.graphSize = graphSize;
            graphData = new int[graphSize, graphSize];
        }
        public Graph(int[,] data)
        {
            this.graphData = data;
        }

        public Graph GenerateRandomGraph(int rangeOfRandomNumbers)
        {
            int[,] graphData = new int[graphSize, graphSize];
            Random random = new Random();

            for (int i = 0; i < graphSize; i++)
            {
                for (int j = 0; j < graphSize; j++)
                {
                    graphData[i, j] = random.Next(0, rangeOfRandomNumbers); // Генерация случайных неотрицательных чисел
                }
            }

            return new Graph(graphData);
        }

        public int[] Dijkstra(int[,] graph, int startVertex)
        {
            int numVertices = graph.GetLength(0);
            int[] distances = new int[numVertices];
            bool[] visited = new bool[numVertices];

            for (int i = 0; i < numVertices; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;
            }

            distances[startVertex] = 0;

            for (int count = 0; count < numVertices - 1; count++)
            {
                int u = MinDistance(distances, visited);
                visited[u] = true;

                for (int v = 0; v < numVertices; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 &&
                        distances[u] != int.MaxValue &&
                        distances[u] + graph[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + graph[u, v];
                    }
                }
            }

            return distances;
        }

        static int MinDistance(int[] distances, bool[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < distances.Length; v++)
            {
                if (!visited[v] && distances[v] <= min)
                {
                    min = distances[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public int[,] GetSubGraph(int subSize)
        {

            int[,] subGraphData = new int[subSize, subSize];

            for (int i = 0; i < subSize; i++)
            {
                for (int j = 0; j < subSize; j++)
                {
                    subGraphData[i, j] = graphData[i, j];
                }
            }

            return subGraphData;
        }

    }

}