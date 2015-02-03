using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlingScoreKeeper.Core
{
    public interface IFrame
    {
        int Delivery1 { get; }
        int Delivery2 { get; }
        int Score { get; }
        IFrame NextFrame { get; }
    }
}