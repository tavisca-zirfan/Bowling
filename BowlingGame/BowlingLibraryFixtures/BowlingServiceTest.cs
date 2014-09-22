using System;
using BowlingLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingLibraryFixtures
{
    [TestClass]
    public class BowlingServiceTest
    {
        [TestMethod]
        public void ShouldReturnScoreAfterEachRoll()
        {
            var bowlingGame = new BowlingService();
            var score = RollBall(4, 3, bowlingGame);
            Assert.AreEqual(12,score);
        }

        [TestMethod]
        public void ShouldReturnZeroIfAllGutter()
        {
            var bowlingGame = new BowlingService();
            var score = RollBall(0,20, bowlingGame);
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void ShouldGiveNextSetNumberWhenCompleted()
        {
            var bowlingGame = new BowlingService();
            var score = RollBall(0, 10, bowlingGame);
            Assert.AreEqual(6, bowlingGame.SetNumber);
        }

        [TestMethod]
        public void ShouldGiveCurrentSetNumberWhenNotCompleted()
        {
            var bowlingGame = new BowlingService();
            var score = RollBall(0, 9, bowlingGame);
            Assert.AreEqual(5, bowlingGame.SetNumber);
        }

        [TestMethod]
        public void ShouldGiveBonusIfStrike()
        {
            var bowlingGame = new BowlingService();
            var score = RollBall(10, 1, bowlingGame);
            score = RollBall(4, 2, bowlingGame);
            Assert.AreEqual(26, score);
        }

        [TestMethod]
        public void ShouldGive300IfAllStrike()
        {
            var bowlingGame = new BowlingService();
            var score = RollBall(10, 12, bowlingGame);
            //score = RollBall(4, 2, bowlingGame);
            Assert.AreEqual(300, score);
        }

        private int RollBall(int noOfPins,int noOfTimes,IBowlingService bowling)
        {
            var score = 0;
            for (var i = 0; i < noOfTimes; i++)
            {
                score = bowling.RollBall(noOfPins);
            }
            return score;
        }
    }
}
