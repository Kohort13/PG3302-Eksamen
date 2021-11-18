using System.Collections.Generic;
using NUnit.Framework;
using Wardrobe_Program;

namespace UnitTests
{
    class ControllersTest
    {
        private Application _app;
        private MockDao _data;

        [SetUp]
        public void Setup() {
            _app = new Application();
            _data = new MockDao();
        }

        [Test]
        public void TestChangeSubtype() {
            _data.Insert(new Accessory());
            _app.AddController("change-subtype", new ChangeSubtypeController(_data));
            _app.Controllers["change-subtype"].Handle(new Command("change-subtype -id 0 -val A new subtype"));
            Assert.That(_data.Retrieve(0).Subtype, Is.EqualTo("A new subtype"));
        }

        [Test]
        public void TestChangePrice() {
            _data.Insert(new Accessory());
            _app.AddController("change-price", new ChangePriceController(_data));
            _app.Controllers["change-price"].Handle(new Command("change-price -id 0 -val 299.99"));
            Assert.That(_data.Retrieve(0).Price, Is.EqualTo(299.99).Within(0.01));
        }

        [Test]
        public void TestChangeSize() {
	        _data.Insert(new Accessory());
	        _app.AddController("change-size", new ChangeSizeController(_data));
	        _app.Controllers["change-size"].Handle(new Command("change-size -id 0 -val new-size"));
            Assert.That(_data.Retrieve(0).Size, Is.EqualTo("new-size"));
        }

        [Test]
        public void TestChangeSeason() {
            var element = new Accessory { Subtype = "An accessory" };
            _data.Insert(element);
            _app.AddController("change-season", new ChangeSeasonController(_data));
            _app.Controllers["change-season"].Handle(new Command("change-season -id 0 -sp -su"));
            Assert.That(element.Seasons, Is.EqualTo(new List<string>{"Spring", "Summer"}));

            _app.Controllers["change-season"].Handle(new Command("change-season -id 0 -wi"));
            Assert.That(element.Seasons, Is.EqualTo(new List<string> { "Winter" }));
        }

        [Test]
        public void TestChangeBrand() {
            var element = new Accessory { Brand = "OldName" };
            _data.Insert(element);
            _app.AddController("change-brand", new ChangeBrandController(_data));
            _app.Controllers["change-brand"].Handle(new Command("change-season -id 0 -val New Brand"));
            Assert.That(_data.Retrieve(element.Id).Brand, Is.EqualTo("New Brand"));
        }

        [Test]
        public void TestChangeNote()
        {
            _data.Insert(new Accessory());
            _app.AddController("change-note", new ChangeNoteController(_data));
            _app.Controllers["change-note"].Handle(new Command("change-note -id 0 -val newNote"));
            Assert.That(_data.Retrieve(0).Note, Is.EqualTo("newNote"));
        }

        
        [Test]
        public void TestDeleteGarment()
        {
            var element = new Bottom {Subtype = "Pantalones"};
            _data.Insert(element);
            _data.Insert(element);
            _data.Insert(element);
            _data.Insert(element);

            _app.AddController("delete-garment", new DeleteGarmentController(_data));
            _app.Controllers["delete-garment"].Handle(new Command("delete-garment -id 2"));
            Assert.That(_data.Retrieve(2), Is.Null);
        }

        [Test]
        public void TestAddMaterial() {
            var element = new Bottom { Subtype = "Jeans" };
            _data.Insert(element);
            _app.AddController("add-material", new AddMaterialController(_data));
            _app.Controllers["add-material"].Handle(new Command("add-material -id 0 -col 4 -sha 1 -fab denim"));
            Assert.That(_data.Retrieve(0).Materials[0].ToString(), Is.EqualTo(new Material{Colour = (Material.Colours) 4, Fabric = "denim", Shade = (Material.Shades)1}.ToString()));
        }

        [Test]
        public void TestDeleteMaterial() {
            var element = new Outerwear
            {
                Subtype = "Adult romper",
                Materials = new()
                {
                    new Material { Colour = (Material.Colours)4, Fabric = "denim", Shade = (Material.Shades)1 }
                }
            };
            _data.Insert(element);
            _app.AddController("delete-material", new DeleteMaterialController(_data));
            _app.Controllers["delete-material"].Handle(new Command("delete-material -id 0 -matId 0"));
            Assert.That(_data.Retrieve(0).Materials, Is.Empty);
        }
        
        [Test]
        public void TestInvalidParameterKey() {
            var element = new Accessory { Subtype = "Skirt" };
            _data.Insert(element);

            _app.AddController("change-subtype", new ChangeSubtypeController(_data));
            _app.Controllers["change-subtype"].Handle(new Command("change-subtype -id 0 -val Jeans -v"));
            Assert.That(_data.Retrieve(0).Subtype, Is.EqualTo("Skirt"));
        }
    }
}
