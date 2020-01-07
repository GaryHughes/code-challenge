using System;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class Market
    {
        public Market(string name)
        {
            Name = name;
        }
        
        public Market(string name, IEnumerable<Entry> entries)
        {
            Name = name;
            foreach (var entry in entries) {
                Add(entry);          
            }
        }

        public void Add(Entry entry)
        {
            if (_participants.Contains(entry.Participant.Id)) {
                throw new ArgumentException($"Invalid attempt to add participant with Id={entry.Participant.Id} more than once");
            }

            _participants.Add(entry.Participant.Id);
            _entries.Add((entry.Price, entry.Generation), entry);
        }
        
        public string Name { get; }

        public IEnumerable<Entry> Entries => _entries.Values;

        readonly SortedDictionary<(decimal Price, long Generation), Entry> _entries = new SortedDictionary<(decimal Price, long Generation), Entry>();

        readonly HashSet<string> _participants = new HashSet<string>();
    }
}