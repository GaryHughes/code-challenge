using System;

namespace dotnet_code_challenge
{
    public class Entry
    {
        public Entry(Participant participant, decimal price)
        {
            if (price == 0) {
                throw new ArgumentException($"${price} cannot zero", nameof(price));
            }

            if (price < 0) {
                throw new ArgumentException($"${price} cannot be negative", nameof(price));
            }

            Participant = participant;
            Price = price;
            Generation = AllocationGeneration();
        }

        public Participant Participant { get; }
        public decimal Price { get; }
        public long Generation { get; } 

        static long AllocationGeneration()
        {
            return _nextGeneration++;
        }

        static long _nextGeneration = 0;
    }
}