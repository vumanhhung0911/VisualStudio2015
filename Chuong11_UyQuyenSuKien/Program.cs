using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuong11_UyQuyenSuKien
{
    delegate int NumberChanger(int n);
    class TestDelegate
    {
        static int num = 10;
        public static int AddNum(int p)
        {
           return num += p;
        }
        public static int MultNum(int q)
        {
            return num *= q;
        }
        public static int getNum()
        {
            return num;
        }
        static void Main(string[] args)
        {
            //Create delegate instances
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);

            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());

            nc2(5);
            Console.WriteLine("Value of Num: {0}", getNum());

            Console.Read();

        }
    }
}
