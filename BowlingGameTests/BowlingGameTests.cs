using NUnit.Framework;
using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace BowlingGameTests
{
    [TestFixture]
    public class BowlingGameTests
    {
        private Game game;


        [Test]
        public void InitGame()
        {
            game = new Game();
            Assert.IsNotNull(game);
        }

        [Test]
        public void TestHittinZeroPerRoll()
        {
            game = new Game();
            RollPins(20, 0);
            Assert.AreEqual(0, game.Score);
        }

        [Test]
        public void TestHittingOnePerRoll()
        {
            game = new Game();
            RollPins(20,1);
            Assert.AreEqual(20, game.Score);
        }

        private void RollPins(int numberOfRolls, int pinsHitPerRoll)
        {
            for (var i = 0; i < numberOfRolls; i++)
            {
                game.Roll(pinsHitPerRoll);
            }
        }
    }
}
