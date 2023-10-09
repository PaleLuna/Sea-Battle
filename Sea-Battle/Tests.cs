using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sea_Battle
{
    [TestClass]
    public class SeaBattleTDDTests
    {
        [TestMethod]
        public void TestTryParseShot()
        {
            string line = "9,0";
            int x;
            int y;
            
            Assert.IsTrue(SeaBattle.TryParseShot(line, out x, out y));
        }

        [TestMethod]
        public void TestIsInRange()
        {
            int x = 10;
            int y = 11;
            
            Assert.IsFalse(SeaBattle.IsInRange(x, y));
        }

        [TestMethod]
        public void TestInitializeBoard()
        {
            char[,] board;
            board = SeaBattle.InitializeBoard();
            
            Assert.IsTrue(board != null);
        }

        [TestMethod]
        public void TestEnemyAttack()
        {
            int shipAmount = 5;
            char[,] board = null;
            
            Assert.IsFalse(SeaBattle.TryEnemyAttack(board, new Random(), ref shipAmount));
        }
    }
}