using System.ComponentModel.DataAnnotations;

namespace Api.Productos.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public required string Nombre { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Range(0.01, double.MaxValue)]
        public required decimal Precio { get; set; }

        [Range(0, int.MaxValue)]
        public required int CantidadEnStock { get; set; }

        public DateTime FechaDeCreacion { get; set; } = DateTime.Now;
    }
}
