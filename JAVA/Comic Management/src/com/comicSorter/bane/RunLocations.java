package com.comicSorter.bane;

import java.io.*;
import java.util.*;

public class RunLocations
{
	public static void main(String[] args)
	{
		Scanner s = new Scanner(System.in);
		File location = null;
		
		String[] directories = new String[0];
		String[] files = new String[0];
		
		String loc1 = "F:\\Downloads\\uTorrentPortable\\Data\\downloads\\comics";
		String loc2 = "F:\\Wolfpack\\Comics\\TO BE SORTED INTO RESPECTIVE FOLDERS";
		String loc3 = "";
		
		System.out.println("Where do you want to sort from?  Enter your choice:  ");
		System.out.println("1 \t Downloads folder\n2 \t TO BE SORTED folder\n3 \t Other - manual input location\n");
		
		int input = s.nextInt();
		
		switch(input)
		{
			case 1:
				//1 downloads folder
				location = new File(loc1);
				break;
			case 2:
				//2 TO BE SORTED FOLDER
				location = new File(loc2);
				break;
			case 3:
				//3 other manual input;
				s = new Scanner(System.in);
				System.out.println("Enter the location you would like to sort from:  ");
				loc3 = s.nextLine();
				location = new File(loc3);
				break;
			default:
				System.out.println("Failed to comply to directions. Terminating life.");
				System.exit(0);
		}
		
		s.close();
		
		try
		{
			directories = location.list(new FilenameFilter()
			{
				@Override
				public boolean accept(File current, String name)
				{
					return new File(current, name).isDirectory();
				}
			});
			
			files = location.list(new FilenameFilter()
			{
				@Override
				public boolean accept(File current, String name)
				{
					return new File(current, name).isFile();
				}
			});
		}
		catch(Exception e){}
		
		for(int i = 0 ; i < directories.length ; i++)
		{
			System.out.println(directories[i]);
		}
		
		System.out.println();
		
		for(int i = 0 ; i < files.length ; i++)
		{
			System.out.println(files[i]);
		}
	}
}