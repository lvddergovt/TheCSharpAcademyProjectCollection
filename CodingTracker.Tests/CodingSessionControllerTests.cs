namespace CodingTracker.Tests
{
    public class CodingSessionControllerTests
    {
        [TestMethod]
        public void TestCreateCodingSessionFromUserInput_UseCurrentDate_ShouldSetDateToCurrentDate()
        {
            // Arrange
            var codingSessionController = new CodingSessionController();
            var expectedDate = DateTime.Now.ToString("yyyy-MM-dd");

            // Act
            using (StringReader input = new StringReader("Y"))
            {
                Console.SetIn(input);
                codingSessionController.CreateCodingSessionFromUserInput();
            }

            // Assert
            // Add your assertions here to verify that the date is set to the current date

            Assert.AreEqual(expectedDate, codingSessionController.Date.ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void TestCreateCodingSessionFromUserInput_EnterCustomDate_ShouldSetDateToCustomDate()
        {
            // Arrange
            var codingSessionController = new CodingSessionController();
            var customDate = "2022-01-01";

            // Act
            using (StringReader input = new StringReader("n\n" + customDate))
            {
                Console.SetIn(input);
                codingSessionController.CreateCodingSessionFromUserInput();
            }

            // Assert
            Assert.AreEqual(customDate, codingSessionController.Date.ToString("yyyy-MM-dd"));
        }

        // Add more tests for other scenarios if needed
    }
}