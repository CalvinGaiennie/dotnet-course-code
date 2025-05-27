using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int myInt = 5;
            int mySecondInt = 10;

            int[] intsToCompress = new int[] {10, 15, 20, 25, 30, 12, 34};
            int[] newIntsToCompress = new int[] {1,2,3,4,5,1
            };

            int totalValue = 0;
            int newTotalValue = 0;

            foreach(int intForCompression in intsToCompress)
            {
                if (intForCompression > 20)
                {
                    if (intForCompression > 20)
                    {
                        totalValue += intForCompression;
                    }
                }
                Console.WriteLine(totalValue);
            };

           static int GetSum(int[] compressableIntArray) 
            {
                int totalValue = 0;
                foreach(int intForCompression in compressableIntArray)
                {
                    totalValue += intForCompression;
                }
                return totalValue;
            }

            totalValue = GetSum(intsToCompress);
            Console.WriteLine("Test");
            Console.WriteLine(totalValue);

            newTotalValue = GetSum(newIntsToCompress);
            Console.WriteLine("New Test");
            Console.WriteLine(newTotalValue);
        }
        
    }
}