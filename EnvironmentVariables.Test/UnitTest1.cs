namespace EnvironmentVariables.Test
{
    public class Tests
    {
        private TestEnvironmentVariables sut;

        [SetUp]
        public void Setup()
        {
            sut = new TestEnvironmentVariables();
        }

        [TearDown]
        public void Cleanup()
        {
            Environment.SetEnvironmentVariable(nameof(sut.EnvironmentVariable1), null);
            Environment.SetEnvironmentVariable(nameof(sut.EnvironmentVariable2), null);
        }

        [Test]
        public void Init_DoesNotFailWithoutValues()
        {
            // Arrange
            // Act
            sut.Init();

            // Assert
            Assert.Null(sut.EnvironmentVariable1);
            Assert.Null(sut.EnvironmentVariable2);
        }

        [Test]
        public void EnvironmentVariable1_ContainsCorrectValue()
        {
            // Arrange
            string testValue = "TEST";
            Environment.SetEnvironmentVariable(nameof(sut.EnvironmentVariable1), testValue);

            // Act
            sut.Init();

            // Assert
            Assert.That(sut.EnvironmentVariable1, Is.EqualTo("TEST"));
            Assert.Null(sut.EnvironmentVariable2);
        }

        [Test]
        public void EnvironmentVariable2_ContainsCorrectValue()
        {
            // Arrange
            string testValue = "TEST Random string here";
            Environment.SetEnvironmentVariable(nameof(sut.EnvironmentVariable2), testValue);

            // Act
            sut.Init();

            // Assert
            Assert.That(sut.EnvironmentVariable2, Is.EqualTo(testValue));
            Assert.Null(sut.EnvironmentVariable1);
        }
    }
}