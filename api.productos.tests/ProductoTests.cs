using Api.Productos.Models;
using System.ComponentModel.DataAnnotations;

public class ProductoTests
{
    [Fact]
    public void Producto_Nombre_Corto_Valida_Error()
    {
        var producto = new Producto { Nombre = "AB", Precio = 10, CantidadEnStock = 5 };
        var context = new ValidationContext(producto, null, null);
        var result = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(producto, context, result, true);
        Assert.False(isValid);
        Assert.Contains(result, v => v.ErrorMessage.Contains("The field Nombre must be a string with a minimum length of 3"));
    }

    [Fact]
    public void Producto_Precio_Negativo_No_Valido()
    {
        var producto = new Producto { Nombre = "Producto Prueba", Precio = -1, CantidadEnStock = 10 };
        var context = new ValidationContext(producto, null, null);
        var result = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(producto, context, result, true);
        Assert.False(isValid);
        Assert.Contains(result, v => v.ErrorMessage.Contains("The field Precio must be between"));
    }

    [Fact]
public void Producto_CantidadEnStock_Negativa_No_Valida()
{
    var producto = new Producto { Nombre = "Producto Stock", Precio = 10, CantidadEnStock = -5 };
    var context = new ValidationContext(producto, null, null);
    var result = new List<ValidationResult>();

    var isValid = Validator.TryValidateObject(producto, context, result, true);
    Assert.False(isValid);
    Assert.Contains(result, v => v.ErrorMessage.Contains("The field CantidadEnStock must be greater than or equal to 0"));
}
}