using System.Collections.Generic;
using System;

public class Color
{
   public Color(int red, int green, int blue)
   {
      Red   = red;
      Green = green;
      Blue  = blue;
   }

   public int Red   { get; private set; }
   public int Green { get; private set; }
   public int Blue  { get; private set; }
}

public class Dict
{
   public static void ExampleZero()
   {
      Dictionary<string, string> theMap =
         new Dictionary<string, string>();

      theMap["Superman"]      = "Clark Kent";
      theMap["Batman"]        = "Bruce Wayne";
      theMap["The Hulk"]      = "Bruce Banner";
      theMap["Spiderman"]     = "Peter Parker";
      theMap["The Flash"]     = "Barry Allen";
      theMap["Green Lantern"] = "Hal Jordan";

      string[] heros = { "The Flash", "Superman", "Spiderman" };

      foreach(string hero in heros)
      {
         Console.WriteLine(
            "{0}'s secret identity is: {1}",
            hero, theMap[hero]
         );
      }

      Console.WriteLine();

      // Now, walk through the entire Dictionary

      foreach(var pair in theMap)
         Console.WriteLine("{0} is {1}", pair.Value, pair.Key);

      Console.WriteLine();
   }

   private static void DoEntries(
      int value,
      string romanValue,
      Dictionary<int, string> toRoman,
      Dictionary<string, int> fromRoman
   )
   {
      toRoman[value]        = romanValue;
      fromRoman[romanValue] = value;
   }

   public static void ExampleOne()
   {
      var toRoman   = new Dictionary<int, string>();
      var fromRoman = new Dictionary<string, int>();

      DoEntries(0, "0",    toRoman, fromRoman);
      DoEntries(1, "i",    toRoman, fromRoman);
      DoEntries(2, "ii",   toRoman, fromRoman);
      DoEntries(3, "iii",  toRoman, fromRoman);
      DoEntries(4, "iv",   toRoman, fromRoman);
      DoEntries(5, "v",    toRoman, fromRoman);
      DoEntries(6, "vi",   toRoman, fromRoman);
      DoEntries(7, "vii",  toRoman, fromRoman);
      DoEntries(8, "viii", toRoman, fromRoman);
      DoEntries(9, "ix",   toRoman, fromRoman);

      Console.WriteLine(
         "{0} - {1} = {2}",
         toRoman[9], toRoman[5], toRoman[4]
      );

      Console.WriteLine(
         "{0}{1}{2}{3}{4}{5}{6}",
         fromRoman["viii"],
         fromRoman["vi"],
         fromRoman["vii"],
         fromRoman["v"],
         fromRoman["iii"],
         fromRoman["0"],
         fromRoman["ix"]
      );

      Console.WriteLine();
   }

   private static Dictionary<char, int> GetVowelCounts(string s)
   {
      Dictionary<char, int> charToCount = new Dictionary<char, int>();

      foreach(char c in s)
      {
         char cLower = char.ToLower(c);

         if(cLower == 'a' || cLower == 'e' || cLower == 'i' ||
            cLower == 'o' || cLower == 'u')
         {
            if(!charToCount.ContainsKey(cLower))
               charToCount[cLower] = 0;

            charToCount[cLower]++;
         }
      }

      return(charToCount);
   }

   private static void DoGetVowelCounts(string s)
   {
      Dictionary<char, int> counts = GetVowelCounts(s);

      Console.WriteLine("\"{0}\"", s);

      foreach(KeyValuePair<char, int> p in counts)
         Console.WriteLine("   '{0}': {1}", p.Key, p.Value);

      Console.WriteLine();
   }

   public static void ExampleTwo()
   {
      DoGetVowelCounts("yo ho ho and a bottle of rum");
      DoGetVowelCounts("aeeiiioooouuuuu");
      DoGetVowelCounts("DoGetVowelCounts");
   }

   public static void ExampleThree()
   {
      var theDictionary = new Dictionary<string, Color>();

      theDictionary["red"]     = new Color(255,   0,   0);
      theDictionary["green"]   = new Color(0,   255,   0);
      theDictionary["blue"]    = new Color(0,     0, 255);
      theDictionary["black"]   = new Color(  0,   0,   0);
      theDictionary["cyan"]    = new Color(  0, 255, 255);
      theDictionary["magenta"] = new Color(255,   0, 255);
      theDictionary["yellow"]  = new Color(255, 255,   0);
      theDictionary["white"]   = new Color(255, 255, 255);

      Console.WriteLine("What color should I look up?");

      string response = Console.ReadLine();

      response = response.Trim().ToLower();

      if(!theDictionary.ContainsKey(response))
      {
          Console.WriteLine("Could not find color: " + response);
      }
      else
      {
         Color theColor = theDictionary[response];

         Console.WriteLine(
            theColor.Red + " " + theColor.Green + " " + theColor.Blue
         );
      }
   }

   public static void Main()
   {
      ExampleZero();
      ExampleOne();
      ExampleTwo();
      ExampleThree();

      Console.ReadLine();
   }
}
