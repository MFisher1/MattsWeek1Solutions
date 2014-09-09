using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LambdaPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>() {"Basketball", "Baseball", "Tennis Raquet", "Running Shoes", "Wrestling Shoes", 
                "Soccer Ball", "Football", "Shoulder Pads", 
                "Trail Running Shoes", "Cycling Shoes", "Kayak", "Kayak Paddles"};


            //declare a variable kayakProducts and set it equal to all products that contain the word "Kayak"
            List<string> kayakProducts = products.Where(x => x.Contains("Kayak")).ToList();

            //print the kayakProducts to the console using a foreach loop.
            Console.WriteLine("print the kayakProducts to the console using a foreach loop.");
            foreach (var item in kayakProducts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            //declare a variable shoeProducts and set it equal to all products that contain the word "Shoes"
            List<string> shoeProducts = products.Where(x => x.Contains("Shoes")).ToList();

            //print the shoeProducts to the console using a foreach loop or string.Join().
            Console.WriteLine("print the shoeProducts to the console using a foreach loop or string.Join().");
            Console.WriteLine(string.Join(" ,", shoeProducts));
            Console.WriteLine();

            //declare a variable ballProducts and set it equal to all the products that have ball in the name.
            List<string> ballProducts = products.Where(x => x.Contains("ball")).ToList();

            //print the ballProducts to the console using a foreach loop or string.Join().
            Console.WriteLine("print the ballProducts to the console using a foreach loop or string.Join().");
            foreach (var item in ballProducts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //sort ballProducts alphabetically and print them to the console.
            Console.WriteLine("sort ballProducts alphabetically and print them to the console.");
            Console.WriteLine(string.Join(" ,", ballProducts.OrderBy(x => x)));

            //add six more items to the products list using .add().
            products.Add("Spam");
            products.Add("Bacon");
            products.Add("Marmolade");
            products.Add("PS4");
            products.Add("Chiiss(cool way of saying cheese)");
            products.Add("Porsche 918 Turbo");
            products.Add("Couldnt think of anything else");

            //print the product with the longest name to the console using the .First() extension.
            
            Console.WriteLine(string.Join(" ,",products.OrderBy(x => x.Length).First()));
            Console.WriteLine();

            //print the product with the shortest name to the console using OrderByDescending() and the .First() extension.
            Console.WriteLine(string.Join(" ,",products.OrderByDescending(x => x.Length).First()));
            Console.WriteLine();
            //print the product with the 4th shortest name to the console using an index or Skip/Take (you must convert the results to a list using .ToList()).
            Console.WriteLine(string.Join(" ,",products.OrderByDescending(x => x.Length).Skip(4).Take(1)));
            Console.WriteLine();

            //print the ballProduct with the 2nd longest name to the console using an index or Skip/Take (you must convert the results to a list using .ToList()).
            Console.WriteLine(string.Join(" ,",ballProducts.OrderBy(x => x.Length).Skip(2).Take(1)));
            Console.WriteLine();

            //declare a variable reversedProducts and set it equal to all products ordered by the longest word first. (use the OrderByDescending() extension).
            List<string> reversedProducts = products.OrderByDescending(x => x.Length).ToList();
              

            //print out the reversedProducts to the console using a foreach loop.
            foreach (var item in reversedProducts)
            {
                Console.WriteLine(reversedProducts);
            }
            Console.WriteLine();
              
            //print out all the products ordered by the longest word first using the OrderByDecending() extension and a foreach loop.  
            //Note: you will not use a variable to store your list
            foreach (var item in products.OrderByDescending(x => x.Length)) 
            {
                 
                 Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}