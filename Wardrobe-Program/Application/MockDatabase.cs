using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe_Program
{
    public class MockDatabase : IDao<Garment>
    {
        private List<Garment> _data = new List<Garment>();
        public Garment Retrieve(int id) {
            return _data[id];
        }

        public List<Garment> ListAll() {
            throw new NotImplementedException();
        }

        public void Insert(Garment element) {
            _data.Add(element);
        }

        public void Update(int id, Garment element) {
            throw new NotImplementedException();
        }
    }
}
