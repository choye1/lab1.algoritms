namespace DijkstraAlgorithm
{

    public class GraphTest
    {
        int rangeOfRandomNumbers { set; get; }
        int graphSize { set; get; }
        int numberOfStarts { set; get; }

        Graph graph { set; get; }
        public GraphTest(int rangeOfRandomNumbers, int graphSize, int numberOfStarts)
        {
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            this.graphSize = graphSize;
            this.numberOfStarts = numberOfStarts;
            graph = new Graph(graphSize).GenerateRandomGraph(rangeOfRandomNumbers);
        }

        public float[] StartAlgorithm()
        {
            List<float> points = new List<float>();
            float algorithmExecutionTime;
            for (int i = 0; i < numberOfStarts; i++)
            {
                for (int j = 1; j < graphSize; j++)
                {
                    GraphTimer graphTimer = new GraphTimer();
                    algorithmExecutionTime = graphTimer.CalculateTime(graph, graph.GetSubGraph(j));
                    points.Add(algorithmExecutionTime);

                    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                    string filePath = Path.Combine(projectDirectory, "Dijkstra");
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(algorithmExecutionTime);
                    }
                }
                points.Add(0); // Максон, смотри если ты встречаешь ноль то ты дорисовал график и надо не удаляя текущий начать рисовать следующий поверх
            }
            return points.ToArray();
        }

    }

}