using System;

namespace denoCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double x1 = Math.PI;
            double x2 = 4.23;
            double result = my_add(x1,x2);
            Console.WriteLine(result);

            int sum = 0;
            for (var i = 1; i<10000; i++){
                sum = sum +i;
            }
            Console.WriteLine("sum: " + sum);
            
            // 调用hello_world函数
            hello_world();
        }

        static double my_add(double x, double y){
            double result;
            result = x+y;
            return result;
        }

        static void hello_world()
        {
            Console.WriteLine("I coding in Rider " + DateTime.Now);
        }
    }
}
