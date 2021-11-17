using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class MockDatabase : IDao<Garment>
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

        private long GetNextId() {
            return _nextId++;
        }

        private long _nextId = -1;

        private readonly List<Garment> _data = new();
    }
}
