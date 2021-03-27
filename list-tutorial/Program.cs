using System;
using System.Collections.Generic;

namespace list_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Program:");

            var names = new List<string> {"wangyahzhu", "zhangyun", "anna", "anderson"};
            names.Add("wangzhumei");
            names.Add("Fliper");
            Console.WriteLine("names[0]:"+names[0]);
            foreach(var name in names) {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            var index = names.IndexOf("zhangyun");
            Console.WriteLine("张云在：" + index);
            
            // 使用列表的排序
            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            
            listInt();
        }

        static void listInt()
        {
            var fibNumbes = new List<int> {1, 1};

            var previous = fibNumbes[fibNumbes.Count - 1];
            var previous2 = fibNumbes[fibNumbes.Count - 2];
            
            fibNumbes.Add(previous+previous2);

            foreach (var item in fibNumbes)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
