using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

          }
     }
}
