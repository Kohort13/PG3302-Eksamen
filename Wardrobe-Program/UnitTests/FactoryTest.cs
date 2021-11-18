using NUnit.Framework;
using Wardrobe_Program;

namespace UnitTests
{
    class FactoryTest
    {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestReturnTypes() {
            TopFactory topFactory = new();
            BottomFactory bottomFactory = new();
            ShoeFactory shoeFactory = new();
            AccessoryFactory accessoryFactory = new();
            OuterwearFactory outerwearFactory = new();

            Garment top = topFactory.CreateGarment();
            Garment bottom = bottomFactory.CreateGarment();
            Garment shoe = shoeFactory.CreateGarment();
            Garment accessory = accessoryFactory.CreateGarment();
            Garment outerwear = outerwearFactory.CreateGarment();

            Assert.IsInstanceOf(typeof(Top), top);
            Assert.That(topFactory.GarmentType, Is.EqualTo("Top"));
            Assert.IsInstanceOf(typeof(Bottom), bottom);
            Assert.That(bottomFactory.GarmentType, Is.EqualTo("Bottom"));
            Assert.IsInstanceOf(typeof(Shoe), shoe);
            Assert.That(shoeFactory.GarmentType, Is.EqualTo("Shoe"));
            Assert.IsInstanceOf(typeof(Accessory), accessory);
            Assert.That(accessoryFactory.GarmentType, Is.EqualTo("Accessory"));
            Assert.IsInstanceOf(typeof(Outerwear), outerwear);
            Assert.That(outerwearFactory.GarmentType, Is.EqualTo("Outerwear"));
        }
    }
}
