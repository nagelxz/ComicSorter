package com.comicSorter.bane;

import java.io.*;
import java.nio.file.*;
import java.util.*;
import java.util.regex.Pattern;

public class ComicSorter
{
	private String[] directories;
	private String[] originalFiles;
	
	public String startingDir="";
	
	public ArrayList<String> failed = new ArrayList<String>();
	
	public ComicSorter() {}
	
	public void folderRecursion(String path)
	{		
		File root = new File(path);
		
		directories = root.list(new FilenameFilter()
		{
			@Override
			public boolean accept(File current, String name)
			{
				return new File(current, name).isDirectory();
			}
		});
		
		originalFiles = root.list(new FilenameFilter()
		{
			@Override
			public boolean accept(File current, String name)
			{
				return new File(current, name).isFile();
			}
		});
		
		nameStripping(startingDir);
		
		if(directories.length == 0)
		{
			originalFiles = root.list(new FilenameFilter()
			{
				@Override
				public boolean accept(File current, String name)
				{
					return new File(current, name).isFile();
				}
			});
			
			nameStripping(path);
		}
		else
			for(String folder : directories)
				folderRecursion(path + "\\" + folder);
	}
	
	private void nameStripping(String path)
	{
		File folder = new File(path);
		
		String[] newname = new String[originalFiles.length];
		
		for(int i = 0 ; i < originalFiles.length ; i++)
			newname[i] = originalFiles[i].replace('_', ' ');

		String waste_regex = ".*?(\\()(2)(0)(\\d)(\\d)(\\))";//takes the front of the file name up to the issue year
				//this ^ is basically skip
		
		for(int i = 0 ; i < newname.length ; i++)
		{
			Pattern waste = Pattern.compile(waste_regex);
			String[] result = waste.split(newname[i]);
			String fileExt = newname[i].substring(newname[i].length()-4);
			newname[i] = newname[i].replace(result[1], fileExt);
		}
		
		for(int i = 0 ; i < newname.length ; i++)
			try
			{
				Path old = Paths.get(folder.getPath() + "\\" + originalFiles[i]);
				Files.move(old, old.resolveSibling(folder.getPath()  + "//" + newname[i]));
			}
			catch(IOException e)
			{
				System.out.println(e);
			}
		
		sort(path);
	}
	
	private void sort(String path)
	{
		File folder = new File(path);
		File comicsList = new File("F:\\Wolfpack\\Comics\\comics list.txt");
		
		String finalDestination = "F:\\Wolfpack\\Comics\\";
		
		ArrayList<String> comics = new ArrayList<String>();
		
		try
		{
			Scanner s = new Scanner(comicsList);
			
			while(s.hasNext())
				comics.add(s.nextLine());
			
			s.close();
		}
		catch(FileNotFoundException e){}
		
		File[] files = folder.listFiles(new FilenameFilter()
		{
			@Override
			public boolean accept(File current, String name)
			{
				return new File(current, name).isFile();
			}
		});
		
		for(File f : files)
		{
			Pattern filler = Pattern.compile(".*?(\\s)(\\d)");
			String result = filler.split(f.getName())[1];
			int excess = result.length()+2;
			String comicName = f.getName().substring(0, (f.getName().length()-excess));
			
			for(int i = 0 ; i < comics.size() ; i++)
			{
				boolean succ = false;

				if(comicName.equals(comics.get(i)))
				{
					try
					{
						Path FROM = Paths.get(f.getPath());
						Path TO = Paths.get(finalDestination + comics.get(i) + "\\" + f.getName());
						//overwrite existing file, if exists
						CopyOption[] options = new CopyOption[]{StandardCopyOption.REPLACE_EXISTING, StandardCopyOption.COPY_ATTRIBUTES}; 
						Files.copy(FROM, TO, options);
						succ = true;
					}
					catch(Exception e)
					{
						e.printStackTrace();
						failed.add(f.getPath());
					}
					
					if(succ)
					{
						f.delete();
						break;
					}
				}
			}
		}
	}
}