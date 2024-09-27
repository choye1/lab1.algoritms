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
                    points.Add(algorithmExecutionTime);

                    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                    string filePath = Path.Combine(projectDirectory, "Matrix");
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
