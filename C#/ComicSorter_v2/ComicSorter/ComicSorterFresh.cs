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
               FolderRecursion(startDir);
               Console.WriteLine("Now that was fun");
               originalFiles = originalFiles.OrderBy(f => f.oFilename).ToList();
               NameStripping();
               Console.WriteLine("Now that was fun");
               Sorting();
          }

          private void FolderRecursion(String path)
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
               else
               {
                    foreach (String folder in directories)
                    {
                         FolderRecursion(path + folder + "\\");
                    }
               }
          }

          private void NameStripping()
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
                         File.Move(file.fileLocation + file.oFilename, file.fileLocation + file.nFilename);
                    }
                    catch (FileNotFoundException e)
                    {
                         Console.WriteLine(e.ToString());
                    }
               }

          }

          private void Sorting()
          {
               String finalDestination = @"C:\temp\Comics\";
               List<String> comics = new List<String>(Directory.EnumerateDirectories(finalDestination).Select(d => new DirectoryInfo(d).Name));

               foreach (FileObject file in originalFiles)
               {
                    Regex rgx = new Regex(".*?(\\s)(\\d)");
                    String result = String.Join("", rgx.Split(file.nFilename));

                    String comicName = file.nFilename.Substring(0, file.nFilename.Length - result.Length);

                    if (comics.Contains(comicName))
                    {
                         Boolean succ = false;

                         try
                         {
                              File.Copy(file.fileLocation + file.nFilename, finalDestination + comicName + "\\" + file.nFilename, true);
                              succ = true;
                         }
                         catch (Exception e)
                         {
                              Console.WriteLine(e.ToString());
                              orphanedFiles.Add(new FileObject { oFilename = file.nFilename, fileLocation = file.fileLocation });
                         }

                         if (succ)
                         {
                              Console.WriteLine("File:  " + (file.fileLocation + file.oFilename) + " successfully moved.");
                              File.Delete(file.fileLocation + file.nFilename);
                         }
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
