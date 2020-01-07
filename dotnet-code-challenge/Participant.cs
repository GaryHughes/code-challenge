using System;

namespace dotnet_code_challenge
{
    public class Participant
    {
        public Participant(string id, string name)
        {
            if (string.IsNullOrEmpty(id)) {
                throw new ArgumentException($"${id} cannot be null or empty", nameof(id));
            }

            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentException($"${name} cannot be null or empty", nameof(name));
            }

            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }        
    }
}