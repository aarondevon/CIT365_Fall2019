using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 Created Console App using the .NET Framework

            // 2 
            string fullName = "Aaron Sawyer";
            string location = "Minnesota";

            // 3
            Console.WriteLine($"My name is {fullName}");
            Console.WriteLine($"I am from {location}");

            // 4
            Console.WriteLine(DateTime.Now.ToString("dd.MM.yyy"));

            // Task 5
            DateTime today = DateTime.Today;
            DateTime christmas = new DateTime(today.Year, 12, 25, 0, 0, 0);

            if (today > christmas)
            {
                christmas = christmas.AddYears(1);
            }

            Console.WriteLine($"There are {(christmas - today).Days} days till Christmas!");

            // Task 6a
            double width, height, woodLength, glassArea;
            string widthString, heightString;

            Console.Write("Enter width: ");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            Console.Write("Enter height: ");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            woodLength = 2 * (width + height) * 3.25;

            glassArea = 2 * (width * height);

            Console.WriteLine("The length of the wood is " + woodLength + " feet");
            Console.WriteLine("The area of the glass is " + glassArea + " square meters");

            // Task 6b
            Console.ReadLine();

        }
    }
}
