using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBelli.AcessoDados.Executores;

namespace DataBell.WebApi.Produto
{
    public class Repositorio : IRepositorio
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
            
        }

        public Produto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Get()
        {
            throw new NotImplementedException();
        }

        public void Set(Produto produto)
        {
            //var queryExec QueryExec<Produto>
            throw new NotImplementedException();
        }

        public void Update(Guid id, Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
