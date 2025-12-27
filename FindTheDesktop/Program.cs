namespace FindTheDesktop;

class Program
{
    static void Main(string[] args)
    {
        // Create a string out of all the args to be searched:
        var searchString = string.Join(" ", args).ToLower();
        searchString = searchString.Trim();
        if (searchString.Length == 0)
        {
            Console.WriteLine("No Search Terms");
            return;
        }

        // Search all of $XDG_DATA_DIRS - If it has a /applications folder, search that otherwise skip. args[] will be a search string.
        // should be lower case for comparisons
        var xdgDataDirs = Environment.GetEnvironmentVariable("XDG_DATA_DIRS");
        var foldersToSearch = new List<string>();

        if (!string.IsNullOrEmpty(xdgDataDirs))
        {
            var paths = xdgDataDirs.Split(':', StringSplitOptions.RemoveEmptyEntries);

            foreach (var path in paths)
            {
                var applicationsPath = Path.Combine(path, "applications");
                if (Directory.Exists(applicationsPath))
                {
                    foldersToSearch.Add(applicationsPath);
                }
            }
        }


        var matchingFiles = new HashSet<string>();

        foreach (var f in foldersToSearch)
        {
            foreach (var file in Directory.GetFiles(f))
            {
                if (Path.GetExtension(file).ToLower() == ".desktop")
                {
                    try
                    {
                        var fileContent = File.ReadAllText(file).ToLower();
                        if (fileContent.Contains(searchString))
                        {
                            matchingFiles.Add(file);
                        }
                    }
                    catch (Exception)
                    {
                        // Skip files that cannot be read
                    }
                }
            }
        }

        
        
        foreach (var f in matchingFiles)
        {
            if (!f.StartsWith("userapp"))
            {
                Console.WriteLine(f);
            }
        }
        Console.WriteLine("Done!");
    }
}