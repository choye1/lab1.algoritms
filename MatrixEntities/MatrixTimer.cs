using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace MatrixEntities
{
    public class MatrixTimer
    {
        int matrixSize { set; get; }

        public MatrixTimer(int matrixSize)
        {
            this.matrixSize = matrixSize;
        }
        public float CalculateTime(Matrix A, Matrix B)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Начинаем измерение времени
            stopwatch.Start();

            // Выполняем какую-то работу
            Matrix C = new Matrix(matrixSize).Multiply(A, B);

            // Останавливаем измерение времени
            stopwatch.Stop();

            // Получаем время выполнения в миллисекундах
            float elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            return elapsedMilliseconds;
        }

    }
}
