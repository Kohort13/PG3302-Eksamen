using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public interface IDao<T>
    {
        public T Retrieve(long id);
        public List<T> ListAll();
        public List<T> ListSome(params Predicate<Garment>[] matchers);

        public void Insert(T element);
        public void Update(long id, T element);
        public void Delete(long id);
    }
}
