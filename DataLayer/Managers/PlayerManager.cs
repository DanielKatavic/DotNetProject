﻿using Utility.Models;
using System.Reflection;
using Utility.Dal;

namespace Utility.Managers
{
    public static partial class PlayerManager
    {
        private static ISet<StartingEleven>? players;
        private static IList<Match>? matches;
        private static readonly IRepository repository = RepositoryFactory.GetRepository();

        private static readonly Predicate<TeamEvent> isYellowCard = te => te.TypeOfEvent is TypeOfEvent.YellowCard or TypeOfEvent.YellowCardSecond;
        private static readonly Predicate<TeamEvent> isGoal = te => te.TypeOfEvent is TypeOfEvent.Goal;
        private static readonly Predicate<Match> isHomeTeam = m => m.HomeTeam?.Country == Settings.TeamSelected?.Country;

        private static ISet<StartingEleven> playersWithYellowCards = new SortedSet<StartingEleven>();
        private static ISet<StartingEleven> playersWithGoals = new SortedSet<StartingEleven>();
    }

    public static partial class PlayerManager
    {
        public static async Task<ISet<StartingEleven>?> GetAllPlayers()
        {
            matches = await MatchManager.GetAllMatches();
            int? teamIndex = matches?.ToList().FindIndex(isHomeTeam);
            if (teamIndex == -1)
            {
                players = matches?[0].AwayTeamStatistics?.AllPlayers;
            }
            else if (teamIndex is not null)
            {
                players = matches?[(int)teamIndex].HomeTeamStatistics?.AllPlayers;
            }
            return players;
        }

        public static void FillPlayersWithEvents(Match match)
        {
            match.HomeTeamEvents?.ToList().ForEach(e =>
            {
                if (e.TypeOfEvent is TypeOfEvent.Goal)
                {
                    StartingEleven? player = match.HomeTeamStatistics?.StartingEleven?.ToList().FirstOrDefault(se => se.Name == e.Player);
                    if (player is not null) player.NumberOfGoals++;
                }
                if (e.TypeOfEvent is TypeOfEvent.YellowCard || e.TypeOfEvent is TypeOfEvent.YellowCardSecond)
                {
                    StartingEleven? player = match.HomeTeamStatistics?.StartingEleven?.ToList().FirstOrDefault(se => se.Name == e.Player);
                    if (player is not null) player.NumberOfYellowCards = e.TypeOfEvent is TypeOfEvent.YellowCard ? 1 : 2;
                }
            });
            match.AwayTeamEvents?.ToList().ForEach(e =>
            {
                if (e.TypeOfEvent is TypeOfEvent.Goal)
                {
                    StartingEleven? player = match.AwayTeamStatistics?.StartingEleven?.ToList().FirstOrDefault(se => se.Name == e.Player);
                    if (player is not null) player.NumberOfGoals++;
                }
                if (e.TypeOfEvent is TypeOfEvent.YellowCard || e.TypeOfEvent is TypeOfEvent.YellowCardSecond)
                {
                    StartingEleven? player = match.AwayTeamStatistics?.StartingEleven?.ToList().FirstOrDefault(se => se.Name == e.Player);
                    if (player is not null) player.NumberOfYellowCards = e.TypeOfEvent is TypeOfEvent.YellowCard ? 1 : 2;
                }
            });
        }

        public static ISet<StartingEleven> GetPlayersWithGoals()
        {
            var teamEvents = GetTeamEvents(MethodBase.GetCurrentMethod()?.Name ?? string.Empty);
            teamEvents?.ToList().ForEach(te => te?.ForEach(g => AddGoalToPlayer(g)));
            return playersWithGoals;
        }

        public static ISet<StartingEleven> GetPlayersWithYellowCards()
        {
            var teamEvents = GetTeamEvents(MethodBase.GetCurrentMethod()?.Name ?? string.Empty);
            teamEvents?.ToList().ForEach(te => te?.ForEach(yc => AddYellowCardToPlayer(yc)));
            return playersWithYellowCards;
        }

        public static void SavePlayerWithImage(StartingEleven player)
            => repository.SavePlayersImage(player);

        public static void LoadPlayersWithImage()
        {
            string[] lines = repository.LoadPlayersWithImage();
            if (lines.Length == 0) return;
            lines.ToList().ForEach(line =>
            {
                string[] details = line.Split("|");
                StartingEleven? player = players?.ToList().FirstOrDefault(p => p.Name == details[0]);
                if (player is not null) player.PicturePath = details[1];
            });
        }

        public static void LoadPlayersWithImage(Match match)
        {
            IEnumerable<StartingEleven>? allPlayers = match.HomeTeamStatistics?.StartingEleven?.Concat(match.AwayTeamStatistics?.StartingEleven ?? Array.Empty<StartingEleven>());

            string[] lines = repository.LoadPlayersWithImage();
            if (lines.Length == 0) return;
            lines.ToList().ForEach(line =>
            {
                string[] details = line.Split("|");
                StartingEleven? player = allPlayers?.ToList().FirstOrDefault(p => p.Name == details[0]);
                if (player is not null) player.PicturePath = details[1];
            });
        }

        public static void SaveFavouritePlayers()
        {
            List<StartingEleven>? favouritePlayers = players?.ToList().FindAll(p => p.IsFavouritePlayer);
            repository.SaveFavouritePlayers(favouritePlayers ?? new List<StartingEleven>());
        }

        public static void LoadFavouritePlayers()
        {
            string[] lines = repository.LoadFavouritePlayers();
            if (lines.Length == 0) return;
            lines.ToList().ForEach(line =>
            {
                StartingEleven? player = players?.ToList().FirstOrDefault(p => p.Name == line);
                if (player is not null) player.IsFavouritePlayer = true;
            });
        }

        public static async void ResetCollections()
        {
            playersWithYellowCards.Clear();
            playersWithGoals.Clear();
            matches = await MatchManager.GetAllMatches();
        }

        private static IEnumerable<List<TeamEvent>?>? GetTeamEvents(string nameOfMethod)
            => matches?.ToList().Select(
              m => m?.HomeTeam?.Country == Settings.TeamSelected?.Country ?
                  m?.HomeTeamEvents?.FindAll(nameOfMethod == nameof(GetPlayersWithGoals) ? isGoal : isYellowCard) :
                  m?.AwayTeamEvents?.FindAll(nameOfMethod == nameof(GetPlayersWithGoals) ? isGoal : isYellowCard));

        private static void AddGoalToPlayer(TeamEvent teamEvent)
        {
            StartingEleven? player = players?.ToList().FirstOrDefault(p => p.Name == teamEvent.Player);
            if (player is not null)
            {
                player.NumberOfGoals++;
                playersWithGoals.Add(player);
            }
        }

        private static void AddYellowCardToPlayer(TeamEvent teamEvent)
        {
            StartingEleven? player = players?.ToList().FirstOrDefault(p => p.Name == teamEvent.Player);
            if (player is not null)
            {
                player.NumberOfYellowCards = teamEvent.TypeOfEvent is TypeOfEvent.YellowCard ? 1 : 2;
                playersWithYellowCards.Add(player);
            }
        }
    }
}