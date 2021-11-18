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
            app.Controllers["change-name"].Handle(new Command("change-name -id 0 -val A new name"));
            Assert.That(data.Retrieve(0).Name, Is.EqualTo("A new name"));
        }

        [Test]
        public void TestChangePriceController() {
            data.Insert(new Accessory());
            app.AddController("change-price", new ChangePriceController(data));
            app.Controllers["change-price"].Handle(new Command("change-price -id 0 -val 299.99"));
            Assert.That(data.Retrieve(0).Price, Is.EqualTo(299.99).Within(0.01));
        }

        [Test]
        public void TestChangeSizeController() {
	        data.Insert(new Accessory());
	        app.AddController("change-size", new ChangeSizeController(data));
	        app.Controllers["change-size"].Handle(new Command("change-size -id 0 -val new-size"));
            Assert.That(data.Retrieve(0).Size, Is.EqualTo("new-size"));
        }

        [Test]
        public void TestChangeSeasonController() {
            var element = new Accessory { Name = "An accessory" };
            data.Insert(element);
            app.AddController("change-season", new ChangeSeasonController(data));
            app.Controllers["change-season"].Handle(new Command("change-season -id 0 -sp -su"));
            Assert.That(element.Seasons, Is.EqualTo(new List<string>{"Spring", "Summer"}));

            app.Controllers["change-season"].Handle(new Command("change-season -id 0 -w"));
            Assert.That(element.Seasons, Is.EqualTo(new List<string> { "Winter" }));
        }

        [Test]
        public void TestChangeBrandController() {
            var element = new Accessory { Brand = "OldName" };
            data.Insert(element);
            app.AddController("change-brand", new ChangeBrandController(data));
            app.Controllers["change-brand"].Handle(new Command("change-season -id 0 -val New Brand"));
            Assert.That(data.Retrieve(element.Id).Brand, Is.EqualTo("New Brand"));
        }

        [Test]
        public void TestInvalidParameterKey() {
            var element = new Accessory { Name = "OldName" };
            data.Insert(element);
            
            app.AddController("change-name", new ChangeNameController(data));
            app.Controllers["change-name"].Handle(new Command("change-name -id 0 -val NewName -v"));
            Assert.That(data.Retrieve(0).Name, Is.EqualTo("OldName"));
        }
    }
}
