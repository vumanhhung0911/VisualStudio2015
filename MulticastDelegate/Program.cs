using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegate
{
    /*
    Các đối tượng delegate có thể được hợp thành bởi sử dụng toán tử "+".
    Một delegate được hợp thành gọi hai delegate mà nó được hợp thành từ đó.
    Chỉ có các delegate cùng kiểu có thể được hợp thành. Toán tử "-" có thể
    được sử dụng để gỡ bỏ một delegate thành phần từ một delegate hợp thành.
    */
    /*
    Sử dụng thuộc tính này của các delegate, bạn có thể tạo một danh sách 
    triệu hồi của các phương thức mà sẽ được gọi khi delegate đó được triệu
    hồi. Điều này được gọi là Multicasting của một Delegate.
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
            // Create delegate instances
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            NumberChanger nc3 = new NumberChanger(AddNum);

            nc = nc1;
            nc += nc2;
            nc += nc3;

            // calling multicast
            nc(5);
            Console.WriteLine("Value of num: {0}", getNum());
           //  Console.Read();

            // Gỡ bỏ một thành phần delegate
            nc -= nc3;
            nc(5);
            Console.WriteLine("Value of num: {0}", getNum());
            Console.Read();

        }
    }
}
