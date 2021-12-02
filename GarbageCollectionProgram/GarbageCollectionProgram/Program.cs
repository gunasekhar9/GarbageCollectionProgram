using System;

namespace GarbageCollectionProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            long men1 = GC.GetTotalMemory(false);
            {
                //Allocate an array and make it unreachable.
                int[] values = new int[50000];
                values = null;
            }
            long men2 = GC.GetTotalMemory(false);
            {
                // collect garbage.
                GC.Collect();
            }
            long men3 = GC.GetTotalMemory(false);
            {
                Console.WriteLine(men1);
                Console.WriteLine(men2);
                Console.WriteLine(men3);
            }
            Console.WriteLine("################");
            long bytes1 = GC.GetTotalMemory(false); // get memory in bytes
            byte[] memory = new byte[1000 * 1000 * 10]; // ten million bytes
            memory[0] = 1; //set memory (prevent allocation from being optimized out)

            long bytes2 = GC.GetTotalMemory(false); // get memory
            long bytes3 = GC.GetTotalMemory(true); //get memory

            Console.WriteLine(bytes1);
            Console.WriteLine(bytes2);
            Console.WriteLine(bytes2 - bytes1); // write difference
            Console.WriteLine(bytes3);
            Console.WriteLine(bytes3 - bytes2); // write difference
            Console.ReadLine();
        }
    }
}