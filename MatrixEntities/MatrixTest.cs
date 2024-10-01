namespace MatrixEntities
{
    public class MatrixTest
    {
        int rangeOfRandomNumbers { set; get; }
        int matrixSize { set; get; }
        int numberOfStarts { set; get; }

        Matrix A {  set; get; }
        Matrix B { set; get; }
        public MatrixTest(int rangeOfRandomNumbers, int matrixSize, int numberOfStarts)
        {
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            this.matrixSize = matrixSize;
            this.numberOfStarts = numberOfStarts;
            A = new Matrix(matrixSize).GenerateRandomMatrix(rangeOfRandomNumbers);
            B = new Matrix(matrixSize).GenerateRandomMatrix(rangeOfRandomNumbers);

        }
        
        public float[] StartAlgorithm()
        {
            List<float> points = new List<float>();
            float algorithmExecutionTime;
            for (int i = 0; i < numberOfStarts; i++)
            {
                for (int j = 1; j < matrixSize; j++)
                {
                    MatrixTimer matrixTimer = new MatrixTimer(j);
                    algorithmExecutionTime = matrixTimer.CalculateTime(A.GetSubmatrix(j), B.GetSubmatrix(j));
                    points.Add(algorithmExecutionTime*100);

                    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                    string filePath = Path.Combine(projectDirectory, "Matrix");
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(algorithmExecutionTime*100);
                    }
                }
                points.Add(-1); // Максон, смотри если ты встречаешь ноль то ты дорисовал график и надо не удаляя текущий начать рисовать следующий поверх
            }

            //WriteFile(points, "Matrix");
           
            
            return points.ToArray();
        }

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
       


    }
}
