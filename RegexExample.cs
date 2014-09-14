//--------------------------------------------------------------
// Regex Example
//
// This example program shows how to use the Regex class
// to do searching and replacing with regular expressions.
//--------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// The Regex class is in the System.Text.RegularExpressions namespace.
// Adding the next line saves us some typing later on.
using System.Text.RegularExpressions;

namespace RegexExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // To use the Regex class, first create an object of type Regex.
            // I used "bunn" as the match text so it would match "bunnies"
            // or "bunny".
            Regex rgx1 = new Regex("bunn", RegexOptions.IgnoreCase);
           
            // Let's create another regex object.
            Regex rgx2 = new Regex("rabbit", RegexOptions.IgnoreCase);

            Console.WriteLine("What is your favorite animal?");
            string animal = Console.ReadLine();

            // Use the IsMatch() method to see if there is a match.
            if (rgx1.IsMatch(animal) || rgx2.IsMatch(animal))
            {
                Console.WriteLine("You said {0}.",animal);
                Console.WriteLine("Yes, bunnies are the best!");
            }
            else
            {
                Console.WriteLine("You said {0}.", animal);
                Console.WriteLine("Okay, whatever.  They aren't as good as bunnies.");
            }

            Console.WriteLine("\nWhat is your favorite quote?");
            string quote = Console.ReadLine();

            // This regular expression will find spaces.
            Regex rgx3 = new Regex(@"\s");

            // Use the Replace() method to search and replace
            // We'll replace all spaces with newlines.
            string newQuote = rgx3.Replace(quote, "\n");

            Console.WriteLine("You said: {0}",quote);
            Console.WriteLine("Did you mean:");
            Console.WriteLine(newQuote);

            Console.WriteLine("\nHit any key to close.");
            Console.ReadKey();
        }
    }
}
