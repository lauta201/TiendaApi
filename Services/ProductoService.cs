using TiendaApi.DTOs;
using TiendaApi.Models;
using TiendaApi.Repositories;

namespace TiendaApi.Services
{
    public class ProductoService : IProductoService
    {
        private IProductoRepository repository;

        public ProductoService(IProductoRepository repository)
        {
            this.repository = repository;
        }

        public List<ProductoDto> ObtenerTodos()
        {
            var productos = repository.ObtenerTodos();

            // paso cada Producto a ProductoDto
            var lista = new List<ProductoDto>();
            foreach (var p in productos)
            {
                lista.Add(ConvertirADto(p));
            }
            return lista;
        }

        public ProductoDto ObtenerPorId(int id)
        {
            var producto = repository.ObtenerPorId(id);
            if (producto == null)
            {
                return null;
            }
            return ConvertirADto(producto);
        }

        public ProductoDto Crear(CreateProductoDto dto)
        {
            Producto producto = new Producto();
            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio.Value;
            producto.Categoria = dto.Categoria;
            producto.Activo = true;

            repository.Agregar(producto);

            return ConvertirADto(producto);
        }

        public bool Actualizar(int id, CreateProductoDto dto)
        {
            var producto = repository.ObtenerPorId(id);
            if (producto == null)
            {
                return false;
            }

            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio.Value;
            producto.Categoria = dto.Categoria;

            return repository.Actualizar(producto);
        }

        public bool Eliminar(int id)
        {
            return repository.Eliminar(id);
        }

        // metodo para pasar de entidad a dto
        private ProductoDto ConvertirADto(Producto p)
        {
            ProductoDto dto = new ProductoDto();
            dto.Id = p.Id;
            dto.Nombre = p.Nombre;
            dto.Precio = p.Precio;
            dto.Categoria = p.Categoria;
            dto.Activo = p.Activo;
            return dto;
        }
    }
}
