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

        [Test]
        public void TestOneSpare()
        {
            game = new Game();
            RollSpare();
            game.Roll(3);
            RollPins(17, 0);
            Assert.AreEqual(16, game.Score);
        }

        [Test]
        public void TestOneString()
        {
            game = new Game();
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollPins(16,0);
            Assert.AreEqual(24, game.Score);
        }

        [Test]
        public void TestPerfectGame()
        {
            game = new Game();
            RollPins(12,10);
            Assert.AreEqual(300, game.Score);
        }

        private void RollPins(int numberOfRolls, int pinsHitPerRoll)
        {
            for (var i = 0; i < numberOfRolls; i++)
            {
                game.Roll(pinsHitPerRoll);
            }
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }
    }
}
