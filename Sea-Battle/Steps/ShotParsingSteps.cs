using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sea_Battle;

namespace BDDTest
{
    [Binding]
    public class ShotParsingSteps
    {
        private string input;
        private int x;
        private int y;
        private bool result;

        [Given("I enter the string \"(.*)\"")]
        public void GivenIEnterLine(string line)
        {
            input = line;
        }

        [When("I try to parse shot coordinates")]
        public void WhenITryToParseShotCoordinates()
        {
            result = SeaBattle.TryParseShot(input, out x, out y);
        }

        [Then("the x and y coordinates should be valid")]
        public void ThenXAndYShouldBeValid()
        {
            Assert.IsTrue(result);
            Assert.IsTrue(x >= 0 && x < 10);
            Assert.IsTrue(y >= 0 && y < 10);
        }
    }
}