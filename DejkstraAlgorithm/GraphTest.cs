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
                        //writer.WriteLine(algorithmExecutionTime);
                    }
                }
                points.Add(-1); // Максон, смотри если ты встречаешь ноль то ты дорисовал график и надо не удаляя текущий начать рисовать следующий поверх
            }

           // WriteFile(points, "Dextra");
            return points.ToArray();
        }

        ///* В конце удалить "//" здесь и в конце файла тест.
        private void WriteFile(List<float> points, string algorithmName)
        {
            string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).FullName).FullName;
            СheckingExistenceDirectory(path);
            path += "\\launches";

            CheckingExistenceFile(path, algorithmName);
            path += "\\" + algorithmName + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {

                foreach (float value in points) { writer.WriteLine(value); }
            }
        }

        private void СheckingExistenceDirectory(string path)
        {
            if (!Array.Exists(Directory.GetDirectories(path), element => element == "launches"))
            {
                Directory.CreateDirectory(path + "\\launches");
            }
        }

        private void CheckingExistenceFile(string path, string algorithmName)
        {
            if (!File.Exists(path + "\\" + algorithmName + ".txt"))
            {
                FileStream file = File.Create(path + "\\" + algorithmName + ".txt");
                file.Close();
            }
        }
        //*/

    }

}