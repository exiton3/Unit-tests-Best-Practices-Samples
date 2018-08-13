using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSamples.Tests
{
    [TestClass]
    public class StringCalculatorTests2
    {
        //Better
        [TestMethod]
        public void Add_EmptyString_ReturnsZero3()
        {
            //Arrange
            var calculator = new StringCalculator();
            
            //Act
            int result = calculator.Add("");
            
            //Assert
            Assert.AreEqual(0, result);
        }
        
        //Bad
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            var calculator = new StringCalculator();

            Assert.AreEqual(0, calculator.Add(""));
        }
    }
}