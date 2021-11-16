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
            Assert.IsInstanceOf(typeof(Bottom), bottom);
            Assert.IsInstanceOf(typeof(Shoe), shoe);
            Assert.IsInstanceOf(typeof(Accessory), accessory);
            Assert.IsInstanceOf(typeof(Outerwear), outerwear);
        }
    }
}
