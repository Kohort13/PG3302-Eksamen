using NUnit.Framework;
using Wardrobe_Program;

namespace UnitTests
{
    public class ValidatorTest
    {
        [SetUp]
        public void Setup() {

        }

        [Test]
        public void TestNoRequiredParams() {
            ControllerValidator noRequiredParams = new()
            {
                AvailableKeys =
                {
                    { "-id", (false, true) },
                    {"-test", (false, false)}
                }
            };
            Assert.That(noRequiredParams.Validate(new Command("junk")));
            Assert.That(noRequiredParams.Validate(new Command("junk -id 44")));
            Assert.That(!noRequiredParams.Validate(new Command("junk -id")));
            Assert.That(noRequiredParams.Validate(new Command("junk -test")));
        }

        [Test]
        public void TestRequiredParams() {
            ControllerValidator requiredParams = new()
            {
                AvailableKeys =
                {
                    { "-a", (true, true) },
                    { "-b", (true, false) },
                    { "-c", (false, true)},
                    { "-d", (false, false)}
                }
            };

            Assert.That(requiredParams.Validate(new Command("kw -a 1 -b")));
            Assert.That(!requiredParams.Validate(new Command("kw -a 1")));
            Assert.That(!requiredParams.Validate(new Command("kw -a -b")));
            Assert.That(!requiredParams.Validate(new Command("kw -c -d")));
            Assert.That(!requiredParams.Validate(new Command("kw -b")));
        }
    }
}