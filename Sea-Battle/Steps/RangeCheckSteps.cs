using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sea_Battle;

namespace BDDTest
{
    [Binding]
    public class RangeCheckSteps
    {
        private int x;
        private int y;
        private bool result;

        [Given("the x coordinate is (\\d+)")]
        public void GivenXCoordinateIs(int xCoord)
        {
            x = xCoord;
        }

        [Given("the y coordinate is (\\d+)")]
        public void GivenYCoordinateIs(int yCoord)
        {
            y = yCoord;
        }

        [When("I check for coordinates within the range")]
        public void WhenICheckCoordinatesInRange()
        {
            result = SeaBattle.IsInRange(x, y);
        }

        [Then("the coordinates should be out of range")]
        public void ThenCoordinatesShouldBeOutOfRange()
        {
            Assert.IsFalse(result);
        }
    }
}