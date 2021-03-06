﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assignment_5 {
    /// <summary>
    /// Holds up to 10 ordered scores to be displayed on the leaderboard
    /// </summary>
    public class LeaderBoard {

        #region Class Variables
        /// <summary>
        /// Stores up to 10 ordered scores
        /// </summary>
        public List<PlayerRank> rankings = new List<PlayerRank>(10);

        /// <summary>
        /// Just used for displaying which leaderboard it is
        /// </summary>
        public string leaderboardType;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor assigns correct gametype to leaderboard
        /// </summary>
        /// <param name="gameType"></param>
        public LeaderBoard(int gameType) {

            try {
                // assign which gameType leaderboard is for
                switch (gameType) {
                    case 0:
                        leaderboardType = "Addition";
                        break;
                    case 1:
                        leaderboardType = "Subtraction";
                        break;
                    case 2:
                        leaderboardType = "Multiplication";
                        break;
                    case 3:
                        leaderboardType = "Division";
                        break;
                }
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Insert Player
        /// <summary>
        /// Sorts score given and inserts it as a PlayerRank object
        /// </summary>
        /// <param name="correctGuesses"></param>
        /// <param name="time"></param>
        /// <param name="player"></param>
        public bool InsertPlayer(int correctGuesses, double time, Player player) {
            try {
                PlayerRank playerRank = new PlayerRank(correctGuesses, time, player);
                int rankIndexFinal = 0;
                // iterate over list
                for (int rankIndex = 0; rankIndex < rankings.Count; rankIndex++) {
                    // higher score than player at index
                    if (playerRank.correctGuesses > rankings[rankIndex].correctGuesses) {
                        // better time than player at index
                        rankings.Insert(rankIndex, playerRank);
                        return true;
                    }
                    // same score as player at index
                    else if (playerRank.correctGuesses == rankings[rankIndex].correctGuesses) {
                        // better time than player at index
                        if (playerRank.time <= rankings[rankIndex].time) {
                            rankings.Insert(rankIndex, playerRank);
                            return true;
                        }
                    }
                    rankIndexFinal = rankIndex;
                }
                // list < 10 items
                if (rankIndexFinal < 9) {
                    rankings.Add(playerRank);
                    return true;
                }
                return false;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
