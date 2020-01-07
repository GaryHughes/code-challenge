using System;
using System.IO;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    class Program
    {
        static void PrintUsage()
        {
            Console.Error.WriteLine("Usage: dotnet_code_challenge <INPUT DIRECTORY>");
        }

        static void Main(string[] args)
        {
            try {

                if (args.Length != 1) {
                    PrintUsage();
                    Environment.Exit(1);
                }

                var feedPath = args[0];

                if (!Path.IsPathRooted(feedPath)) {
                    feedPath = Path.Combine(".", feedPath);    
                }

                if (!Directory.Exists(feedPath)) {
                    Console.Error.WriteLine($"'{feedPath}' is not a directory");
                    PrintUsage();
                    Environment.Exit(1);    
                }

                foreach (var feed in LoadFeeds(feedPath)) {
                    foreach (var market in feed.Markets) {
                        Console.WriteLine(market.Name);
                        Console.WriteLine(new string('-', market.Name.Length)); 
                        foreach (var entry in market.Entries) {
                            Console.WriteLine($"{entry.Price}\t{entry.Participant.Name}");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex) {
                Console.Error.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        static IEnumerable<IFeed> LoadFeeds(string path)
        {
            foreach (var entry in Directory.EnumerateFiles(path)) {
                yield return Path.GetExtension(entry) switch {
                    ".xml" => new XmlFeed(entry),
                    ".json" => new JsonFeed(entry),
                    _ => throw new Exception($"Unsupported file type {entry}")
                };    
            }
        }
    }
}
