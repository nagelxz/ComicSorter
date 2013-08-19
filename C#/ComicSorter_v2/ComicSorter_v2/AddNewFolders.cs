using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ComicSorter_v2
{
     public class AddNewFolders
     {
          public String directory = @"C:\temp\Comics\";//F:\Wolfpack\Comics     for desktop computer
          public String comics2add = "comics2add.txt";
          public String comicsList = "comics list.txt";

          public List<String> comicsToAdd;
          public List<String> comics;

          public static void Main(string[] args)
          {
               AddNewFolders anf = new AddNewFolders();
              
               List<String> directories = new List<String>(Directory.EnumerateDirectories(anf.directory));      
               anf.comicsToAdd = new List<String>(File.ReadAllLines(anf.directory + anf.comics2add));
               anf.comics = new List<String>(File.ReadAllLines(anf.directory + anf.comicsList));
               //First line checks the directory for a list of current folders.
               //The next 2 lines read the 2 text files and store them for later usage

               anf.mkDirs(directories);
               anf.repopComicsList();
          }

          private void mkDirs(List<String> directories)//Creates the directories that are missing.
          {
               for (int i = 0; i < comicsToAdd.Count; i++)
               {
                    if(!Directory.Exists(directory + comicsToAdd[i]))//Checks to see if it exists before creating
                    {
                         Console.WriteLine(comicsToAdd[i]);
                         Directory.CreateDirectory(directory + comicsToAdd[i]);
                    }
               }
          }

          private void repopComicsList()//Adds the new comics from the comics2add.txt file to the main list of comics.
          {
               for (int i = 0; i < comicsToAdd.Count; i++)
               {
                    if (!comics.Contains(comicsToAdd[i], StringComparer.OrdinalIgnoreCase))//Checks to see if the folder exists before moving on
                    {
                         comics.Add(comicsToAdd[i]);
                         Console.WriteLine(comicsToAdd[i] + "added to the comics list.");
                    }
               }

               comics.Sort();//Puts them into alphabetical order.

               updateAndResetNewComicsList();
          }

          private void updateAndResetNewComicsList()//Erases the contents of the comics2add.txt file.
          {
               File.Delete(directory + comicsList);
               File.WriteAllLines(directory + comicsList, comics);
               File.WriteAllText(directory + comics2add, String.Empty);
          }
     }
}
