using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBell.WebApi.Produto
{
    interface IRepositorio
    {
        Produto Get(Guid id);
        IEnumerable<Produto> Get();
        void Set(Produto produto);
        void Delete(Guid id);
        void Update(Guid id, Produto produto);
    }
}
