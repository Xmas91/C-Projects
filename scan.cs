using System.IO;
using System;

public class Scan
{
   public static string FileNameToCategory(string fileName)
   {
      string name = Path.GetFileNameWithoutExtension(
         fileName.Replace("-", " ")
      );

      string result = "";

      for(int i = 0; i < name.Length; i ++)
      {
         char theChar = name[i];

         if(!char.IsWhiteSpace(theChar))
         {
            if(i == 0 || char.IsWhiteSpace(name[i - 1]))
               theChar = char.ToUpper(theChar);
         }

         result += theChar;
      }

      return(result);
   }

   public static void Main()
   {
      Console.WriteLine(FileNameToCategory("history-of-the-world.txt"));

      string dir = "c:\\temp";

      string[] files = Directory.GetFiles(dir, "*.txt");

      foreach(var file in files)
         Console.WriteLine("'{0}' => '{1}'", file, FileNameToCategory(file));
   }
}
