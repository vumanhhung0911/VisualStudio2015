using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidu01
{
    // Giá trị kiểu trả về là kiểu comparison, đây là kiểu liệt kê:
    public enum comparison
    {
        theFirstComesFirst = 1,
        theSecondComesFirst = 2
    }

    public class Pair
    {
        // Khai báo ủy quyền
        public delegate comparison WhichIsFirst(object obj1, object obj2);
        // Biến lưu giữ 2 đối tượng
        private object[] thePair = new object[2];

        // Đưa vào 2 đối tượng theo thứ tự
        public Pair(object firstObject, object secondObject)
        {
            thePair[0] = firstObject;
            thePair[1] = secondObject;
        }

        // Phủ quyết phương thức ToString()
        public override string ToString()
        {
            return thePair[0].ToString() + "," + thePair[1].ToString();
        }

        // Định nghĩa phương thức Sort() cho lớp Pair
        public void Sort(WhichIsFirst theDelegateFunc)
        {
            if(theDelegateFunc(thePair[0], thePair[1]) == comparison.theSecondComesFirst)
            {
                object temp = thePair[0];
                thePair[0] = thePair[1];
                thePair[1] = temp;
            }
        }
        // Thiết lập phương thức ReverseSort, Phương thức này đặt các mục trong mảng theo thứ tự ngược lại
        public void ReverseSort(WhichIsFirst theDelegateFunc)
        {
            if (theDelegateFunc(thePair[0], thePair[1]) == comparison.theFirstComesFirst)
            {
                object temp = thePair[0];
                thePair[0] = thePair[1];
                thePair[1] = temp;
            }
        }
    }

    // Tạo hai lớp đối tượng đơn giản
    public class Student
    {
        private string name;

        public Student(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public static comparison WhichStudentComesFirst(object o1, object o2)
        {
            Student s1 = (Student)o1;
            Student s2 = (Student)o2;
            return (String.Compare(s1.name, s2.name) < 0 ? comparison.theFirstComesFirst : comparison.theSecondComesFirst);
        }
    }
    public class Cat
    {
        // biến lưu giữ trọng lượng
        private int weight;

        public Cat(int weight)
        {
            this.weight = weight;
        }
        // sắp theo trọng lượng
        public static comparison WhichCatComesFirst(Object o1, Object o2)
        {
            Cat c1 = (Cat)o1;
            Cat c2 = (Cat)o2;
            return ((c1.weight > c2.weight) ? comparison.theSecondComesFirst : comparison.theFirstComesFirst);
        }
        public override string ToString()
        {
            return weight.ToString();
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            // tạo ra hai đối tượng Student và Cat
            // Đưa chúng vào hai đối tượng Pair
            Student Thao = new Student("Thao");
            Student Ba = new Student("Ba");
            Cat Mun = new Cat(5);
            Cat Ngao = new Cat(2);
            Pair studentPair = new Pair(Thao, Ba);
            Pair catPair = new Pair(Mun, Ngao);
            Console.WriteLine("Sinh vien \t\t\t: {0}", studentPair.ToString());
            Console.WriteLine("Meo \t\t\t: {0}", catPair.ToString());
            // tạo ủy quyền
            Pair.WhichIsFirst theStudentDelegate = new Pair.WhichIsFirst(Student.WhichStudentComesFirst);
            Pair.WhichIsFirst theCatDelegate = new Pair.WhichIsFirst(Cat.WhichCatComesFirst);
            // sắp xếp dùng ủy quyền
            studentPair.Sort(theStudentDelegate);
            Console.WriteLine("Sau khi sap xep studentPair\t\t:{0}", studentPair.ToString());
            studentPair.ReverseSort(theStudentDelegate);
            Console.WriteLine("Sau khi sap xep nguoc studentPair\t\t:{0}", studentPair.ToString());
            catPair.Sort(theCatDelegate);
            Console.WriteLine("Sau khi sap xep catPair\t\t:{0}", catPair.ToString());
            catPair.ReverseSort(theCatDelegate);
            Console.WriteLine("Sau khi sap xep nguoc catPair\t\t:{0}", catPair.ToString());

            Console.Read();
        }
        /*
        Trong đoạn chương trình thử nghiệm trên chúng ta tạo ra hai đối tượng Student và hai đối
        tượng Cat sau đó đưa chúng vào hai đối tượng chứa Pair theo từng loại. Bộ khởi dựng của lớp
        Student lấy một chuỗi đại diện cho tên của sinh viên và bộ khởi dựng của lớp Cat thì lấy một
        số int đại diện cho trọng lượng của mèo.

            Student Thao = new Student(“Thao”);
            Student Ba = new Student(“Ba”);
            Cat Mun = new Cat(“5”);
            Cat Ngao = new Cat(“2”);
            Pair studentPair = new Pair(Thao, Ba);
            Pair catPair = new Pair(Mun, Ngao);
            Console.WriteLine(“Sinh vien \t\t\t: {0}”, studentPair.ToString());
            Console.WriteLine(“Meo \t\t\t: {0}”, catPair.ToString());

        Sau đó chương trình in nội dung chứa bên trong của hai đối tượng chứa Pair, và chúng ta có
        thể thấy thứ tự như sau:

            Sinh vien : Thao, Ba
            Meo : 5, 2

        Thứ tự xuất hiện của nó chính là thứ tự đưa vào. Tiếp theo chúng ta khởi tạo hai đối tượng ủy
        quyền:

            Pair.WhichIsFirst theStudentDelegate = new Pair.WhichIsFirst( Student.WhichStudentComesFirst);
            Pair.WhichIsFirst theCatDelegate = new Pair.WhichIsFirst( Student.WhichCatComesFirst);

        Ủy quyền đầu tiên theStudentDelegate được tạo ra bằng cách truyền vào một phương thức
        tĩnh tương ứng của lớp Student.
        Đối tượng ủy quyền thứ hai, theCatDelegate được một phương thức tĩnh của lớp Cat.
        Bây giờ ta đã có các đối tượng ủy quyền, chúng ta truyền ủy quyền đầu tiên cho phương thức
        Sort của đối tượng Pair, và sau đó là phương thức ReverseSort. Kết quả được xuất ra màn
        hình:

            Sau khi sap xep studentPair : Ba, Thao
            Sau khi sap xep nguoc studentPair : Thao, Ba
            Sau khi sap xep catPair : 2, 5
            Sau khi sap xep nguoc catPair : 5, 2
        */
    }
}
