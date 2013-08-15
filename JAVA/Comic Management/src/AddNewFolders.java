import java.io.*;
import java.util.*;

public class AddNewFolders
{
	public File directory;
	public File comics2add;
	public File comicsList;
	
	public ArrayList<String> comicstoadd;
	public ArrayList<String> comics;
	
	public static void main(String[] args)
	{
		AddNewFolders anf = new AddNewFolders();
		
		anf.directory = new File("F:\\Wolfpack\\Comics");//for when at home
		anf.comics2add = new File(anf.directory, "comics2add.txt");
		anf.comicsList = new File(anf.directory, "comics list.txt");
				
		anf.comicstoadd = new ArrayList<>();
		anf.comics = new ArrayList<>();

		String[] directories = anf.directory.list(new FilenameFilter()
		{
			@Override
			public boolean accept(File current, String name)
			{
				return new File(current, name).isDirectory();
			}
		});
	
		anf.popNewComicsList();
		anf.popComicsList();
		anf.makedirs(directories);
		anf.repopComicsList();
		anf.resetNewComicsList();
		
		System.out.println("DONE");
	}

	private void popNewComicsList()
	{
		try
		{
			Scanner s = new Scanner(comics2add);
			
			while(s.hasNext())
				comicstoadd.add(s.nextLine());
			
			s.close();
		}
		catch(FileNotFoundException e){}	
	}
	
	private void popComicsList()
	{
		try
		{
			Scanner s = new Scanner(comicsList);
			
			while(s.hasNext())
				comics.add(s.nextLine());
			
			s.close();
		}
		catch(FileNotFoundException e){}
	}
	
	private void makedirs(String[] directories)
	{
		for(int i = 0 ; i < comicstoadd.size() ; i++)
		{
			boolean exists = false;
			
			for(int j = 0 ; j < directories.length ; j++)
				if(directories[j].equalsIgnoreCase(comicstoadd.get(i)))
				{
					exists = true;
					break;
				}
			
			if(!exists)
			{
				System.out.println(comicstoadd.get(i));
				File newdir = new File(directory, comicstoadd.get(i));
				newdir.mkdir();
			}
		}
	}
	
	private void repopComicsList()
	{
		for(int i = 0 ; i < comicstoadd.size() ; i++)
		{
			boolean exists = false;
			
			for(int j = 0 ; j < comics.size() ; j++)
				if(comics.get(j).equalsIgnoreCase(comicstoadd.get(i)))
				{
					exists = true;
					break;
				}
			
			if(!exists)
			{
				comics.add(comicstoadd.get(i));
				System.out.println(comicstoadd.get(i) + " added to comics list.");
				Collections.sort(comics);
			}
		}
		
		updateComicList();
	}
	
	private void updateComicList()
	{
		comicsList.delete();
		
		try
		{
			BufferedWriter out = new BufferedWriter(new FileWriter(comicsList));
			
			for(int i = 0; i < comics.size(); i++)
			{
				out.write(comics.get(i));
				out.write("\r\n");//change to \n if ever move to *nix based system
			}
			
			out.close();
		}
		catch (IOException e) {}
	}
	
	private void resetNewComicsList()
	{
		comics2add.delete();
		
		try
		{
			BufferedWriter out = new BufferedWriter(new FileWriter(comics2add));
			
			out.close();
		}
		catch (IOException e) {}
	}
}