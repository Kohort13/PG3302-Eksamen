using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class MockDatabase : IDao<Garment>
    {
        private readonly List<Garment> _data = new List<Garment>();
        public Garment Retrieve(long id) {
            return _data[(Index)id];
        }

        public List<Garment> ListAll() {
            return _data;
        }

        public void Insert(Garment element) {
            _data.Add(element);
        }

        public void Update(long id, Garment element) {
            _data[(Index)id] = element;
        }
    }
}
