using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MainApp

    {
        public static void Main(string[] args)
        {
            int i = 1;

            WordFrequency wordFreq = new WordFrequency();

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

                    dic = wordFreq.MkCount(lineSepProc, dic);

                    var listOfHighest = wordFreq.MkSort(dic, "desc", " ");

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
    }
}

