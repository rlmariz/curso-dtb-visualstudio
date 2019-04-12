using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBelli.AcessoDados.Construtores;
using DataBelli.AcessoDados.Executores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DataBell.WebApi.Produto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IServiceProvider provider;
        private readonly IOptions<DataBase> dataBaseSettings;

        public ProdutoController(IServiceProvider provider, IOptions<DataBase> dataBaseSettings)
        {
            this.provider = provider;
            this.dataBaseSettings = dataBaseSettings;
            //var connecton = this.dataBaseSettings.Value.ConnectionString;
        }

        // GET: api/Produto
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            var builder = (IQueryBuilder<Produto>)this.provider.GetService(typeof(IQueryBuilder<Produto>));
            var queryExec = (IQueryExec<Produto>)this.provider.GetService(typeof(IQueryExec<Produto>));
            return queryExec.Select("");
        }

        // GET: api/Produto/5
        [HttpGet("{id}", Name = "Get")]
        public Produto Get(Guid id)
        {
            var repositorio = (IRepositorio)this.provider.GetService(typeof(IRepositorio));

            return repositorio.Get(id);
        }

        // POST: api/Produto
        [HttpPost]
        public void Post([FromBody] Produto value)
        {
            //var repositorio = (IRepositorio)this.provider.GetService(typeof(IRepositorio));
            //repositorio.Set(value);
            var builder = (IQueryBuilder<Produto>)this.provider.GetService(typeof(IQueryBuilder<Produto>));
            var queryExec = (IQueryExec<Produto>)this.provider.GetService(typeof(IQueryExec<Produto>));
            queryExec.Insert(value);
        }

        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Produto value)
        {
            var repositorio = (IRepositorio)this.provider.GetService(typeof(IRepositorio));

            repositorio.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var repositorio = (IRepositorio)this.provider.GetService(typeof(IRepositorio));

            repositorio.Delete(id);
        }
    }
}
