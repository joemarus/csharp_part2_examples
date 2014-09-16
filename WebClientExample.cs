//-----------------------------------------------------------------------------
// Use WebClient
//
//  A short example of how to read the contents of a web page with the 
//  WebClient class.
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
// The WebClient class is in the System.Net namespace.
using System.Net;

namespace UseWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let's make an object of type WebClient.
            WebClient wc = new WebClient();

            Console.WriteLine("Downloading...");
            // Use the DownloadString method to get the contents of the web page 
            // as a string.
            string contents = wc.DownloadString("http://apod.nasa.gov/apod/astropix.html");
            Console.WriteLine(contents);

            // Let's use a Regex object to search for the image tag.
            Regex rgx = new Regex("<img src=\"(.*)\"", RegexOptions.IgnoreCase);
            string pic = "";

            // Use the Matches property to see if we found anything.
            foreach ( Match m in rgx.Matches(contents) )
            {
                // Use the Groups collection of the match object to extract 
                // the text in the parenthesis.
                Console.WriteLine("I found this: {0}", m.Groups[1]);
                pic = m.Groups[1].ToString();
            }

            pic = "http://apod.nasa.gov/apod/" + pic;

            Console.WriteLine("Downloading picture...");
            // Use the DownloadFile method of the webclient object to, well, download a file.
            wc.DownloadFile(pic,@"C:\users\jmaru_000\Pictures\apod.jpg");

            Console.WriteLine("\nHit any key to exit");
            Console.ReadKey();
        }
    }
}
