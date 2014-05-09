     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.IO;
     using System.Text.RegularExpressions;

     namespace ComicSorter
     {
     //class ComicSorterFresh
     //{
     //     private SortedDictionary<String,String> originalFiles = new SortedDictionary<String,String>();
     //     private SortedDictionary<String,String> orphanedFiles = new SortedDictionary<String,String>();

     //     public String startDir = "";

     //     public void Start()
     //     {
     //          folderRecursion(startDir);
     //          Console.WriteLine("Now that was fun");
     //          nameStripping();
     //     }

     //     private void folderRecursion(String path)
     //     {
     //          List<String> directories = new List<String>(Directory.EnumerateDirectories(path).Select(d => new DirectoryInfo(d).Name));

     //          Int32 dirContentCount = Directory.GetFiles(path).Length;

     //          if (dirContentCount != 0 && directories.Count != 0)
     //          {
     //               List<Object> temp = new List<Object>(Directory.EnumerateFiles(path).Select(f => Path.GetFileName(f)));

     //               foreach(String file in temp)
     //               {
     //                    originalFiles.Add(file, path);
     //               }
     //          }

     //          if (directories.Count == 0)//might be ble to merge this with the other if statement. LOOK AT LATER!!!
     //          {
     //               List<Object> temp = new List<Object>(Directory.EnumerateFiles(path).Select(f => Path.GetFileName(f)));

     //               foreach (String file in temp)
     //               {
     //                    originalFiles.Add(file, path);
     //               }
     //          }
     //          else
     //          {
     //               foreach (String folder in directories)
     //               {
     //                    folderRecursion(path + folder + "\\");
     //               }
     //          }
     //     }

     //     private void nameStripping()
     //     {
     //          String[] goodExt = {"cb7", "cbr", "cbt", "cbz", "pdf"};
     //          List<String> junk = new List<String>();
          
     //          foreach(KeyValuePair<String, String> file in originalFiles)
     //          {
     //               Int32 found = 0;
     //               foreach(String ext in goodExt)
     //               {
     //                    if(!String.Equals(file.Key.Substring(file.Key.Length - 3),ext,StringComparison.Ordinal))
     //                    {
     //                         found++;
     //                    }
     //               }

     //               if (found == goodExt.Length)
     //               {
     //                    junk.Add(file.Key);
     //               }
                    
     //          }

     //          foreach (String item in junk)
     //          {
     //               originalFiles.Remove(item);
     //          }

     //     }
     //}

     class ComicSorterFresh
     {
          List<FileObject> originalFiles = new List<FileObject>();
          List<FileObject> orphanedFiles = new List<FileObject>();

          public String startDir = "";

          public void Start()
          {
               folderRecursion(startDir);
               Console.WriteLine("Now that was fun");
               originalFiles = originalFiles.OrderBy(f => f.filename).ToList();
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
                         originalFiles.Add(new FileObject { filename = file, fileLocation = path });
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
               
               originalFiles.RemoveAll(e => !goodExt.Contains(e.filename.Substring(e.filename.Length - 3)));

                             

          }
     }

     class FileObject
     {
          public String filename;
          public String fileLocation;
     }
     }
