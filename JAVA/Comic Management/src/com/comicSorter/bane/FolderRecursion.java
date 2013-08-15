package com.comicSorter.bane;

import java.io.*;

public class FolderRecursion
{
	public void walk(String path)
	{
		File root = new File(path);
		
		String[] directories = root.list(new FilenameFilter()
		{
			@Override
			public boolean accept(File current, String name)
			{
				return new File(current, name).isDirectory();
			}
		});
		
		if(directories.length == 0)
		{
			String[] files = root.list(new FilenameFilter()
			{
				@Override
				public boolean accept(File current, String name)
				{
					return new File(current, name).isFile();
				}
			});
			
			for(String f : files)
			{
				System.out.println(f);
			}
		}
		else
		{
			for(String folder : directories)
			{
				walk(path + "\\" + folder);
				System.out.println(folder);
			}
		}
    }

    public static void main(String[] args)
    {
	   FolderRecursion fw = new FolderRecursion();
        fw.walk("F:\\Wolfpack\\Comics\\TO BE SORTED INTO RESPECTIVE FOLDERS");
    }
}