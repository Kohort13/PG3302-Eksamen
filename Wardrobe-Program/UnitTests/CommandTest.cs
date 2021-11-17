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

            Assert.AreEqual("change-property", command.Keyword);
            Assert.AreEqual(0, command.Parameters.Count);
        }

        [Test]
        public void TestParameters() {
            string input1 = "change-colour -id 1 -v green blue";
            Wardrobe_Program.Command command1 = new(input1);

            Assert.AreEqual("change-colour", command1.Keyword);
            Assert.AreEqual(2, command1.Parameters.Count);
            Assert.AreEqual("1", command1.Parameters["-id"]);
            Assert.AreEqual("green blue", command1.Parameters["-v"]);
        }

        [Test]
        public void TestNoValueToParam() {
            string input2 = "change-colour -id 1 -v green blue -b";
            Wardrobe_Program.Command command2 = new(input2);
            
            Assert.AreEqual("change-colour", command2.Keyword);
            Assert.AreEqual(3, command2.Parameters.Count);
            Assert.AreEqual("1", command2.Parameters["-id"]);
            Assert.AreEqual("green blue", command2.Parameters["-v"]);
            Assert.AreEqual("", command2.Parameters["-b"]);

            string input3 = "change-colour -id";
            Wardrobe_Program.Command command3 = new(input3);

            Assert.AreEqual("change-colour", command3.Keyword);
            Assert.AreEqual(1, command3.Parameters.Count);
            Assert.AreEqual("", command3.Parameters["-id"]);
        }
    }
}