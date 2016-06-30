using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell_GenericDelegateTypes
{
    public class Util
    {
        public static void Transform<T>(T[] values, Func<T,T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = transformer(values[i]);
        }
    }
    class Program
    {
        static int Square(int x) { return x * x; }
        static float Circumference(float x) { return x * 4; }
        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3 };
            Util.Transform(values, Square); // Hook in Square
            foreach (int i in values)
            {
                Console.Write(i + "  ");
            }

            Console.WriteLine();

            float[] vals = { 1.2f, 2.2f, 1.1f };
            Util.Transform(vals, Circumference); // Hook in Circurmference
            foreach (float i in vals)
            {
                Console.Write(i + " ");
            }
            Console.Read();
        }
    }
}
