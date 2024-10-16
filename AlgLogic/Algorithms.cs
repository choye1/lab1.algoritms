using MatrixEntities;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.IO; 

namespace AlgLogic
{

    public class Algorithm1 : AlgorithmInterface
    {
        public Algorithm1() { }
        public int ExecuteAlgorithm(int[] vector)
        {
            return 1;
        }
    }

    public class Algorithm2 : AlgorithmInterface
    {
        public Algorithm2() { }
        public int ExecuteAlgorithm(int[] vector)
        {
            int sum = 0;
            foreach (int v in vector)
            {
                sum += v;
            }
            return sum;
        }
    }

    public class Algorithm3 : AlgorithmInterface
    {
        public Algorithm3() { }
        public int ExecuteAlgorithm(int[] vector)
        {
            int mul = 1;
            foreach (int v in vector)
            {
                mul *= v;
            }
            return mul;
        }
    }

    public class AlgorithmBubbleSort : AlgorithmInterface
    {
        public AlgorithmBubbleSort() { }
        public int ExecuteAlgorithm(int[] vector)
        {
            int temp = 0;
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
    public class AlgorithmQuickSort : AlgorithmInterface
    {
        public AlgorithmQuickSort() { }

        public void QuickSort(int[] vector, int left, int right)
        {
            if (left >= right) return;
            int center = vector[(left + right) / 2];
            int i = left;
            int j = right;
            while (i <= j)
            {
                while (vector[i] < center) i++;
                while (vector[j] > center) j--;
                if (i <= j)
                {
                    int temp = vector[i];
                    vector[i] = vector[j];
                    vector[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j) QuickSort(vector, left, j);
            if (i < right) QuickSort(vector, i, right);
        }

        public int ExecuteAlgorithm(int[] vector)
        {
            if (vector == null || vector.Length == 0) return 0;
            QuickSort(vector, 0, vector.Length - 1);
            return 0;
        }
    }

    public class AlgorithmPolynome : AlgorithmInterface
    {
        public AlgorithmPolynome() { }

        public void CalculatePolynome(int[] vector)
        {
            double result = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                result += vector[i] * Math.Pow(1.5, i);
            }
        }
        public int ExecuteAlgorithm(int[] vector)
        {
            CalculatePolynome(vector);
            return 0;
        }
    }
    public class AlgorithmPolynomeHorner : AlgorithmInterface 
    {
        public AlgorithmPolynomeHorner() { }// int[] vector) { }
        public void CalculatePolynomeHorner(int[] vector)
        {
            double result = vector[vector.Length - 1];
            for (int i = vector.Length - 2; i >= 0; i--)
            {
                result = result * 1.5 + vector[i];
            }
        }
        public int ExecuteAlgorithm(int[] vector)
        {
            CalculatePolynomeHorner(vector);
            return 0;
        }
    }

    public class AlgorithmQuickPow : AlgorithmInterface
    {
        public AlgorithmQuickPow()
        {
        }

        public int QuickPow(int num, int power)
        {
            long result;
            int steps = 0;

            if (power % 2 == 1)
            {
                result = num;
                steps+=2;
            }
            else
            {
                result = 1;
                steps++;
            }
            while (power != 0)
            {               
                power /= 2;
                num *= num;
                steps += 3;

                if (power % 2 == 1)
                {
                    result *= num;
                    steps+=2;
                }
            }
            return steps;
        }

        public int ExecuteAlgorithm(int[] vector)
        {
            int x = vector.Length;
            return QuickPow(2, x);
        }
    }


    public class AlgorithmQuickPow2 : AlgorithmInterface
    {
        public AlgorithmQuickPow2()
        {
        }

        public int QuickPow2(int n, int x)
        {
            int count = 0;
            int c = x;
            int f = 1;
            int k = n;

            count += 3; // Инициализация переменных

            while (k != 0)
            {
                count += 1; // Проверка условия цикла
                if (k % 2 == 1)
                {
                    f = f * c;
                    count += 2; // Умножение f на c
                }
                c = c * c;
                k = k / 2;
                count += 2; // Умножение c на c и деление k на 2
            }
            count++; // Завершение цикла
            return count;
        }

        public int ExecuteAlgorithm(int[] vector)
        {
            int x = vector.Length;
            return QuickPow2(x, 2);
        }
    }



public class AlgorithmRecPow : AlgorithmInterface
    {
        public AlgorithmRecPow()
        {
        }

        public int RecPow(int n, int x, ref int c)
        {
            c += 1;
            int f;
            if (n == 0)
            {
                f = 1;
                c += 2;
            }
            else
            {
                c += 1;
                f = RecPow(n / 2, x, ref c);
                if (n % 2 == 1)
                {
                    f = f * f * x;
                    c += 3;
                }
                else
                {
                    f = f * f;
                    c += 2;
                }
            }
            c += 1;
            return f;
        }

        public int ExecuteAlgorithm(int[] vector)
        {
            int c = 0;
            int x = vector.Length;
            RecPow(x, 2, ref c);
            return c;
        }
    }


    public class AlgorithmClassicPow : AlgorithmInterface
    {
        public AlgorithmClassicPow()
        {
        }
        public int ClassicPow(int n, int x)
        {
            int c = 0;
            int f = 1;
            int k = 0;
            c += 2;
            while (k < n)
            {
                f = f * x;
                k = k + 1;
                c += 4;
            }
            c += 1;
            return c;

        }

        public int ExecuteAlgorithm(int[] vector)
        {
            int x = vector.Length;
            return ClassicPow(x, 2);
        }

        public class AlgorithmTimSort : AlgorithmInterface
        {
            private const int RUN = 32;
            public AlgorithmTimSort() { }

            public static void InsertionSort(int[] arr, int left, int right)
            {
                for (int i = left + 1; i <= right; i++)
                {
                    int temp = arr[i];
                    int j = i - 1;
                    while (j >= left && arr[j] > temp)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    arr[j + 1] = temp;
                }
            }

            public static void Merge(int[] arr, int left, int mid, int right)
            {
                int len1 = mid - left + 1, len2 = right - mid;
                int[] leftArr = new int[len1];
                int[] rightArr = new int[len2];

                Array.Copy(arr, left, leftArr, 0, len1);
                Array.Copy(arr, mid + 1, rightArr, 0, len2);

                int i = 0, j = 0, k = left;
                while (i < len1 && j < len2)
                {
                    if (leftArr[i] <= rightArr[j])
                        arr[k++] = leftArr[i++];
                    else
                        arr[k++] = rightArr[j++];
                }

                while (i < len1)
                    arr[k++] = leftArr[i++];

                while (j < len2)
                    arr[k++] = rightArr[j++];
            }

            public static void TimSortAlgorithm(int[] arr, int n)
            {
                // Сортировка каждого маленького подмассива вставками
                for (int i = 0; i < n; i += RUN)
                    InsertionSort(arr, i, Math.Min(i + RUN - 1, n - 1));

                // Слияние подмассивов
                for (int size = RUN; size < n; size = 2 * size)
                {
                    for (int left = 0; left < n; left += 2 * size)
                    {
                        int mid = left + size - 1;
                        int right = Math.Min((left + 2 * size - 1), (n - 1));

                        if (mid < right)
                            Merge(arr, left, mid, right);
                    }
                }
            }
            public int ExecuteAlgorithm(int[] vector)
            {  
                TimSortAlgorithm(vector, vector.Length);
                return 0;
            }
        }
        public class AlgorithmMerge : AlgorithmInterface
        {
            public AlgorithmMerge() { }
            static void Merge(int[] vector, int lowIndex, int middleIndex, int highIndex)
            {
                var left = lowIndex;
                var right = middleIndex + 1;
                var tempArray = new int[highIndex - lowIndex + 1];
                var index = 0;

                while ((left <= middleIndex) && (right <= highIndex))
                {
                    if (vector[left] < vector[right])
                    {
                        tempArray[index] = vector[left];
                        left++;
                    }
                    else
                    {
                        tempArray[index] = vector[right];
                        right++;
                    }

                    index++;
                }

                for (var i = left; i <= middleIndex; i++)
                {
                    tempArray[index] = vector[i];
                    index++;
                }

                for (var i = right; i <= highIndex; i++)
                {
                    tempArray[index] = vector[i];
                    index++;
                }

                for (var i = 0; i < tempArray.Length; i++)
                {
                    vector[lowIndex + i] = tempArray[i];
                }
            }

            //сортировка слиянием

            static void MergeSort(int[] vector, int lowIndex, int highIndex)
            {
                if (lowIndex < highIndex)
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(vector, lowIndex, middleIndex);
                    MergeSort(vector, middleIndex + 1, highIndex);
                    Merge(vector, lowIndex, middleIndex, highIndex);
                }
            }
            static void MergeSort(int[] vector)
            {
                MergeSort(vector, 0, vector.Length - 1);
            }
            public int ExecuteAlgorithm(int[] vector)
            {
                MergeSort(vector);
                return 0;
            }
        }
       


        public class ALgorithmNumberPartitioning : AlgorithmInterface
        {
            public ALgorithmNumberPartitioning() { }

            public static bool CanPartition(int[] nums)
            {
                // считаем сумму все элементов
                int totalSum = 0;
                foreach (int num in nums)
                {
                    totalSum += num;
                }

                if (totalSum % 2 != 0)
                {
                    return false;
                }

                // находим половину суммы
                int targetSum = totalSum / 2;

                bool[,] dp = new bool[nums.Length + 1, targetSum + 1];

                // заполняем первую строку
                for (int i = 0; i <= nums.Length; i++)
                {
                    dp[i, 0] = true;
                }
                //заполняем массив
                for (int i = 1; i <= nums.Length; i++)
                {
                    for (int j = 1; j <= targetSum; j++)
                    {
                        if (nums[i - 1] > j)
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                        }
                    }
                }

                return dp[nums.Length, targetSum];
            }

            public int ExecuteAlgorithm(int[] vector)
            {
                CanPartition(vector);
                return 0;
            }
        }
    }

}
