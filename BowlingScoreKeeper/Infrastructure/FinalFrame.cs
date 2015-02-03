using BowlingScoreKeeper.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace BowlingScoreKeeper.Infrastructure
{
    public sealed class FinalFrame : IFrame
    {
        private readonly int delivery1, delivery2, delivery3;        

        public FinalFrame(int delivery1, int delivery2, int delivery3)
        {
            Contract.Requires(delivery1 <= Constants.PinsTotal);
            Contract.Requires(delivery2 <= Constants.PinsTotal);
            Contract.Requires(delivery3 <= Constants.PinsTotal);              

            this.delivery1 = delivery1;
            this.delivery2 = delivery2;
            this.delivery3 = delivery3;
        }

        public int Delivery1 { get { return this.delivery1; } }

        public int Delivery2 { get { return this.delivery2; } }

        public int Score
        {
            get { return this.delivery1 + this.delivery2 + this.delivery3; }
        }

        public IFrame NextFrame
        {
            get { return null; }
        }
    }
}