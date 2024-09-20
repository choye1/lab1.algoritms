﻿using MatrixEntities;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace AlgLogic
{

    public class Algorithm1 : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public Algorithm1(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            return 1;
        }
    }

    public class Algorithm2 : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public Algorithm2(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            int sum = 0;
            foreach (int v in vector)
            {
                sum += v;
            }
            return sum;
        }
    }

    public class Algorithm3 : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public Algorithm3(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            int mul = 0;
            foreach (int v in vector)
            {
                mul *= v;
            }
            return mul;
        }
    }

    public class AlgorithmBubbleSort : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public AlgorithmBubbleSort(float[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            float temp = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = i + 1; j < vector.Length; j++)
                {
                    if (vector[i] > vector[j])
                    {
                        temp = vector[i];
                        vector[i] = vector[j];
                        vector[j] = temp;
                    }
                }
            }
            return 0;
        }
    }
    public class AlgorithmQuickSort : AlgorithmItnerface
    {
        float[] vector { set; get; }
        public AlgorithmQuickSort(float[] vector)
        {
            this.vector = vector;
        }
        public void QuickSort(float[] vector, int left, int right)
        {
            if (left > right) return;
            int center = (int)vector[(vector.Length - 1) / 2];
            int i = left;
            int j = right;
            while (i <= j)
            {
                while (vector[i] < center) i++;
                while (vector[j] > center) j--;
                if (i <= j)
                {
                    int temp = (int)vector[i];
                    vector[i] = vector[j];
                    vector[j] = temp;
                    i++;
                    j--;
                }
            }
            QuickSort(vector, left, j);
            QuickSort(vector, i, right);
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            int left = (int)vector[0];
            int right = (int)vector[vector.Length];
            QuickSort(vector, left, right);
            return 0;
        }

    }

    public class AlgorithmQuickPow : AlgorithmItnerface
    {
        float[] vector { set; get; }
        int n { get; set; }
        public AlgorithmQuickPow(float[] vector, int n)
        {
            this.vector = vector;
            this.n = n;

        }
        public void QuickPow(int x, int n)
        {
            int c = x;
            int k = n;
            int f;

            if (k % 2 == 1)
            {
                f = c;
            }
            else
            {
                f = 1;
            }

            while (k != 0)
            {
                k = k / 2;
                c = c * c;

                if (k % 2 == 1)
                {
                    f = f * c;
                }
            }
        }
        public int ExecuteAlgorithm(float[] vector)
        {
            for (int x = 0; x < vector.Length; x++)
            {
                QuickPow(x, n);
            }
            return 0;
        }
    }

    public class AlgorithmQuickPow2 : AlgorithmItnerface
    {
        public float[] vector { set; get; }
        int n { set; get; }
        public AlgorithmQuickPow2(float[] vector, int n)
        {
            this.vector = vector;
            this.n = n;
        }
        public void QuickPow2(int x, int n)
        {
            int c = x;
            int f = 1;
            int k = n;
            while (k != 0)
            {
                if (k % 2 == 0)
                {
                    c = c * c;
                    k = k % 2;
                }

                else
                {
                    f = f * c;
                    k = k - 1;
                }

            }

        }

        public int ExecuteAlgorithm(float[] vector)
        {
            for (int x = 0; x < vector.Length; x++)
            {
                QuickPow2(x, n);
            }
            return 1;
        }
    }

    public class AlgorithmRecPow : AlgorithmItnerface
    {
        public float[] vector { set; get; }
        int n { set; get; }
        public AlgorithmRecPow(float[] vector, int n)
        {
            this.vector = vector;
            this.n = n;
        }
        public int RecPow(int x, int n)
        {
            int f;
            if (n == 0)
            {
                f = 1;
            }

            else
            {
                f = RecPow(x, n / 2);
                if (n % 2 == 1)
                {
                    f = f * f * x;
                }

                else
                {
                    f = f * f;
                }

            }

            return f;
        }

        public int ExecuteAlgorithm(float[] vector)
        {
            for (int x = 0; x < vector.Length; x++)
            {
                RecPow(x, n);   
            }

            return 1;
        }

    }

    public class AlgorithmClassicPow : AlgorithmItnerface
    {
        public float[] vector { set; get; }
        int n { set; get; }
        public AlgorithmClassicPow(float[] vector, int n)
        {
            this.vector = vector;
            this.n = n;
        }
        public void ClassicPow(int x, int n)
        {
            int f = 1;
            int k = 0;
            while (k < n)
            {
                f = f * x;
                k = k + 1;
            }

        }

        public int ExecuteAlgorithm(float[] vector)
        {
            for (int x = 0; x < vector.Length; x++)
            {
                ClassicPow(x, n);
            }

            return 1;
        }

    }

}