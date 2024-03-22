using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymHyR.Data;
using GymHyR.Models;
using GymHyR.Services;
using Library;

namespace GymHyR.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoesController(ProductosServices productosServices) : ControllerBase
{
    // GET: api/Productoes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
    {
        var prop = await productosServices.GetProductos();
        return Ok(prop);
    }

    // GET: api/Productoes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        return await productosServices.GetProducto(id);
    }

    // PUT: api/Productoes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, Producto producto)
    {
        return await productosServices.PutProducto(id, producto);
    }

    // POST: api/Productoes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            var productoSave = await productosServices.PostProducto(producto);
            return Ok(productoSave);
        }
    // DELETE: api/Productoes/5
    [HttpDelete("{id}")]
    public async Task<bool> DeleteProducto(Producto producto)
    {
        return await productosServices.DeleteProducto(producto);
    }

    private bool ProductoExists(int id)
    {
        return productosServices.ProductoExists(id);
    }
}
