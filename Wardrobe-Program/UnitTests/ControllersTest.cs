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
        [Test]
        public void TestChangePriceController()
        {
            MockDatabase data = new();
            data.Insert(new Accessory());
            app.AddController("change-price", new ChangePriceController(data));
            app.Controllers["change-price"].Handle(new Command("change-price 0 404"));
            Assert.AreEqual("404", data.Retrieve(0).Price);
        }
        [Test]
        public void TestChangeSizeController()
        {
	        MockDatabase data = new();
	        data.Insert(new Accessory());
	        app.AddController("change-size", new ChangeSizeController(data));
	        app.Controllers["change-size"].Handle(new Command("change-size 0 new-size"));
	        Assert.AreEqual("new-size", data.Retrieve(0).Size);
        }
    }
}
