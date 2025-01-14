using Api.Productos.Models;
using Api.Productos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Productos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        /// <summary>
        /// Obtiene una lista de productos con filtros opcionales.
        /// </summary>
        /// <param name="nombre">Nombre del producto (opcional).</param>
        /// <param name="minPrecio">Precio mínimo del producto (opcional).</param>
        /// <param name="maxPrecio">Precio máximo del producto (opcional).</param>
        /// <returns>Lista de productos filtrados.</returns>
        /// <response code="200">Lista de productos devuelta exitosamente.</response>
        [HttpGet]
        public async Task<IActionResult> GetProductos([FromQuery] string? nombre, [FromQuery] decimal? minPrecio, [FromQuery] decimal? maxPrecio)
        {
            var productos = await _productoService.GetProductosAsync(nombre, minPrecio, maxPrecio);
            return Ok(productos);
        }

        /// <summary>
        /// Obtiene un producto específico por su ID.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Detalles del producto.</returns>
        /// <response code="200">Producto encontrado exitosamente.</response>
        /// <response code="404">Producto no encontrado.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
                return NotFound();
            return Ok(producto);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="producto">Detalles del producto a crear.</param>
        /// <returns>El producto creado.</returns>
        /// <response code="201">Producto creado exitosamente.</response>
        /// <response code="400">Datos inválidos.</response>
        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProducto = await _productoService.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = createdProducto.Id }, createdProducto);
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">ID del producto a actualizar.</param>
        /// <param name="producto">Detalles actualizados del producto.</param>
        /// <returns>Producto actualizado.</returns>
        /// <response code="200">Producto actualizado exitosamente.</response>
        /// <response code="400">Datos inválidos o IDs no coinciden.</response>
        /// <response code="404">Producto no encontrado.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedProducto = await _productoService.UpdateProductoAsync(id, producto);
            if (updatedProducto == null)
                return NotFound();

            return Ok(updatedProducto);
        }

        /// <summary>
        /// Elimina un producto existente.
        /// </summary>
        /// <param name="id">ID del producto a eliminar.</param>
        /// <returns>Respuesta vacía si se elimina exitosamente.</returns>
        /// <response code="204">Producto eliminado exitosamente.</response>
        /// <response code="404">Producto no encontrado.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var success = await _productoService.DeleteProductoAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
