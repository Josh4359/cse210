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
                    items.Add(item);

                    item = default;

                    lastC = default;

                    continue;
                }

                item += c;

                lastC = c;
            }

            if (item.Length > 0)
                items.Add(item);
            
            lines.Add(items);
        }

        return lines;
    }
}