using MatrixEntities;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace AlgLogic
{

    public class Algorithm1 : AlgorithmItnerface
    {
        int[] vector { set; get; }
        public Algorithm1(int[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(int[] vector)
        {
            return 1;
        }
    }

    public class Algorithm2 : AlgorithmItnerface
    {
        int[] vector { set; get; }
        public Algorithm2(int[] vector)
        {
            this.vector = vector;
        }

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

    public class Algorithm3 : AlgorithmItnerface
    {
        int[] vector { set; get; }
        public Algorithm3(int[] vector)
        {
            this.vector = vector;
        }

        public int ExecuteAlgorithm(int[] vector)
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
        int[] vector { set; get; }
        public AlgorithmBubbleSort(int[] vector)
        {
            this.vector = vector;
        }

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
    public class AlgorithmQuickSort : AlgorithmItnerface
    {
        int[] vector { set; get; }
        public AlgorithmQuickSort(int[] vector)
        {
            this.vector = vector;
        }
        public void QuickSort(int[] vector, int left, int right)
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

        public int ExecuteAlgorithm(int[] vector)
        {
            int left = (int)vector[0];
            int right = (int)vector[vector.Length];
            QuickSort(vector, left, right);
            return 0;
        }

    }
    public class AlgorithmPolynome : AlgorithmItnerface
    {
        int[] vector { set; get; }
        public AlgorithmPolynome(int[] vector)
        {
            this.vector = vector;
        }
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
    public class AlgorithmPolynomeHorner : AlgorithmItnerface
    {
        int[] vector { set; get; }
        public AlgorithmPolynomeHorner(int[] vector)
        {
            this.vector = vector;
        }
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

    public class AlgorithmQuickPow : AlgorithmItnerface
    {
        int[] vector { set; get; }
        int n { get; set; }
        public AlgorithmQuickPow(int[] vector, int n)
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
        public int ExecuteAlgorithm(int[] vector)
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
        public int[] vector { set; get; }
        int n { set; get; }
        public AlgorithmQuickPow2(int[] vector, int n)
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

        public int ExecuteAlgorithm(int[] vector)
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
        public int[] vector { set; get; }
        int n { set; get; }
        public AlgorithmRecPow(int[] vector, int n)
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

        public int ExecuteAlgorithm(int[] vector)
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
        public int[] vector { set; get; }
        int n { set; get; }
        public AlgorithmClassicPow(int[] vector, int n)
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

        public int ExecuteAlgorithm(int[] vector)
        {
            for (int x = 0; x < vector.Length; x++)
            {
                ClassicPow(x, n);
            }

            return 1;
        }

        public class AlgorithmTimSort : AlgorithmItnerface
        {
            public int[] vector { set; get; }
            private const int RUN = 32;

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
        public class AlgorithmMerge : AlgorithmItnerface
        {
            public int[] vector { get; set; }

            public AlgorithmMerge(int[] vector)
            {
                this.vector = vector;
            }
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
    }

}
