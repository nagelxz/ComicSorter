package com.comicSorter.bane;

import java.io.*;
import java.nio.file.*;
import java.util.regex.Pattern;

public class NameStripping
{
	public static void main(String[] args)
	{
		File folder = new File("F:\\Wolfpack\\Comics\\TO BE SORTED INTO RESPECTIVE FOLDERS");
		
		String[] original = folder.list(new FilenameFilter()
		{
			@Override
			public boolean accept(File current, String name)
			{
				return new File(current, name).isFile();
			}
		});
		
		String[] newname = new String[original.length];
		
		for(int i = 0 ; i < original.length ; i++)
		{
			newname[i] = original[i].replace('_', ' ');
		}
		
		for(int i = 0 ; i < original.length ; i++)
		{
			System.out.println(original[i]);
		}

		String waste_regex = ".*?(\\()(2)(0)(\\d)(\\d)(\\))";//takes the front of the file name up to the issue year
				//this ^ is basically skip
		
		for(int i = 0 ; i < newname.length ; i++)
		{
			Pattern waste = Pattern.compile(waste_regex);
			String[] result = waste.split(newname[i]);
			String fileExt = newname[i].substring(newname[i].length()-4);
			newname[i] = newname[i].replace(result[1], fileExt);
		}
		
		for(int i = 0 ; i < original.length ; i++)
		{
			try
			{
				System.out.println(newname[i]);
				Path old = Paths.get(folder.getPath() + "\\" + original[i]);
				Files.move(old, old.resolveSibling(folder.getPath()  + "//" + newname[i]));
			}
			catch(IOException e)
			{
				System.out.println(e);
			}
		}
	}
}