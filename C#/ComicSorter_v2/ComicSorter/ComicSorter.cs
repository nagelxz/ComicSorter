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
               directories = new List<String>(Directory.EnumerateDirectories(path).Select(d => new DirectoryInfo(d).Name));

               originalFiles = new List<String>(Directory.EnumerateFiles(path).Select(f => Path.GetFileName(f)));
               //create another function to see if the ending is not of the comic variety
               //if not, remove from the list
               //not a major rush until i get it working for the files that do fit the profile

               nameStripping(startingDir);

               if (directories.Count == 0)
               {
                    originalFiles = new List<String>(Directory.EnumerateFiles(path).Select(f => Path.GetFileName(f)));
                    //create another function to see if the ending is not of the comic variety
                    //if not, remove from the list
                    //not a major rush until i get it working for the files that do fit the profile
                    nameStripping(path);
               }
               else
               {
                    foreach(String folder in directories)
                    {
                         folderRecursion(path + folder + "\\");
                    }
               }
          }

          private void nameStripping(String path)
          {
               List<String> newName = new List<String>(originalFiles);

               for (int i = 0; i < newName.Count; i++)
               {
                    newName[i] = newName[i].Replace('_', ' ');
               }

               String wasteRegex = ".*?(\\()(2)(0)(\\d)(\\d)(\\))";//takes the front of the file name up to the issue year
                               //this ^ is basically skip

               for (int i = 0; i < newName.Count; i++)
               {
                    Regex rgx = new Regex(wasteRegex);
                    String result =String.Join("", rgx.Split(newName[i]));
                    String fileExt = newName[i].Substring(newName[i].Length - 4);//Once the initial rewrite is finished change so that the list of filenames are checked before worked on so that they get removed prior to finding out they have the wron extension
                    newName[i] = newName[i].Replace(" " + result, fileExt);//Dont thing this is going to work the same as in Java. While at Newark work test against static string to get this to work before moving testing against any files.
               }

               for (int i = 0; i < newName.Count; i++)
               {
                    File.Move(path + originalFiles[i], path + newName[i]);//might be able to move int above for loop, look into it same time of rejecting extensions.
               }
               
               sort(path);

               //clear original files and newName before going onto the next folder for safety
               //ony bother if the carry over continues to happen
          }

          private void sort(String Path)//Same thing goes for here, i need to look more indepth into how C# handles folder/file manipulation for compying, moving, renaming, deleting before I can go any further. Pulling into Secacus doesn't give me much of that time.
          {

          }
     }
}
