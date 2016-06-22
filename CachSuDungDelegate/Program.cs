using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachSuDungDelegate
{
    /*
    Ví dụ sau minh họa cách sử dụng của delegate trong C#.
    Delegate với tên printString có thể được sử dụng để tham
    chiếu phương thức mà nhận một chuỗi như là input và không 
    trả về cái gì.
    */
    /*
    Chúng ta sử dụng delegate này để gọi hai phương thức: 
        phương thức đầu tiên in chuỗi tới Console,
        và phương thức thứ hai in nó tới một File.
    */
    class PrintString
    {
        static FileStream fs;
        static StreamWriter sw;

        // delegate declaration
        public delegate void printString(string s);

        // this method prints to the console
        public static void WriteToScreen(string str)
        {
            Console.WriteLine("The String is: {0}", str);
        }

        // this method prints to a file
        public static void WriteToFile(string s)
        {
            fs = new FileStream("d:\\message.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        // this method takes the delegate as parameter and uses it to
        // call the methods as required
        public static void sendString(printString ps)
        {
            ps("Hello World");
        }
        static void Main(string[] args)
        {
            printString ps1 = new printString(WriteToScreen);
            printString ps2 = new printString(WriteToFile);
            sendString(ps1);
            sendString(ps2);
            Console.ReadKey();
        }
    }
}
