using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicSorter
{
     class Program
     {
          static void Main(string[] args)
          {
               String downloadLocation = @"F:\Downloads\";
               String holdingLocation = @"F:\Wolfpack\Comics\TO BE SORTED INTO RESPECTIVE FOLDERS";//Downloaded from unconventional means.
               String userInput = "";

               Console.WriteLine("Where do you want to sort from?  Enter your choice:  ");
               Console.WriteLine("1 \t Downloads folder\n2 \t TO BE SORTED folder\n3 \t Other - manual input location\n");


               Int32 input = Convert.ToInt32(Console.ReadLine());

               switch (input)
               {
                    case 1:
                         //1 downloads folder

                         break;
                    case 2:
                         //2 TO BE SORTED FOLDER

                         break;
                    case 3:
                         //3 other manual input
                         Console.Write("Enter the location you would like to sort from:  ");
                         userInput = Console.ReadLine();

                         break;
                    default:
                         Console.WriteLine("Failed to comply to directions. Terminating Life.");
                         Environment.Exit(0);
                         break;
               }

          }
     }
}
