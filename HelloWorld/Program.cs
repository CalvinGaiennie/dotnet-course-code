using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] myGroceryArray = new string[2];

            myGroceryArray[0] = "Cheese";
            myGroceryArray[1] = "Milk";

            // List<string> myGroceryList = new List<string>();
            // myGroceryList.Add("Ice Cream");

            List<string> myGroceryList = ["Ice Cream", "Crackers"];

            Console.WriteLine(myGroceryList[0]);

            IEnumerable<string> myGroceryEnumerable = myGroceryList;

            List<string> mySecondGroceryList = myGroceryEnumerable.ToList();

            string[,] myMultiDemensionalArray = {{"a","b"},{"c","d"},{"e","f"}};
            Console.WriteLine(myMultiDemensionalArray[0,0]);
            Console.WriteLine(myMultiDemensionalArray[2,1]);

            Dictionary<string, int> groceryPrices = new Dictionary<string, int>();

            groceryPrices["Cheese"] = 5;

            Console.WriteLine(groceryPrices["Cheese"]);
        }
    }
}