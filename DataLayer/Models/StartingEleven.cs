﻿using Newtonsoft.Json;

namespace Utility.Models
{
    public enum Position { Defender, Forward, Goalie, Midfield };

    public class StartingEleven : IComparable<StartingEleven>
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string? Position { get; set; }

        public override string ToString() 
            => $"{Name} | {ShirtNumber}";

        public override bool Equals(object? obj)
            => obj is StartingEleven startingEleven && Name == startingEleven.Name;

        public override int GetHashCode()
            => 13 * Name.GetHashCode();

        public int CompareTo(StartingEleven? other) 
            => Name.CompareTo(other.Name);
    }
}