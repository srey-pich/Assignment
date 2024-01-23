using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the title channel:");
        string userInput = Console.ReadLine();

        string output = ExtractChannels(userInput);

        Console.WriteLine(output);
    }
    static string ExtractChannels(string title)
    {
        // Define a regular expression pattern to match tags in square brackets
        string pattern = @"\[([^\]]+)\]";

        // Use regex to find all matches in the title
        MatchCollection matches = Regex.Matches(title, pattern);

        // Define a set to store unique channels
        HashSet<string> channelsSet = new HashSet<string>();

        // Iterate over matches and add them to the set
        foreach (Match match in matches)
        {
            string[] channels = match.Groups[1].Value.Split(',');
            foreach (string channel in channels)
            {
                channelsSet.Add(channel.Trim());
            }
        }

        // Remove any irrelevant content
        HashSet<string> relevantChannels = new HashSet<string>(channelsSet, StringComparer.OrdinalIgnoreCase);
        relevantChannels.Remove("");
        relevantChannels.Remove("HAHA");

        // Format the output
        string output = $"Receive channels: {string.Join(", ", relevantChannels)}";
        return output;
    }
}
