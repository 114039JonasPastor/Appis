using ApiProductos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private List<Productos> lista = Productos.ObtenerInstancia();
        // GET: api/<ProductosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lista);
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            foreach(Productos p in lista)
            {
                if(p.Codigo == id)
                {
                    return Ok(p);
                }
            }
            return NotFound($"{id} No registrada!");
        }

        // POST api/<ProductosController>
        [HttpPost]
        public IActionResult Post([FromBody] Productos producto)
        {
            if(producto == null && !(producto is Productos))
            {
                return BadRequest();
            }
            lista.Add(producto);
            return Ok("Se registro el producto");
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Productos producto)
        {
            foreach (Productos p in lista)
            {
                if (p.Codigo == id)
                {
                    p.Nombre = producto.Nombre;
                    p.Precio = producto.Precio;
                    return Ok(producto);
                }
            }
            return BadRequest();
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{cod}")]
        public IActionResult Delete(int cod)
        {
            foreach(Productos p in lista)
            {
                if(p.Codigo > lista.Count)
                {
                    BadRequest("Numero de codigo erroneo");
                }
                else if(cod == p.Codigo)
                {
                    lista.RemoveAt(p.Codigo);
                    return Ok("Se removio el producto con exito");
                }
            }
            return BadRequest("Numero de codigo erroneo");
        }
    }
}
