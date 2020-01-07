using System;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class Market
    {
        public void Add(Entry entry)
        {
            _entries.Add((entry.Price, entry.Generation), entry);
        }
        
        public IEnumerable<Entry> Entries => _entries.Values;

        readonly SortedDictionary<(decimal Price, long Generation), Entry> _entries = new SortedDictionary<(decimal Price, long Generation), Entry>();
    }
}