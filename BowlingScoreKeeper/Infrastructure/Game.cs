using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace BowlingScoreKeeper.Infrastructure
{
    public class Game
    {
        private readonly Dictionary<string, ScoreCard> scoreCards;

        public Game(string[] players)
        {
            Contract.Requires(players != null && players.Any());

            this.scoreCards = new Dictionary<string, ScoreCard>();

            foreach (var p in players)
            {
                this.scoreCards.Add(p, new ScoreCard());
            }            
        }

        public IEnumerable<string> Players
        {
            get
            {
                return this.scoreCards.Keys;
            }
        }

        public void UpdateRollRecord(int frameIndex, RollRecord[] records)
        {
            Contract.Requires(frameIndex >= 0 && frameIndex <= Constants.FramesTotal);
            foreach (var record in records)
            {
                scoreCards[record.Player].UpdateRollRecord(frameIndex, record);                
            }
        }        
    }
}