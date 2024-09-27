using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgLogic
{
    public class ToWPF
    {
        public float[] ReadFloatArrayFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            float[] floatArray = new float[lines.Length];

            return floatArray;
        }
    }
}
