using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBelli.AcessoDados.Construtores;
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
            //var repositorio = (IRepositorio)this.provider.GetService(typeof(IRepositorio));
            //var builder = new (MsSqlServerQueryBuilder<Produto>)this.provider.GetService(typeof(MsSqlServerQueryBuilder<Produto>));
            //MsSqlServerQueryBuilder<Produto>();
            //var queryExec = new QueryExec<Produto>(builder);
            //return queryExec.Select("Where Id=" + id.ToString().);
            return null;
        }

        public IEnumerable<Produto> Get()
        {
            //var builder = new MsSqlServerQueryBuilder<Produto>();
            //var queryExec = new QueryExec<Produto>(builder);
            //return queryExec.Select("1=1");
            throw new NotImplementedException();
        }

        public void Set(Produto produto)
        {
            //var builder = new MsSqlServerQueryBuilder<Produto>();
            //var queryExec = new QueryExec<Produto>(builder);
            //queryExec.Insert(produto);
            throw new NotImplementedException();
        }

        public void Update(Guid id, Produto produto)
        {
            //var builder = new MsSqlServerQueryBuilder<Produto>();
            //var queryExec = new QueryExec<Produto>(builder);
            throw new NotImplementedException();
        }
    }
}
