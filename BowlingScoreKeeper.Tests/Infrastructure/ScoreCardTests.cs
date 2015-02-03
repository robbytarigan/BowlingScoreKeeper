using BowlingScoreKeeper.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreKeeper.Tests.Infrastructure
{
    [TestFixture]
    public class ScoreCard_When_Scores
    {
        [Test]
        public void Given_no_spares_or_strikes_Should_give_correct_scores()
        {
            var scoreCard = new ScoreCard();
            scoreCard.UpdateRollRecord(0, new RollRecord { Player = "John", Delivery1 = 9, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(1, new RollRecord { Player = "John", Delivery1 = 3, Delivery2 = 5 });
            scoreCard.UpdateRollRecord(2, new RollRecord { Player = "John", Delivery1 = 6, Delivery2 = 1 });
            scoreCard.UpdateRollRecord(3, new RollRecord { Player = "John", Delivery1 = 3, Delivery2 = 6 });
            scoreCard.UpdateRollRecord(4, new RollRecord { Player = "John", Delivery1 = 8, Delivery2 = 1 });
            scoreCard.UpdateRollRecord(5, new RollRecord { Player = "John", Delivery1 = 5, Delivery2 = 3 });
            scoreCard.UpdateRollRecord(6, new RollRecord { Player = "John", Delivery1 = 2, Delivery2 = 5 });
            scoreCard.UpdateRollRecord(7, new RollRecord { Player = "John", Delivery1 = 8, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(8, new RollRecord { Player = "John", Delivery1 = 7, Delivery2 = 1 });
            scoreCard.UpdateRollRecord(9, new RollRecord { Player = "John", Delivery1 = 8, Delivery2 = 1 });

            var expectedScores = new[] { 9, 17, 24, 33, 42, 50, 57, 65, 73, 82 };            

            CollectionAssert.AreEqual(expectedScores, scoreCard.Scores);
        }

        [Test]
        public void Given_spares_included_Should_give_correct_scores()
        {
            var scoreCard = new ScoreCard();
            scoreCard.UpdateRollRecord(0, new RollRecord { Player = "Mary", Delivery1 = 9, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(1, new RollRecord { Player = "Mary", Delivery1 = 3, Delivery2 = 7 });
            scoreCard.UpdateRollRecord(2, new RollRecord { Player = "Mary", Delivery1 = 6, Delivery2 = 1 });
            scoreCard.UpdateRollRecord(3, new RollRecord { Player = "Mary", Delivery1 = 3, Delivery2 = 7 });
            scoreCard.UpdateRollRecord(4, new RollRecord { Player = "Mary", Delivery1 = 8, Delivery2 = 1 });
            scoreCard.UpdateRollRecord(5, new RollRecord { Player = "Mary", Delivery1 = 5, Delivery2 = 5 });
            scoreCard.UpdateRollRecord(6, new RollRecord { Player = "Mary", Delivery1 = 0, Delivery2 = 10 });
            scoreCard.UpdateRollRecord(7, new RollRecord { Player = "Mary", Delivery1 = 8, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(8, new RollRecord { Player = "Mary", Delivery1 = 7, Delivery2 = 3 });
            scoreCard.UpdateRollRecord(9, new RollRecord { Player = "Mary", Delivery1 = 8, Delivery2 = 2, Delivery3 = 8 });

            var expectedScores = new[] { 9, 25, 32, 50, 59, 69, 87, 95, 113, 131 };
            
            CollectionAssert.AreEqual(expectedScores, scoreCard.Scores);
        }

        [Test]
        public void Given_spares_and_strikes_Should_give_correct_score()
        {
            var scoreCard = new ScoreCard();
            scoreCard.UpdateRollRecord(0, new RollRecord { Player = "Kim", Delivery1 = 10 , Delivery2 = 0 });
            scoreCard.UpdateRollRecord(1, new RollRecord { Player = "Kim", Delivery1 = 3, Delivery2 = 7 });
            scoreCard.UpdateRollRecord(2, new RollRecord { Player = "Kim", Delivery1 = 6, Delivery2 = 1 });
            scoreCard.UpdateRollRecord(3, new RollRecord { Player = "Kim", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(4, new RollRecord { Player = "Kim", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(5, new RollRecord { Player = "Kim", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(6, new RollRecord { Player = "Kim", Delivery1 = 2, Delivery2 = 8 });
            scoreCard.UpdateRollRecord(7, new RollRecord { Player = "Kim", Delivery1 = 9, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(8, new RollRecord { Player = "Kim", Delivery1 = 7, Delivery2 = 3 });
            scoreCard.UpdateRollRecord(9, new RollRecord { Player = "Kim", Delivery1 = 10, Delivery2 = 10, Delivery3 = 10 });

            var expectedScores = new[] { 20, 36, 43, 73, 95, 115, 134, 143, 163, 193 };
            var scores = scoreCard.Scores.ToList();

            CollectionAssert.AreEqual(expectedScores, scoreCard.Scores);
        }

        [Test]
        public void Given_perfect_game_Should_give_perfect_score()
        {
            var scoreCard = new ScoreCard();
            scoreCard.UpdateRollRecord(0, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(1, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(2, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(3, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(4, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(5, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(6, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(7, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(8, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 0 });
            scoreCard.UpdateRollRecord(9, new RollRecord { Player = "Leo", Delivery1 = 10, Delivery2 = 10, Delivery3 = 10 });

            var expectedScores = new[] { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300 };

            var scores = scoreCard.Scores.ToList();

            CollectionAssert.AreEqual(expectedScores, scoreCard.Scores);
        }
    }
}
