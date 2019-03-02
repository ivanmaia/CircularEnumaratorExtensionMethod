using System;
using System.Collections.Generic;
using DroopyExtensions;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello CircularEnumerator!");

            IEnumerable<string> list = new string[]{"1", "2", "3"};

            var ce = list.GetCircularEnumerator();

            while (ce.MoveNext())
            {
                Console.WriteLine(ce.Current);
            }
        }
    }
}
