using System.Collections.Generic;
using System.Diagnostics.Contracts;
using BowlingScoreKeeper.Core;

namespace BowlingScoreKeeper.Infrastructure
{
    public sealed class ScoreCard
    {
        private readonly RollRecord[] rollRecords;

        private int lastUpdatedIndex;

        public ScoreCard()
        {
            this.rollRecords = new RollRecord[Constants.PinsTotal];
            this.lastUpdatedIndex = 0;
        }

        public IEnumerable<int> Scores
        { 
            get 
            {                
                IFrame currentFrame = null, nextFrame = null;

                if (lastUpdatedIndex == Constants.PinsTotal - 1)
                {
                    nextFrame = new FinalFrame(this.rollRecords[lastUpdatedIndex].Delivery1, this.rollRecords[lastUpdatedIndex].Delivery2, this.rollRecords[lastUpdatedIndex].Delivery3);
                }
                else
                {
                    nextFrame = new NormalFrame(this.rollRecords[lastUpdatedIndex].Delivery1, this.rollRecords[lastUpdatedIndex].Delivery2, null);
                }

                for (int i = lastUpdatedIndex - 1; i >= 0; i--)
                {
                    currentFrame = new NormalFrame(this.rollRecords[i].Delivery1, this.rollRecords[i].Delivery2, nextFrame);
                    nextFrame = currentFrame;
                }

                int score = 0;
                while (currentFrame != null)
                {
                    score += currentFrame.Score;
                    yield return score;
                    currentFrame = currentFrame.NextFrame;
                }
            }            
        }

        public void UpdateRollRecord(int frameIndex, RollRecord record)
        {
            Contract.Requires(frameIndex >= 0 && frameIndex <= Constants.FramesTotal);
            this.rollRecords[frameIndex] = record;
            this.lastUpdatedIndex = frameIndex;
        }                
    }
}