using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace MatrixEntities
{
    public interface AlgorithmItnerface
    {
        int ExecuteAlgorithm(float[] vector);
    }
    public class Test
    {
        public AlgorithmItnerface Instance { set; get; }
        int rangeOfRandomNumbers { set; get; }
        int matrixSize { set; get; }
        int numberOfStarts { set; get; }

        Matrix A {  set; get; }
        Matrix B { set; get; }
        public Test(AlgorithmItnerface Instance, int rangeOfRandomNumbers, int matrixSize, int numberOfStarts)
        {
            this.Instance = Instance;
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            this.matrixSize = matrixSize;
            this.numberOfStarts = numberOfStarts;
            A = new Matrix(matrixSize, numberOfStarts).GenerateRandomMatrix();
            B = new Matrix(matrixSize, numberOfStarts).GenerateRandomMatrix();

        }
        
        public void StartAlgorithm()
        {
            List<float> points = new List<float>();
            float algorithmExecutionTime;
            for (int i = 0; i < numberOfStarts; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    //Timer timer = new Timer(Instance, (float[])vector.Take(j));
                    //algorithmExecutionTime = timer.CalculateTime();
                    //points.Add(algorithmExecutionTime);
                }
                points.Add(0); // Максон, смотри если ты встречаешь ноль то ты дорисовал график и надо не удаляя текущий начать рисовать следующий поверх
            }
            //return points.ToArray();
        }

    }
    public class MatrixTimer
    {
        //public AlgorithmItnerface Instance { set; get; }
        //public MatrixTimer(AlgorithmItnerface Instance)
        //{
        //    this.Instance = Instance;
        //}
        //public float CalculateTime(float[] vector)
        //{
        //    Stopwatch stopwatch = new Stopwatch();

        //    // Начинаем измерение времени
        //    stopwatch.Start();

        //    // Выполняем какую-то работу
        //    Instance.ExecuteAlgorithm(vector);

        //    // Останавливаем измерение времени
        //    stopwatch.Stop();

        //    // Получаем время выполнения в миллисекундах
        //    float elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        //    return elapsedMilliseconds;
        }

    }
    public class Matrix
    {
        private int[,] data;
        int matrixSize {  get; set; }
        int rangeOfRandomNumbers { set; get; }
        public Matrix(int matrixSize, int rangeOfRandomNumbers) 
        {
            this.matrixSize = matrixSize;
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
            data = new int[matrixSize, matrixSize];
        }
        public Matrix(int[,] data)
        {
            this.data = data;
        }

        public Matrix GenerateRandomMatrix()
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
