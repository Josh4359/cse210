public static class CSVUtility
{
    public static List<List<string>> ParseCSV(string[] csv)
    {
        List<List<string>> lines = new();

        foreach (string line in csv)
        {
            List<string> items = new();

            string item = default;

            char lastC = default;

            foreach (char c in line)
            {
                if (c == ',' && lastC != '\\')
                {
                    item = item.Replace("\\,", ",");
                    
                    items.Add(item);

                    item = default;

                    lastC = default;

                    continue;
                }

                item += c;

                lastC = c;
            }

            if (item.Length > 0)
            {
                item = item.Replace("\\,", ",");

                items.Add(item);
            }
            
            lines.Add(items);
        }

        return lines;
    }

    public static string ToCSV(string[] items)
    {
        string csv = default;

        for (int i = 0; i < items.Length; i++)
        {
            if (i > 0)
                csv += ',';
            
            csv += items[i].Replace(",", "\\,");
        }

        return csv;
    }
}