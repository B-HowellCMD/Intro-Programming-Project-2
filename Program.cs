using System;

namespace HowellProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "orders.txt";
            StreamReader sr = new StreamReader(filename); // Calling the data from the .txt file
            string userName; // Users name from the .txt file
            int orderSize; // Displays the size the user chose
            int orderTea; // Displays the type of tea the user chose

            const double PLAIN_TEA_PRICE = 0.43; // Plain tea price per oz
            const double BLACK_TEA_PRICE = 0.53; // Black tea price per oz
            const double GREEN_TEA_PRICE = 0.65; // Green tea price per oz
            const double WHITE_TEA_PRICE = 0.78; // White tea price per oz
            const double TAX_RATE = 0.045; // sales tax 4.5%

            while (true)
            {
                Console.WriteLine("*** Welcome To The Tea Shop!! ***");
                Console.WriteLine("\t1. Plain Tea");
                Console.WriteLine("\t2. Black Tea");
                Console.WriteLine("\t3. Green Tea");
                Console.WriteLine("\t4. White Tea");
                Console.WriteLine("\t5. Exit Program");
                Console.Write("Enter the number of your choice: ");
                string userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                if (choice == 5)
                {
                    break; // Exit the program
                }

                if (choice < 1 || choice > 4) // Input validation
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    continue;
                }

                Console.WriteLine("\nSelect a size: ");
                Console.WriteLine("\t1. Small (8oz)");
                Console.WriteLine("\t2. Medium (16oz)");
                Console.WriteLine("\t3. Large (24oz)");
                Console.Write("Enter the number of your size choice: ");
                string sizeChoice = Console.ReadLine();

                if (!int.TryParse(sizeChoice, out int sizeOption)) // Checking if the user inputed a number and not a string
                {
                    Console.WriteLine("Invalid size choice. Please enter a number.");
                    continue;
                }

                if (sizeOption < 1 || sizeOption > 3)
                {
                    Console.WriteLine("Invalid size choice. Please enter a number between 1 and 3.");
                    continue;
                }

                double subTotal = 0.0; // Subtotal

                switch (choice) // Using one switch statement to do all of the logic, instead of the multiple nested if else statements
                {
                    case 1: // Plain Tea
                        subTotal = PLAIN_TEA_PRICE * GetSizeInOunces(sizeOption);
                        break;
                    case 2: // Black Tea
                        subTotal = BLACK_TEA_PRICE * GetSizeInOunces(sizeOption);
                        break;
                    case 3: // Green Tea
                        subTotal = GREEN_TEA_PRICE * GetSizeInOunces(sizeOption);
                        break;
                    case 4: // White Tea
                        subTotal = WHITE_TEA_PRICE * GetSizeInOunces(sizeOption);
                        break;
                }

                double salesTax = subTotal * TAX_RATE;
                double finalCost = subTotal + salesTax;

                Console.WriteLine("Subtotal : {0}\nSales Tax: {1}\nTotal Cost: {2}",
                    subTotal.ToString("c"), salesTax.ToString("c"), finalCost.ToString("c"));
            }
            while (!sr.EndOfStream)
            {
                userName = sr.ReadLine(); // Displays the users name
                orderSize = int.Parse(sr.ReadLine());
                orderTea = int.Parse(sr.ReadLine());
                sr.ReadLine();

                Console.WriteLine("Name on order: {0}\nPrice of Tea: {1}\nSales Tax: {2}\nOrder Cost: {3}");
            }
        }

        static int GetSizeInOunces(int sizeOption) // used to calculate the costs // Tried using the GetSizeInOunces without the static method, but I always got an error. After further research and reading the textbook, I found out about the static method
        {
            switch (sizeOption)
            {
                case 1:
                    return 8; 
                case 2:
                    return 16;
                case 3:
                    return 24;
                default:
                    return 0;
            }
        }
    }
}
