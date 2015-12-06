using System;
using _03_GenericList.Interfaces;

namespace _03_GenericList
{
    class Program
    {
        static void Main()
        {
            try
            {
                IGenericList<int> l = new GenericList<int>(3);
                Console.WriteLine(l);
                l.Add(5);
                l.Add(-33);
                l.Add(15);
                l.Add(333);
                Console.WriteLine(l);
                Console.WriteLine("Element #2 (old value): {0}", l[2]);
                l[2] = 666;
                Console.WriteLine("Element #2 (new value):{0}", l[2]);
                Console.WriteLine(l);
                l.Remove(3);
                Console.WriteLine(l);
                l.Insert(999, 1);
                Console.WriteLine(l);
                Console.WriteLine("666 found at index: {0}", l.FindIndex(666));
                Console.WriteLine("Minimum element: {0}", l.Min());
                Console.WriteLine("Maximum element: {0}", l.Max());

                l.Clear();
                Console.WriteLine(l);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
