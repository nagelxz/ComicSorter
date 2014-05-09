using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ComicSorter
{
     class ComicSorterFresh
     {
          List<FileObject> originalFiles = new List<FileObject>();
          List<FileObject> orphanedFiles = new List<FileObject>();

          public String startDir = "";

          public void Start()
          {
               folderRecursion(startDir);
               Console.WriteLine("Now that was fun");
               originalFiles = originalFiles.OrderBy(f => f.oFilename).ToList();
               nameStripping();
               Console.WriteLine("Now that was fun");
          }

          private void folderRecursion(String path)
          {
               List<String> directories = new List<String>(Directory.EnumerateDirectories(path).Select(d => new DirectoryInfo(d).Name));

               Int32 dirContentCount = Directory.GetFiles(path).Length;

               if ((dirContentCount != 0 && directories.Count != 0) || directories.Count == 0)
               {
                    List<Object> temp = new List<Object>(Directory.EnumerateFiles(path).Select(f => Path.GetFileName(f)));

                    foreach (String file in temp)
                    {
                         originalFiles.Add(new FileObject { oFilename = file, fileLocation = path });
                    }
               }

               //if (directories.Count == 0)//might be ble to merge this with the other if statement. LOOK AT LATER!!!
               //{
               //     List<Object> temp = new List<Object>(Directory.EnumerateFiles(path).Select(f => Path.GetFileName(f)));

               //     foreach (String file in temp)
               //     {
                         
               //     }
               //}
               else
               {
                    foreach (String folder in directories)
                    {
                         folderRecursion(path + folder + "\\");
                    }
               }
          }

          private void nameStripping()
          {
               List<String> goodExt = new List<String>(){ "cb7", "cbr", "cbt", "cbz", "pdf" };
               
               originalFiles.RemoveAll(e => !goodExt.Contains(e.oFilename.Substring(e.oFilename.Length - 3)));

               foreach (FileObject file in originalFiles)
               {
                    file.nFilename = file.oFilename.Replace('_', ' ');

                    String wasteRegex = ".*?(\\()(2)(0)(\\d)(\\d)(\\))";//takes the front of the file name up to the issue year
                    //this ^ is basically skip

                    Regex rgx = new Regex(wasteRegex);
                    String result = String.Join("", rgx.Split(file.nFilename));
                    String fileExt = file.nFilename.Substring(file.nFilename.Length - 4);//Once the initial rewrite is finished change so that the list of filenames are checked before worked on so that they get removed prior to finding out they have the wron extension
                    file.nFilename = file.nFilename.Replace(" " + result, fileExt);//Dont thing this is going to work the same as in Java. While at Newark work test against static string to get this to work before moving testing against any files.

                    try//see if i could cut out this move now that i have the new name connected to the old name... will probably make it faster, haha Oh notation hope you see this one day mike.
                    {
                         File.Move(file.fileLocation + file.oFilename, file.fileLocation + file.nFilename)
                    }
                    catch (FileNotFoundException e)
                    {
                         Console.WriteLine(e.ToString());
                    }
               }

          }
     }

     class FileObject
     {
          public String oFilename;
          public String nFilename;
          public String fileLocation;
     }
}
