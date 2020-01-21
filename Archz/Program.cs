using System;

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
    }
}
