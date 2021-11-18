using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;

namespace Wardrobe_Program
{
    /// <summary>
    /// An in-memory GarmentDao that can be used for testing/mocking
    /// </summary>
    public class MockDao : IDao<Garment>
    {
        public Garment Retrieve(long id) {
            return _data.Find(garment => garment.Id == id);
        }

        public List<Garment> ListAll() {
            return _data;
        }

        public void Insert(Garment element) {
            element.Id = GetNextId();
            _data.Add(element);
        }

        public void Update(long id, Garment element) {
            var garmentToUpdate = Retrieve(id);
            
            garmentToUpdate.Name = element.Name;
            garmentToUpdate.Seasons = element.Seasons;
            garmentToUpdate.Materials = element.Materials;
            garmentToUpdate.Brand = element.Brand;
            garmentToUpdate.Notes = element.Notes;
            garmentToUpdate.Price = element.Price;
            garmentToUpdate.Size = element.Size;
        }

        public static MockDao GetPopulatedTestDatabase() {
            MockDao data = new();
            for (int i = 0; i < 15; i++) {
                var seasons = new List<List<string>>
                {
                    new() { "Winter", "Spring" },
                    new() { "Summer", "Autumn" },
                    new() { "Summer" }
                };
                Accessory garment = new()
                {
                    Name = Utils.PickOne(new Collection<string> { "A name", "Another name", "Yet another name", "Bob" }),
                    Brand = Utils.PickOne(new Collection<string> { "Gucci", "D&G", "YSL", "Hugo Boss" }),
                    Price = Utils.PickOne(new Collection<float> { 99, 249, 899, 499 }),
                    Seasons = Utils.PickOne<List<string>>(new Collection<List<string>>(seasons))
                };
                data.Insert(garment);
            }
            return data;
        }

        private long GetNextId() {
            return _nextId++;
        }

        private long _nextId = 0;

        private readonly List<Garment> _data = new();
    }
}
