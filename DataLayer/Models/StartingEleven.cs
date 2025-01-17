﻿using Newtonsoft.Json;
using System.Text;

namespace Utility.Models
{
    public enum Position { Defender, Forward, Goalie, Midfield };

    public class StartingEleven : IComparable<StartingEleven>
    {
        private const char Del = '|';

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        public int NumberOfYellowCards { get; set; }

        public bool IsFavouritePlayer { get; set; }

        public int NumberOfGoals { get; set; }

        public int NumberOfRedCards => NumberOfYellowCards == 2 ? 1 : 0;

        public string? PicturePath { get; set; }

        public string FormatForFileImages()
            => $"{Name}{Del}{PicturePath}{Environment.NewLine}";

        public string FormatForFileFavourites() 
            => Name;

        public override string ToString() 
            => $"{Name}{Del}{ShirtNumber}";

        public override bool Equals(object? obj)
            => obj is StartingEleven startingEleven && Name == startingEleven.Name;

        public override int GetHashCode()
            => 13 * Name.GetHashCode();

        public int CompareTo(StartingEleven? other) 
            => Name.CompareTo(other?.Name);
    }
}
