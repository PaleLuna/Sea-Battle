using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sea_Battle;

namespace BDDTest
{
    [Binding]
    public class BoardInitializationSteps
    {
        private char[,] board;

        [When("I initialize the game board")]
        public void WhenIInitializeGameBoard()
        {
            board = SeaBattle.InitializeBoard();
        }

        [Then("the game board should not be empty")]
        public void ThenGameBoardShouldNotBeEmpty()
        {
            Assert.IsNotNull(board);
        }
    }
}