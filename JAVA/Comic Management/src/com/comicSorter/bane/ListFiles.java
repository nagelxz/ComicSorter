package com.comicSorter.bane;

import java.io.*;
import java.nio.file.attribute.BasicFileAttributes;
import java.nio.file.*;

public class ListFiles extends SimpleFileVisitor<Path>
{
	private final int indentionAmount = 6;
	private int indentionLevel;

	public ListFiles()
	{
		indentionLevel = 0;
	}

	private void indent()
	{
		for (int i = 0; i < indentionLevel; i++)
		{
			System.out.print("   ");
		}
	}

	@Override
	public FileVisitResult visitFile(Path file, BasicFileAttributes attributes)
	{
		indent();
		System.out.println(file.getFileName());
		
		return FileVisitResult.CONTINUE;
	}
	
	@Override
	public FileVisitResult postVisitDirectory(Path directory, IOException e) throws IOException
	{
		indentionLevel -= indentionAmount;
		indent();
		System.out.println("Finished " + directory.getFileName());

		return FileVisitResult.CONTINUE;
	}
	
	@Override
	public FileVisitResult preVisitDirectory(Path directory, BasicFileAttributes attributes) throws IOException
	{
		indent();
		System.out.println("Directory: " + directory.getFileName());
		indentionLevel += indentionAmount;
		
		return FileVisitResult.CONTINUE;
	}
	
	@Override
	public FileVisitResult visitFileFailed(Path file, IOException exc) throws IOException
	{
		System.out.println("A file traversal error ocurred");

		return super.visitFileFailed(file, exc);
	}

	public static void main(String[] args)
	{
		try
		{
			//Path path = Paths.get("F:\\Downloads\\uTorrentPortable\\Data\\downloads\\comics");
			Path path = Paths.get("F:\\Wolfpack\\Comics\\TO BE SORTED INTO RESPECTIVE FOLDERS");
			ListFiles listFiles = new ListFiles();
			Files.walkFileTree(path, listFiles);
		}
		catch (IOException ex)
		{
			ex.printStackTrace();
		}
	}
}