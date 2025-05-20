using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int myInt = 5;
            int mySecondInt = 10;
            
            // Console.WriteLine(myInt);
            
            // myInt++;

            // Console.WriteLine(myInt);

            // myInt+= 7;

            // myInt -= 8;

            // Console.WriteLine(myInt);

            // Console.WriteLine(myInt * mySecondInt);
            // Console.WriteLine(mySecondInt / myInt);

            // Console.WriteLine(mySecondInt + myInt);
            // Console.WriteLine(myInt - mySecondInt);

            // string myString = "test";

            // Console.WriteLine(myString);

            // myString += "second part";

            // Console.WriteLine(myString);

            if (myInt < mySecondInt) 
            {
                myInt += 10;
            }

            Console.WriteLine(myInt);

            string myCow = "Cow";
            string myCapitalizedCow = "Cow";

            if (myCow == myCapitalizedCow)
            {
                Console.WriteLine("Equal");
            } else 
            {
                Console.WriteLine("Not Equal");
            }

            switch (myCow)
            {
                case "cow":
                    Console.WriteLine("Lowercase");
                    break;
                case "Cow":
                    Console.WriteLine("Uppercase");
                    break;
                default:
                    Console.WriteLine("Default Ran");
                    break;
            }
        }
    }
}