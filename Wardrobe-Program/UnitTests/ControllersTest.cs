using System.Collections.Generic;
using NUnit.Framework;
using Wardrobe_Program;

namespace UnitTests
{
    class ControllersTest
    {
        private Application app;
        private MockDao data;

        [SetUp]
        public void Setup() {
            app = new Application();
            data = new MockDao();
        }

        [Test]
        public void TestChangeNameController() {
            data.Insert(new Accessory());
            app.AddController("change-name", new ChangeNameController(data));
            app.Controllers["change-name"].Handle(new Command("change-name -id 0 -val A-new-name"));
            Assert.AreEqual("A-new-name", data.Retrieve(0).Name);
        }

        [Test]
        public void TestChangePriceController() {
            data.Insert(new Accessory());
            app.AddController("change-price", new ChangePriceController(data));
            app.Controllers["change-price"].Handle(new Command("change-price -id 0 -val 404"));
            Assert.AreEqual(404, data.Retrieve(0).Price);
        }

        [Test]
        public void TestChangeSizeController() {
	        data.Insert(new Accessory());
	        app.AddController("change-size", new ChangeSizeController(data));
	        app.Controllers["change-size"].Handle(new Command("change-size -id 0 -val new-size"));
	        Assert.AreEqual("new-size", data.Retrieve(0).Size);
        }

        [Test]
        public void TestChangeSeasonController() {
            var element = new Accessory { Name = "An accessory" };
            data.Insert(element);
            app.AddController("change-season", new ChangeSeasonController(data));
            app.Controllers["change-season"].Handle(new Command("change-season -id 0 -sp -su"));
            Assert.AreEqual(element.Seasons, new List<string> { "Spring", "Summer" });

            app.Controllers["change-season"].Handle(new Command("change-season -id 0 -w"));
            Assert.AreEqual(element.Seasons, new List<string> { "Winter" });
        }
    }
}
