using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Testing;


namespace ConsoleApp1
{
  public  class MainApp
    {
        static void Main(string[] args)
        {
            int i = 1;


            while (i == 1)
            {
                Console.WriteLine("Please type in a sentence"); //Input
                String line = Console.ReadLine(); //Assign
                if (String.IsNullOrEmpty(line))
                {
                    Console.WriteLine("Please Try Again"); //if nothing is put in
                    continue;
                }
                else
                {

                    char[] charSeparators = new char[] {' '};
                    string[] lineSep = line.Split(charSeparators, 100, StringSplitOptions.RemoveEmptyEntries);
                    var lineSepProc = lineSep.Select(s => s.ToLowerInvariant()).ToArray();


                    Dictionary<string, int> dic = new Dictionary<string, int>();

                    dic = MkCount(lineSepProc, dic);

                    var listOfHighest = MkSort(dic, "desc", " ");

                    Console.WriteLine(listOfHighest);
                    Console.WriteLine("Highest Frequency: " + listOfHighest.First());
                }

                i = 3;
                while (i == 3)
                {
                    Console.WriteLine("Would you like to split another sentence? Y/N");
                    string answer = Console.ReadLine();
                    if (answer.ToUpper() == "Y")
                    {
                        i = 1;
                    }
                    else if (answer.ToUpper() == "N")
                    {
                        i = 0;
                    }
                    else
                    {
                        i = 3;
                    }
                }
            }
        }
        static Dictionary<string, int> MkCount(string[] arr, Dictionary<string, int> dic)
        {
            foreach (var item in arr)
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 1);
                }
                else
                {
                    dic[item]++;
                }
            }
            return dic;
        }

        static string MkSort(Dictionary<string, int> dic, string sortOrder, string separator)
        {
            var sortAlpha = (from entry in dic orderby entry.Key ascending select entry);
            StringBuilder sb = new StringBuilder();
            if (sortOrder == "desc")
            {
                var sort = (from entry in sortAlpha orderby entry.Value descending select entry).ToList();
                foreach (KeyValuePair<string, int> pair in sort)
                {
                    sb.AppendLine(string.Format("{0}" + separator + "{1}", pair.Value, pair.Key));
                }
            }
            else if (sortOrder == "asc")
            {
                var sort = (from entry in sortAlpha orderby entry.Value ascending select entry);
                foreach (KeyValuePair<string, int> pair in sort)
                {
                    sb.AppendLine(string.Format("{0}" + separator + "{1}", pair.Value, pair.Key));
                }
            }
            else
            {
                foreach (KeyValuePair<string, int> pair in sortAlpha)
                {
                    sb.AppendLine(string.Format("{0}" + separator + "{1}", pair.Key, pair.Value));
                }
            }
            return sb.ToString();
        }
    }
}
