using NUnit.Framework;

namespace UnitTests
{
    public class CommandTest
    {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestNoParameters() {
            string userInput = "change-property";
            Wardrobe_Program.Command command = new(userInput);

            Assert.AreEqual("change-property", command.CommandComponent);
            Assert.AreEqual(0, command.Parameters.Count);
        }

        [Test]
        public void TestParameters() {
            string userInput = "change-colour 1 green";
            Wardrobe_Program.Command command = new(userInput);

            Assert.AreEqual("change-colour", command.CommandComponent);
            Assert.AreEqual(2, command.Parameters.Count);
            Assert.AreEqual("1", command.Parameters[0]);
            Assert.AreEqual("green", command.Parameters[1]);
        }
    }
}