using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ComicSorter_v2
{
     public class AddNewFolders
     {
          public String directory = @"F:\Wolfpack\Comics\";
          public String comics2add = "comics2add.txt";
          public String comicsList = "comics list.txt";

          public List<String> comicsToAdd;
          public List<String> comics;

          public static void Main(string[] args)
          {
               AddNewFolders anf = new AddNewFolders();
              
               List<String> directories = new List<String>(Directory.EnumerateDirectories(anf.directory));      
               anf.comicsToAdd = new List<String>(File.ReadAllLines(anf.directory + anf.comics2add));
               anf.comics = new List<String>(File.ReadAllLines(anf.directory + anf.comics));
          }

          private void mkDirs(String[] directories)
          {
               for (int i = 0; i < comicsToAdd.Count; i++)
               {
                    if(!Directory.Exists(directory + comicsToAdd[i]))
                    {
                         Console.WriteLine(comicsToAdd[i]);
                         Directory.CreateDirectory(directory + comicsToAdd[i]);
                    }
               }
          }

          private void repopComicsList()
          {
               for (int i = 0; i < comicsToAdd.Count; i++)
               {
                    if (!comics.Contains(comicsToAdd[i], StringComparer.OrdinalIgnoreCase))
                    {
                         comics.Add(comicsToAdd[i]);
                         Console.WriteLine(comicsToAdd[i] + "added to the comics list.");
                         comics.Sort();
                    }
               }
          }

          private void updateComicsList()
          {

          }

          private void resetNewComicsList()//might be able to merge this with updateComicsList
          {

          }
     }
}
