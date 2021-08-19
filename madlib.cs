using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System;

public class MadLib
{
   public MadLib(string fileName)
   {
      mOriginal = File.ReadAllText(fileName);
      mLookup   = new Dictionary<string, string>();

      Regex           regex      = new Regex("<[a-zA-Z]+>");
      MatchCollection collection = regex.Matches(mOriginal);

      foreach(Match m in collection)
         mLookup[m.ToString()] = "";

      if(mLookup.Count == 0)
         throw new Exception("No <tags> found in: " + fileName);
   }

   public void ShowLookup()
   {
      foreach(var pair in mLookup)
         Console.WriteLine("'{0} -> '{1}'", pair.Key, pair.Value);
   }

   public void ShowOriginal()
   {
      Console.WriteLine(mOriginal);
   }

   public void Show()
   {
      string theString = mOriginal;

      foreach(var pair in mLookup)
         theString = theString.Replace(pair.Key, pair.Value);

      Console.WriteLine(theString);
   }

   private static string GetReplacement(string key)
   {
      string replacement = "";

      while(replacement == "")
      {
         Console.Write("Enter replacement for '" + key + "' ");
         replacement = Console.ReadLine().Trim();
      }

      return(replacement);
   }

   public void GetReplacements()
   {
      var tmp = new Dictionary<string, string>();

      foreach(var pair in mLookup)
         tmp[pair.Key] = GetReplacement(pair.Key);

      mLookup = tmp;
   }

   private string mOriginal;

   private Dictionary<string, string> mLookup =
      new Dictionary<string, string>();
}

public class Test
{
   public static void Main()
   {
      var m = new MadLib("mad.txt");

      for(;;)
      {
         m.GetReplacements();
         Console.WriteLine();

         m.Show();

         Console.WriteLine();
         Console.Write("Enter 'q' to quit: ");

         if(Console.ReadLine().ToLower().StartsWith("q"))
            break;
      }
   }
}
