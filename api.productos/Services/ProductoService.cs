using Api.Productos.Data;
using Api.Productos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Productos.Services
{
    public class ProductoService(ApplicationDbContext context) : IProductoService
    {
        private readonly ApplicationDbContext _context = context;

        /// <inheritdoc/>
        public async Task<List<Producto>> GetProductosAsync(string? nombre, decimal? minPrecio, decimal? maxPrecio)
        {
            var query = _context.Productos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
                query = query.Where(p => p.Nombre.Contains(nombre));

            if (minPrecio.HasValue)
                query = query.Where(p => p.Precio >= minPrecio);

            if (maxPrecio.HasValue)
                query = query.Where(p => p.Precio <= maxPrecio);

            return await query.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            return producto;  // Correcto, puede retornar null si no se encuentra
        }

        /// <inheritdoc/>
        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        /// <inheritdoc/>
        public async Task<Producto?> UpdateProductoAsync(int id, Producto producto)
        {
            var existingProducto = await _context.Productos.FindAsync(id);
            if (existingProducto == null)
                return null; // Indica que el producto no existe

            existingProducto.Nombre = producto.Nombre;
            existingProducto.Descripcion = producto.Descripcion;
            existingProducto.Precio = producto.Precio;
            existingProducto.CantidadEnStock = producto.CantidadEnStock;

            await _context.SaveChangesAsync();
            return existingProducto;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}