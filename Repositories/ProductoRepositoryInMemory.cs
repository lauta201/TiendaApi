using TiendaApi.Models;

namespace TiendaApi.Repositories
{
    public class ProductoRepositoryInMemory : IProductoRepository
    {
        private List<Producto> productos = new List<Producto>();

        public ProductoRepositoryInMemory()
        {
            // datos de prueba
            productos.Add(new Producto { Id = 1, Nombre = "Laptop", Precio = 850000, Categoria = "Tecnologia", Activo = true });
            productos.Add(new Producto { Id = 2, Nombre = "Mouse", Precio = 15000, Categoria = "Tecnologia", Activo = true });
            productos.Add(new Producto { Id = 3, Nombre = "Silla", Precio = 120000, Categoria = "Muebles", Activo = true });
            productos.Add(new Producto { Id = 4, Nombre = "Escritorio", Precio = 200000, Categoria = "Muebles", Activo = false });
        }

        public List<Producto> ObtenerTodos()
        {
            return productos.ToList();
        }

        public Producto ObtenerPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {
            // el id nuevo es el mayor que hay + 1
            int nuevoId = 1;
            if (productos.Count > 0)
            {
                nuevoId = productos.Max(p => p.Id) + 1;
            }
            producto.Id = nuevoId;
            productos.Add(producto);
        }

        public bool Actualizar(Producto producto)
        {
            var existente = productos.FirstOrDefault(p => p.Id == producto.Id);
            if (existente == null)
            {
                return false;
            }

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Categoria = producto.Categoria;
            existente.Activo = producto.Activo;
            return true;
        }

        public bool Eliminar(int id)
        {
            var existente = productos.FirstOrDefault(p => p.Id == id);
            if (existente == null)
            {
                return false;
            }

            productos.Remove(existente);
            return true;
        }
    }
}
