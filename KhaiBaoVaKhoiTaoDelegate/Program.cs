using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuong11_UyQuyenSuKien
{
    /*
    Ủy quyền được dùng để xác định những loại phương thức có thể được dùng để xử lý các sự kiện
    và để thực hiện callback trong chương trình ứng dụng. Chúng cũng có thể được sử dụng để xác
    định các phương thức tĩnh và các instance của phương thức mà chúng ta không biết cho đến khi
    chương trình thực hiện /// thực sự là éo hiểu @@
    */

    
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

            TestDelegate.AddNum(15); // khác biệt gì ở đây mà tại sao lại phải dùng delegate trong khi kết quả như nhau?
            Console.WriteLine("Value of Num: {0}", TestDelegate.getNum());
            TestDelegate.MultNum(2);
            Console.WriteLine("Value of Num: {0}", TestDelegate.getNum());

            Console.Read();
        }
    }
}
