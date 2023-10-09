using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sea_Battle;

namespace BDDTest
{
    [Binding]
    public class EnemyAttackSteps
    {
        private int shipAmount;
        private char[,] board;
        private bool result;

        [Given("the number of enemy ships is (\\d+)")]
        public void GivenNumberOfEnemyShipsIs(int numberOfShips)
        {
            shipAmount = numberOfShips;
        }

        [Given("the opponent's game board is not initialized")]
        public void GivenOpponentsGameBoardIsNotInitialized()
        {
            board = null;
        }

        [When("the opponent attempts to attack")]
        public void WhenOpponentAttemptsToAttack()
        {
            result = SeaBattle.TryEnemyAttack(board, new Random(), ref shipAmount);
        }

        [Then("the enemy attack should not be successful")]
        public void ThenEnemyAttackShouldNotBeSuccessful()
        {
            Assert.IsFalse(result);
        }
    }
}