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
               ComicSorter cs = new ComicSorter();

               String downloadLocation = @"C:\temp\Downloads\";
               String holdingLocation = @"C:\temp\Comics\TO BE SORTED INTO RESPECTIVE FOLDERS";//Downloaded from unconventional means.
               String userInput = "";

               Console.WriteLine("Where do you want to sort from?  Enter your choice:  ");
               Console.WriteLine("1 \t Downloads folder\n2 \t TO BE SORTED folder\n3 \t Other - manual input location\n");

               Int32 input = Convert.ToInt32(Console.ReadLine());

               switch (input)
               {
                    case 1:
                         //1 downloads folder
                         cs.startingDir = downloadLocation;
                         break;
                    case 2:
                         //2 TO BE SORTED FOLDER
                         cs.startingDir = holdingLocation;
                         break;
                    case 3:
                         //3 other manual input
                         Console.Write("Enter the location you would like to sort from:  ");
                         userInput = Console.ReadLine();
                         cs.startingDir = userInput;
                         break;
                    default:
                         Console.WriteLine("Failed to comply to directions. Terminating Life.");
                         Environment.Exit(0);
                         break;
               }

               cs.folderRecursion(cs.startingDir);

               //I'll write the failed files code once i get the rest working.

          }
     }
}
