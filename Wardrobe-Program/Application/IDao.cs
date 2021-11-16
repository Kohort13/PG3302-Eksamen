using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe_Program
{
    public interface IDao<T>
    {
        public T Retrieve(int id);
        public List<T> ListAll();
        public void Insert(T element);
        public void Update(int id, T element);
    }
}
