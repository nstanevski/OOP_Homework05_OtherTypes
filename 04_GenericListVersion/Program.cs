using System;
using _03_GenericList.Attributes;

namespace _03_GenericList
{
    class Program
    {
        static void Main()
        {
            
            Type genericListType = typeof(GenericList<int>);
            object[] attributes = genericListType.GetCustomAttributes(false);
            foreach (var attrib in attributes)
            {
                if (attrib is VersionAttribute)
                {
                    Console.WriteLine("Version attribute value: {0}", attrib);
                }
                
            }
        }
    }
}
