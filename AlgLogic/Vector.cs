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

        public int[] GenerateRandomVector()
        {
            int[] vector = new int[vectorLength]; 
            Random random = new Random();

            for (int i = 0; i < vectorLength; i++)
            {
                vector[i] = (random.Next(0, rangeOfRandomNumbers));
            }

            return vector;
        }
        public int[] GenerateShuffleVector()
        {
            int[] vector = new int[vectorLength];

            for (int i = 0; i < vectorLength; i++)
            {
                vector[i] = i;
            }

            return Shuffle(vector);

        }
        static int[] Shuffle(int[] vector)
        {
            Random rng = new Random();
            int n = vector.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = vector[k];
                vector[k] = vector[n];
                vector[n] = value;
            }
            return vector;
        }
    }

}
