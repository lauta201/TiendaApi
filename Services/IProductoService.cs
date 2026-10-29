using TiendaApi.DTOs;

namespace TiendaApi.Services
{
    public interface IProductoService
    {
        List<ProductoDto> ObtenerTodos();
        ProductoDto ObtenerPorId(int id);
        ProductoDto Crear(CreateProductoDto dto);
        bool Actualizar(int id, CreateProductoDto dto);
        bool Eliminar(int id);
    }
}
