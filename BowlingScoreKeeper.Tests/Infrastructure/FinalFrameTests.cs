using BowlingScoreKeeper.Infrastructure;
using NUnit.Framework;

namespace BowlingScoreKeeper.Tests.Infrastructure
{    
    [TestFixture]
    public class FinalFrame_When_Score
    {
        [TestCase(2, 3, 4, Result = 9)]
        [TestCase(8, 2, 2, Result = 12)]
        [TestCase(10, 10, 10, Result = 30)]
        public int Should_be_the_total_of_all_deliveries(int delivery1, int delivery2, int delivery3)
        {
            var frame = new FinalFrame(delivery1, delivery2, delivery3);
            return frame.Score;
        }
    }
}
