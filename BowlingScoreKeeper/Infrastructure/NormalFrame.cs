using BowlingScoreKeeper.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace BowlingScoreKeeper.Infrastructure
{
    public sealed class NormalFrame : IFrame
    {        
        private readonly int delivery1, delivery2;
        private readonly IFrame nextFrame;
        private readonly int score;

        public NormalFrame(int delivery1, int delivery2, IFrame nextFrame)
        {
            Contract.Requires(delivery1 <= Constants.PinsTotal);
            Contract.Requires(delivery2 <= Constants.PinsTotal);

            this.delivery1 = delivery1;
            this.delivery2 = delivery2;
            
            this.score = this.delivery1 + this.delivery2;

            if (nextFrame != null)
            {
                if (IsStrike)
                {
                    this.score += nextFrame.Delivery1 != Constants.PinsTotal ? nextFrame.Delivery1 + nextFrame.Delivery2 :
                        (nextFrame.Delivery1 + (nextFrame.NextFrame != null ? nextFrame.NextFrame.Delivery1 : nextFrame.Delivery2));
                }

                if (IsSpare)
                {
                    this.score += nextFrame.Delivery1;
                }

                this.nextFrame = nextFrame;
            }
        }

        public bool IsStrike { get { return this.delivery1 == Constants.PinsTotal; } }

        public bool IsSpare { get { return !this.IsStrike && (this.delivery1 + this.delivery2) == Constants.PinsTotal; } }

        public int Delivery1 { get { return this.delivery1; } }

        public int Delivery2 { get { return this.delivery2; } }
        
        public int Score { get { return this.score; } }

        public IFrame NextFrame
        {
            get { return this.nextFrame; }
        }


        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant((this.delivery1 + this.delivery2) <= Constants.PinsTotal);
        }
    }
}