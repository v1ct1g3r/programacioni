using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Core.Interfaces;
using SistemaPedidos.Core.Models;
using SistemaPedidos.Core.Servicios;
using SistemaPedidos.Web.ViewModels;

namespace SistemaPedidos.Web.Controllers;

public class ProductosController : Controller
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    // GET: Productos
    public async Task<IActionResult> Index()
    {
        var productos = await _productoService.ObtenerTodosAsync();
        return View(productos);
    }

    // GET: Productos/Crear
    public IActionResult Crear()
    {
        return View();
    }

    // POST: Productos/Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(CrearProductoVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        try
        {
            Producto producto = vm.Tipo == "Digital"
                ? new ProductoDigital
                {
                    Nombre = vm.Nombre,
                    Precio = vm.Precio,
                    Stock = vm.Stock,
                    UrlDescarga = vm.UrlDescarga
                }
                : new ProductoFisico
                {
                    Nombre = vm.Nombre,
                    Precio = vm.Precio,
                    Stock = vm.Stock,
                    PesoKg = vm.PesoKg
                };

            await _productoService.CrearAsync(producto);
            TempData["Mensaje"] = "Producto creado exitosamente";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al crear producto: {ex.Message}";
            return View(vm);
        }
    }
}
