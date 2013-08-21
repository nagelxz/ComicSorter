using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ComicSorter
{
     class ComicSorter
     {
          private List<String> directories;
          private List<String> originalFiles;

          public String startingDir = "";

          public List<String> failed = new List<String>();

          public void folderRecursion(String path)
          {
               directories = new List<String>(Directory.EnumerateDirectories(path));

               originalFiles = new List<String>(Directory.EnumerateFiles(path));

               nameStripping(startingDir);

               if (directories.Count == 0)
               {
                    originalFiles = new List<String>(Directory.EnumerateFiles(path));

                    nameStripping(path);
               }
               else
               {
                    foreach(String folder in directories)
                    {
                         folderRecursion(path + "\\" + folder);
                    }
               }
          }

          private void nameStripping(String path)
          {
               List<String> newName = new List<String>();

               for (int i = 0; i < originalFiles.Count;  )
               {
                    newName[i] = originalFiles[i].Replace('_', ' ');
               }

               String wasteRegex = ".*?(\\()(2)(0)(\\d)(\\d)(\\))";//takes the front of the file name up to the issue year
                               //this ^ is basically skip

               for (int i = 0; i < newName.Count; i++)
               {
                    Regex rgx = new Regex(wasteRegex);
                    String[] result = rgx.Split(newName[i]);
                    String fileExt = newName[i].Substring(newName.Count - 4);//Once the initial rewrite is finished change so that the list of filenames are checked before worked on so that they get removed prior to finding out they have the wron extension
                    newName[i] = newName[i].Replace(result[1], fileExt);//Dont thing this is going to work the same as in Java. While at Newark work test against static string to get this to work before moving testing against any files.
               }

               for (int i = 0; i < newName.Count; i++)
               {
                    //Look into renaming a file in C#, running out of time on the train. Mabe could get lucky and have time to work on it in NYC.
               }

               sort(path);
          }

          private void sort(String Path)//Same thing goes for here, i need to look more indepth into how C# handles folder/file manipulation for compying, moving, renaming, deleting before I can go any further. Pulling into Secacus doesn't give me much of that time.
          {

          }
     }
}
