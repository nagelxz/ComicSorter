import java.io.File;
import java.io.FileNotFoundException;
import java.io.FilenameFilter;
import java.nio.file.CopyOption;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Pattern;


public class test
{
	public static void main(String[] args)
	{
		String[] input = {"Avengers 001 (2013).cbr", "Avengers Assemble 001 (2013).cbr", "Avengers Arena 001 (2013).cbr", "Wolverine 002 (2012).cbr", "Wolverine and the X-Men 002 (2012).cbr"};
		String[] comics = {"Avengers","Avengers Assemble","Avengers Arena","Wolverine","Wolverine and the X-Men"};
		
		for(String f : input)
		{
			Pattern waste = Pattern.compile(".*?(\\s)(\\d)");
			String result = waste.split(f)[1];
			String comicName = f.substring(0, (f.length()-(result.length()+2)));
			
			for(String c : comics)
			{
				//if(f.regionMatches(0, c, 0, (f.length()-(result[1].length()+2))))
				if(comicName.equals(c))
				{
					int a= 0;
					break;
				}
				else
				{
					int b = 0;
				}
			}
		}
		
		//String nonsense_regex = ".*?(\\s)(\\d)";//takes the front of the file name up to the issue year
		//this ^ is basically skip

		for(String f : input)
		{
			String nonsense_regex = ".*?(\\s)(\\d)";
			Pattern waste = Pattern.compile(nonsense_regex);
			String[] result = waste.split(f);
			int a = 0;
		}
		
//		ArrayList<String> comics = new ArrayList<String>();
//		
//		try
//		{
//			Scanner s = new Scanner(comicsList);
//			
//			while(s.hasNext())
//				comics.add(s.nextLine());
//			
//			s.close();
//		}
//		catch(FileNotFoundException e){}
//		
//		File[] files = folder.listFiles(new FilenameFilter()
//		{
//			@Override
//			public boolean accept(File current, String name)
//			{
//				return new File(current, name).isFile();
//			}
//		});
//		
//		for(File f : files)
//			for(int i = 0 ; i < comics.size() ; i++)
//			{
//				boolean succ = false;
//				
//				if(f.getName().startsWith(comics.get(i)))
//				{
//					try
//					{
//						Path FROM = Paths.get(f.getPath());
//						Path TO = Paths.get(finalDestination + comics.get(i) + "\\" + f.getName());
//						//overwrite existing file, if exists
//						CopyOption[] options = new CopyOption[]{StandardCopyOption.REPLACE_EXISTING, StandardCopyOption.COPY_ATTRIBUTES}; 
//						Files.copy(FROM, TO, options);
//						succ = true;
//					}
//					catch(Exception e)
//					{
//						e.printStackTrace();
//						failed.add(f.getPath());
//					}
//					
//					if(succ)
//					{
//						f.delete();
//						break;
//					}
//				}
//			}
//		}
	}
}
