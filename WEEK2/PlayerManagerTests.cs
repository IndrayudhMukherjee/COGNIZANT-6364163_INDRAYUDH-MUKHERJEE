using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerManagerTests
    {
        private Mock<IPlayerMapper> _mockMapper;

        [OneTimeSetUp]
        public void Init()
        {
            _mockMapper = new Mock<IPlayerMapper>();
        }

        [Test]
        public void RegisterNewPlayer_ShouldReturnValidPlayer_WhenPlayerDoesNotExist()
        {
            // Arrange
            string testName = "Virat Kohli";

            _mockMapper.Setup(p => p.IsPlayerNameExistsInDb(testName)).Returns(false);
            _mockMapper.Setup(p => p.AddNewPlayerIntoDb(testName));

            // Act
            var player = Player.RegisterNewPlayer(testName, _mockMapper.Object);

            // Assert
            Assert.IsNotNull(player);
            Assert.AreEqual("Virat Kohli", player.Name);
            Assert.AreEqual("India", player.Country);
            Assert.AreEqual(23, player.Age);
            Assert.AreEqual(30, player.NoOfMatches);
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrow_WhenPlayerExists()
        {
            _mockMapper.Setup(p => p.IsPlayerNameExistsInDb("Sachin")).Returns(true);

            var ex = Assert.Throws<ArgumentException>(() => 
                Player.RegisterNewPlayer("Sachin", _mockMapper.Object));

            Assert.That(ex.Message, Is.EqualTo("Player name already exists."));
        }
    }
}
