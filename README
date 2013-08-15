This is just one of my many side projects that I have started.  I recently got into reading comics and had a bit of an issue. I would have dozens upon dozens of comics sitting in the download folder. Sure I use Comicrack to keep them "organized" but it didn’t help the behind the scenes.

So I decided to write a program to create the folder structure, strip the names of useless characters, and sort them into folders based on their Comic's name.

Version 1.
It's a 2 program setup, and very clumsy I might add. It does the job but it has a high failure rate.
Written in Java. First program creates and updates a folder structure off of a text file named comics2add.txt, create the folders and add the list of names to a master text file comic list.txt. The second program is what did the heavy lifting. Via CLI I could choose directory to pull the new files from or enter in a directory manually. It would recursively look through the directory to pull the names of files to be stripped by regex and renamed. The files would then be moved from the directory into the folder structure and delete the original.
It’s in the second program where the issue lives. It would find most files and strip them fine, only some would fail, but the biggest issue was the moving of the files. Their ending folder would exist but it would say it failed, but would still delete the file in the originating directory. I had it doing a copy not a move, but the options array was causing issues with that for some reason.

For more granular control of file and folder manipulation, I'm moving the rest of my development of this project to C#. Due to me using Windows mostly I have no issues not using a multi-platform language for this. I will be leaving the original java code up if anyone wants to fix the issues or mold it for their own usage.

Version 2.
Written in C#.
For the start of re-write, it is going to be an exact mirror of the Java code in terms of functionality, same command-line features, same functions, same almost everything. The biggest difference being it's only going to be one program. There's going to be a minor interface to handle the choosing to do the folder structure or do the sorting.


After I get that done and working to my idea of "perfect" (nothing is ever perfect in the eye of a programmer, everything can always be improved in some way),  I'm going to move on from using text files or csv files to a compact SQL database, most likely the built-in one Microsoft offers. Next then is a more usable GUI interface and turning the CLI version into an auto run version possibly. Prompts for auto-add comics to the structure, log printouts, and the possibility of adding it to comicrack (last possible tackling of the final code - v3.0, at that point dropping the compact DB and just moving forward with the creation of the structure where comicrack auto updates its database from.)

CHANGELOG:

v1.0:  Original program.
