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

            var updatedPants = new Bottom { Name = "A new name", Id = 4664 };
            _dao.Update(pants.Id, updatedPants);

            Assert.AreNotEqual(pants.Id, updatedPants.Id);
            Assert.AreEqual(pants.Id, idBeforeUpdate);
            Assert.AreEqual(pants.Brand, updatedPants.Brand);
            Assert.AreEqual(pants.Materials, updatedPants.Materials);
            Assert.AreEqual(pants.Seasons, updatedPants.Seasons);
            Assert.AreEqual(pants.Price, updatedPants.Price);
            Assert.AreEqual(pants.Name, updatedPants.Name);
            Assert.AreEqual(pants.Notes, updatedPants.Notes);
            Assert.AreEqual(pants.Size, updatedPants.Size);
        }
    }
}
