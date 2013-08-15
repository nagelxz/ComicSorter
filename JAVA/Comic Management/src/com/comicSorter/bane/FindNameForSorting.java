package com.comicSorter.bane;

import java.io.*;
import java.nio.file.CopyOption;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.*;
import java.util.regex.Pattern;

public class FindNameForSorting
{
	public static void main(String[] args)
	{
		File folder = new File("F:\\Wolfpack\\Comics\\TO BE SORTED INTO RESPECTIVE FOLDERS");
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
			for(int i = 0 ; i < comics.size() ; i++)
			{
				boolean succ = false;
				
				if(f.getName().startsWith(comics.get(i)))
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
