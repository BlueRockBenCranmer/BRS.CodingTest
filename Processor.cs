using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public partial class WordFrequency
{

    public Dictionary<string, int> MkCount(string[] arr, Dictionary<string, int> dic)
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

    public string MkSort(Dictionary<string, int> dic, string sortOrder, string separator)
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
    