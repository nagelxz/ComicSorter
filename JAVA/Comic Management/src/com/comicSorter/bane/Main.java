package com.comicSorter.bane;

import java.io.*;
import java.util.*;

public class Main
{
	@SuppressWarnings("resource")
	public static void main(String[] args)
	{
		ComicSorter cs = new ComicSorter();
		Scanner s = new Scanner(System.in);
		
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
				cs.startingDir = loc1;
				break;
			case 2:
				//2 TO BE SORTED FOLDER
				cs.startingDir = loc2;
				break;
			case 3:
				//3 other manual input;
				s = new Scanner(System.in);
				System.out.println("Enter the location you would like to sort from:  ");
				loc3 = s.nextLine();
				cs.startingDir = loc3;
				break;
			default:
				System.out.println("Failed to comply to directions. Terminating life.");
				System.exit(0);
		}
		
		s.close();
		
		cs.folderRecursion(cs.startingDir);
		
		try
		{
			BufferedWriter out = new BufferedWriter(new FileWriter(new File("F:\\Wolfpack\\Comics\\failed files.txt")));
			
			for(int i = 0 ; i < cs.failed.size() ; i++)
			{
				out.write(cs.failed.get(i));
				out.write("\r\n");//change to \n if ever move to *nix based system
			}
			
			out.close();
		}
		catch(Exception e) {}
		
		
	}
}