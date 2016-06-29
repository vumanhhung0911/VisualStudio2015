using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    delegate T NumberChanger<T>(T n);

    // Class test delegate
    class Example03
    {
        static int num = 10;
        static float numf = 10.5f;
        public static int Addnum(int p)
        {
            return num += p;
        }

        public static float Addnum(float p)
        {
            return numf += p;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static float MultNum(float q)
        {
            return numf *= q;
        }

        public static int getNum()
        {
            return num;
        }
        public static float getNumFloat()
        {
            return numf;
        }

        static void Main(string[] args)
        {
            // create delegate instances
            NumberChanger<int> nc1 = new NumberChanger<int>(Addnum);
            NumberChanger<int> nc2 = new NumberChanger<int>(MultNum);

            //calling the methods using the delegate objects
            nc1(25);
            Console.WriteLine("Value of Num : {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num : {0}", getNum());

            NumberChanger<float> nc3 = new NumberChanger<float>(Addnum);
            NumberChanger<float> nc4 = new NumberChanger<float>(MultNum);

            //calling the methods using the delegate objects
            nc3(25);
            Console.WriteLine("Value of Num : {0}", getNumFloat());
            nc4(5);
            Console.WriteLine("Value of Num : {0}", getNumFloat());


            Console.Read();
      
        }
    }
}
