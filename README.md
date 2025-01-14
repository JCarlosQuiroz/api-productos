
# API de Productos

Esta API permite gestionar productos en un sistema de inventarios.

## Requisitos

- .NET Core 8
- SQLite

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/JCarlosQuiroz/api-productos.git
   cd api.productos
   ```
2. Restaura las dependencias:

   ```bash
   dotnet restore
   ```
3. Aplica las migraciones:

   ```bash
   dotnet ef database update
   ```
4. Ejecuta la aplicación:

   ```bash
   dotnet run
   ```

## Endpoints

### Obtener todos los productos

**Método**: `GET /api/Productos`

**Parámetros opcionales**:

- `nombre`: Filtra productos por nombre.
- `minPrecio`: Precio mínimo.
- `maxPrecio`: Precio máximo.

**Ejemplo de respuesta**:

```json
[
    {
        "id": 1,
        "nombre": "Producto A",
        "descripcion": "Descripción de prueba",
        "precio": 10.5,
        "cantidadEnStock": 100,
        "fechaDeCreacion": "2025-01-14T00:00:00"
    }
]

**Crear un producto**:
**Método: POST /api/Productos**

**Cuerpo del JSON**:

```json
{
    "nombre": "Nuevo Producto",
    "descripcion": "Descripción opcional",
    "precio": 20.99,
    "cantidadEnStock": 50
}
**Ejemplo de respuesta**:

```json

{
    "id": 3,
    "nombre": "Nuevo Producto",
    "descripcion": "Descripción opcional",
    "precio": 20.99,
    "cantidadEnStock": 50,
    "fechaDeCreacion": "2025-01-14T00:00:00"
}
```
