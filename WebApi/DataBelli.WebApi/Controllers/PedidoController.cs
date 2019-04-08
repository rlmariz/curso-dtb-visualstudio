using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBelli.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataBelli.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        IRepositorio repositorio;

        //public PedidoController(IRepositorio repositorio)
        //{
        //    this.repositorio = repositorio;
        //}

        public PedidoController()
        {
            this.repositorio = repositorio;
        }

        // GET: api/Pedido
        [HttpGet]
        public IEnumerable<PedidoModel> Get()
        {
            var pedidos = new List<PedidoModel>
            {
                new PedidoModel
                {
                    Data = DateTime.Now,
                    Numero = Guid.NewGuid().ToString(),
                    QuantidadeItens = 10,
                    Obsevacoes = "Obs 1"
                },
                new PedidoModel
                {
                    Data = DateTime.Now.AddDays(-25),
                    Numero = Guid.NewGuid().ToString(),
                    QuantidadeItens = 48,
                    Obsevacoes = "Obs 2"
                }
            };
            return pedidos;
        }

        // GET: api/Pedido/5
        [HttpGet]
        [Route("{id:max(10)}")]
        public PedidoModel Get(int id)
        {
            var pedido = new PedidoModel
            {
                Data = DateTime.Now,
                Numero = Guid.NewGuid().ToString(),
                QuantidadeItens = 10,
                Obsevacoes = "Obs Pedido"
            };

            return pedido;
        }

        // POST: api/Pedido
        [HttpPost]
        public void Post([FromBody] PedidoModel value)
        {
        }

        // PUT: api/Pedido/5
        [HttpPut("{id}")]  
        public void Put(int id, [FromBody] PedidoModel value)
        {
            System.Diagnostics.Debugger.Break();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            System.Diagnostics.Debugger.Break();
        }
    }
}
