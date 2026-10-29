using Microsoft.AspNetCore.Mvc;
using TiendaApi.DTOs;
using TiendaApi.Services;

namespace TiendaApi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private IProductoService service;

        public ProductosController(IProductoService service)
        {
            this.service = service;
        }

        // GET api/productos
        [HttpGet]
        public IActionResult GetAll()
        {
            var productos = service.ObtenerTodos();
            return Ok(productos);
        }

        // GET api/productos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var producto = service.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        // POST api/productos
        [HttpPost]
        public IActionResult Create(CreateProductoDto dto)
        {
            // con [ApiController] si el dto no es valido ya devuelve 400 solo,
            // pero lo dejo por las dudas
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creado = service.Crear(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        // PUT api/productos/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateProductoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool actualizado = service.Actualizar(id, dto);
            if (!actualizado)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/productos/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool eliminado = service.Eliminar(id);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
