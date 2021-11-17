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
            garmentToUpdate = element;
        }

        private long GetNextId() {
            return _nextId++;
        }

        private long _nextId = -1;

        private readonly List<Garment> _data = new();
    }
}
