using Api.Productos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Productos.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetProductosAsync(string? nombre, decimal? minPrecio, decimal? maxPrecio);
        Task<Producto?> GetProductoByIdAsync(int id);  // Correcto, puede retornar null
        Task<Producto> CreateProductoAsync(Producto producto);
        Task<Producto?> UpdateProductoAsync(int id, Producto producto); // También permite null
        Task<bool> DeleteProductoAsync(int id);
    }
}
