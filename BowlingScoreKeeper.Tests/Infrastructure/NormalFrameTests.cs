using BowlingScoreKeeper.Infrastructure;
using NUnit.Framework;

namespace BowlingScoreKeeper.Tests.Models
{
    [TestFixture]
    public class NormalFrame_When_IsStrike
    {
        [Test]
        public void Given_all_pins_knocked_down_on_first_delivery_Should_return_true()
        {
            var frame = new NormalFrame(10, 0, null);
            Assert.IsTrue(frame.IsStrike);
        }

        [TestCase(0, 10)]
        [TestCase(1, 9)]
        [TestCase(2, 3)]
        public void Given_not_all_pins_knocked_down_on_first_delivery_Should_return_false(int delivery1, int delivery2)
        {
            var frame = new NormalFrame(delivery1, delivery2, null);
            Assert.IsFalse(frame.IsStrike);
        }
    }

    [TestFixture]
    public class NormalFrame_When_IsSpare
    {
        [Test]
        public void Given_all_pins_knocked_down_on_first_delivery_Should_return_false()
        {
            var frame = new NormalFrame(10, 0, null);
            Assert.IsFalse(frame.IsSpare);
        }

        [TestCase(0, 10)]
        [TestCase(1, 9)]
        public void Given_not_all_pins_knocked_down_on_first_delivery_and_the_reminder_are_knocked_down_after_that_Should_return_true(int delivery1, int delivery2)
        {
            var frame = new NormalFrame(delivery1, delivery2, null);
            Assert.IsTrue(frame.IsSpare);
        }

        
        [TestCase(0, 0)]
        [TestCase(2, 3)]
        public void Given_not_all_pins_knocked_down_on_first_and_second_deliveries_Should_return_false(int delivery1, int delivery2)
        {
            var frame = new NormalFrame(delivery1, delivery2, null);
            Assert.IsFalse(frame.IsSpare);
        }    
    }

    [TestFixture]
    public class NormalFrame_When_Score
    {
        [TestCase(0, 0, Result = 0)]
        [TestCase(10, 0, Result= 10)]
        [TestCase(0, 10, Result=10)]
        [TestCase(2, 3, Result=5)]
        public int Given_next_frame_is_not_defined_yet_Then_score_is_the_number_of_pins_knocked(int delivery1, int delivery2)
        {
            var frame = new NormalFrame(delivery1, delivery2, null);
            return frame.Score;
        }

        [TestCase(0, 0, Result = 10)]
        [TestCase(10, 0, Result = 20)]
        [TestCase(7, 3, Result = 20)]
        [TestCase(3, 7, Result = 20)]
        [TestCase(7, 1, Result = 18)]
        public int Given_strike_and_next_frame_is_defined_Then_current_score_is_added_with_the_next_frame_score(int nextDelivery1, int nextDelivery2)
        {
            var nextFrame = new NormalFrame(nextDelivery1, nextDelivery2, null);
            var currentFrame = new NormalFrame(10, 0, nextFrame);
            return currentFrame.Score;
        }

        [TestCase(0, 0, Result = 10)]
        [TestCase(10, 0, Result = 20)]
        [TestCase(7, 3, Result = 17)]
        [TestCase(7, 1, Result = 17)]
        public int Given_spare_and_next_frame_is_defined_Then_current_score_is_added_with_the_next_first_delivery(int nextDelivery1, int nextDelivery2)
        {
            var nextFrame = new NormalFrame(nextDelivery1, nextDelivery2, null);
            var currentFrame = new NormalFrame(8, 2, nextFrame);
            return currentFrame.Score;
        }

        [TestCase(0, 0, Result = 8)]
        [TestCase(10, 0, Result = 8)]
        [TestCase(7, 3, Result = 8)]
        [TestCase(7, 1, Result = 8)]
        public int Given_not_all_pins_are_knocked_down_and_next_frame_is_defined_Then_current_score_is_not_added(int nextDelivery1, int nextDelivery2)
        {
            var nextFrame = new NormalFrame(nextDelivery1, nextDelivery2, null);
            var currentFrame = new NormalFrame(8, 0, nextFrame);
            return currentFrame.Score;
        }
    }
}
