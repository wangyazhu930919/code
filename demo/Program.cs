using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Help h;
            Person p;

            h = sayHello;
            h();
            h = sayBye;
            h();

            void goStation(Action do_sth) {
                Console.WriteLine("去火车站");
                Console.WriteLine("找到站长");
                do_sth();
                Console.WriteLine("离开火车站");
            }

            goStation(()=>Console.WriteLine("打他一顿"));

            void sayHello() 
            {
                Console.WriteLine("hello");
            }

            void sayBye() {
                Console.WriteLine("GoodBye");
            }
        }
    }
}


delegate void Help();
delegate void do_sth();

class Person {

}