using System;
using System.Collections.Generic;

namespace Archz
{
    class Program
    {
        static void Main(string[] args)
        {
            core.Archz archz = new core.Archz();
            archz.Run();

#if DEBUG
            Console.ReadLine();
#endif
        }

        static void foo()
        {
            Console.WriteLine("Zero parameters methods was called");
        }
    }
}
