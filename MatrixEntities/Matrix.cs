namespace MatrixEntities
{
    public class Matrix
    {
        private int[,] data;
        int matrixSize {  get; set; }
        public Matrix(int matrixSize) 
        {
            this.matrixSize = matrixSize;
            data = new int[matrixSize, matrixSize];
        }
        public Matrix(int[,] data)
        {
            this.data = data;
        }

        public Matrix GenerateRandomMatrix(int rangeOfRandomNumbers)
        {
            int[,] matrixData = new int[matrixSize, matrixSize];
            Random random = new Random();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixData[i, j] = random.Next(0, rangeOfRandomNumbers); // Генерация случайных неотрицательных чисел
                }
            }

            return new Matrix(matrixData);
        }

        public Matrix Multiply(Matrix A, Matrix B)
        {

            int[,] resultMatrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < matrixSize; k++)
                    {
                        resultMatrix[i, j] += A.data[i, k] * B.data[k, j];
                    }
                }
            }

            return new Matrix(resultMatrix);
        }

        public Matrix GetSubmatrix(int subSize)
        {

            int[,] submatrixData = new int[subSize, subSize];

            for (int i = 0; i < subSize; i++)
            {
                for (int j = 0; j < subSize; j++)
                {
                    submatrixData[i, j] = data[i, j];
                }
            }

            return new Matrix(submatrixData);
        }
    }
}
