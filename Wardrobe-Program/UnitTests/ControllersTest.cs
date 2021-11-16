using NUnit.Framework;
using Wardrobe_Program;

namespace UnitTests
{
    class ControllersTest
    {
        private Wardrobe_Program.Application app;

        [SetUp]
        public void Setup() {
            app = new Application();
        }

        [Test]
        public void TestChangeNameController() {
            MockDatabase data = new();
            data.Insert(new Accessory());
            app.AddController("change-name", new ChangeNameController(data));
            app.Controllers["change-name"].Handle(new Command("change-name 0 A-new-name"));
            Assert.AreEqual("A-new-name", data.Retrieve(0).Name);
        }

    }
}
