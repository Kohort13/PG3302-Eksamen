using NUnit.Framework;
using Wardrobe_Program;

namespace UnitTests
{
    class MockDatabaseTest
    {
        private MockDao _dao;
        [SetUp]
        public void Setup() {
            _dao = new();
        }

        [Test]
        public void TestUpdate() {
            var shoe = new Shoe();
            var pants = new Bottom();
            _dao.Insert(shoe);
            _dao.Insert(pants);
            var idBeforeUpdate = pants.Id;

            var updatedPants = new Bottom { Subtype = "A new name", Id = 4664 };
            _dao.Update(pants.Id, updatedPants);

            Assert.AreNotEqual(pants.Id, updatedPants.Id);
            Assert.AreEqual(pants.Id, idBeforeUpdate);
            Assert.AreEqual(pants.Brand, updatedPants.Brand);
            Assert.AreEqual(pants.Materials, updatedPants.Materials);
            Assert.AreEqual(pants.Seasons, updatedPants.Seasons);
            Assert.AreEqual(pants.Price, updatedPants.Price);
            Assert.AreEqual(pants.Subtype, updatedPants.Subtype);
            Assert.AreEqual(pants.Note, updatedPants.Note);
            Assert.AreEqual(pants.Size, updatedPants.Size);
        }

        [Test]
        public void TestRetrieve() {
            var shoe = new Shoe {Subtype = "Shoes", Price = 99.5f};
            var pants = new Bottom {Subtype = "Pants", Price = 499.0f};

            _dao.Insert(shoe);
            _dao.Insert(pants);
            Assert.That(shoe.Id, Is.EqualTo(0));
            Assert.That(pants.Id, Is.EqualTo(1));
            Assert.That(_dao.Retrieve(0), Is.EqualTo(shoe));
            Assert.That(_dao.Retrieve(1), Is.EqualTo(pants));
        }
    }
}
