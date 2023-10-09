using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sea_Battle
{
    [TestClass]
    public class SeaBattleTDDTests
    {
        [TestMethod]
        private void TestTryParseShot()
        {
            string line = "9,0";
            int x;
            int y;
            
            Assert.IsTrue(SeaBattle.TryParseShot(line, out x, out y));
        }
    }
}