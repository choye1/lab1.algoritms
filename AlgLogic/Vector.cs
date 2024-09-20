namespace AlgLogic
{
    class Vector
    {
        int vectorLength { set; get; }
        int rangeOfRandomNumbers { set; get; }

        public Vector(int vectorLength, int rangeOfRandomNumbers)
        {
            this.vectorLength = vectorLength;
            this.rangeOfRandomNumbers = rangeOfRandomNumbers;
        }
        public float[] GenerateRandomVector()
        {
            float[] vector = new float[vectorLength]; //перепишите пж чтобы вектор был интовым и генерился на рандомных интах
            Random random = new Random();

            for (int i = 0; i < vectorLength; i++)
            {
                vector[i] = (float)(random.NextDouble() * rangeOfRandomNumbers);
            }

            return vector;
        }
        public float[] GenerateShuffleVector()
        {
            float[] vector = new float[vectorLength];

            for (int i = 0; i < vectorLength; i++)
            {
                vector[i] = i;
            }

            return Shuffle(vector);

        }
        static float[] Shuffle(float[] vector)
        {
            Random rng = new Random();
            int n = vector.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                float value = vector[k];
                vector[k] = vector[n];
                vector[n] = value;
            }
            return vector;
        }
    }

}
