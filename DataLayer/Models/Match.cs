﻿using Newtonsoft.Json;

namespace Utility.Models
{
    public enum Status { Completed };
    public enum StageName { Final, FirstStage, PlayOffForThirdPlace, QuarterFinals, RoundOf16, SemiFinals };
    public enum Time { FullTime };

    public class Match
    {
        [JsonProperty("venue")]
        public string? Venue { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("time")]
        public string? Time { get; set; }

        [JsonProperty("fifa_id")]
        public long FifaId { get; set; }

        [JsonProperty("weather")]
        public Weather? Weather { get; set; }

        [JsonProperty("attendance")]
        public long Attendance { get; set; }

        [JsonProperty("officials")]
        public List<string>? Officials { get; set; }

        [JsonProperty("stage_name")]
        public string? StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string? HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string? AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public string? Datetime { get; set; }

        [JsonProperty("winner")]
        public string? Winner { get; set; }

        [JsonProperty("winner_code")]
        public string? WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public Team? HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public Team? AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent>? HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent>? AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics? HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics? AwayTeamStatistics { get; set; }

        [JsonProperty("last_event_update_at")]
        public string? LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public string? LastScoreUpdateAt { get; set; }

        public override string ToString() 
            => $"{Location} | {HomeTeam}";
    }
}