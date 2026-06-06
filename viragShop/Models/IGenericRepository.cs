using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viragShop.Models
{
    internal interface IGenericRepository<T> where T : new()
    {
        List<T> GetAll();
        void insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
