using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.Core.Interfaces;
using SistemaPedidos.Core.Models;
using SistemaPedidos.Core.Pagos;
using SistemaPedidos.Core.Servicios;
using SistemaPedidos.Web.ViewModels;

namespace SistemaPedidos.Web.Controllers;

public class PedidosController : Controller
{
    private readonly IPedidoService _pedidoService;
    private readonly IProductoService _productoService;

    public PedidosController(IPedidoService pedidoService, IProductoService productoService)
    {
        _pedidoService = pedidoService;
        _productoService = productoService;
    }

    // GET: Pedidos
    public async Task<IActionResult> Index()
    {
        var resumen = await _pedidoService.ObtenerResumenAsync();
        return View(resumen);
    }

    // GET: Pedidos/Crear
    public async Task<IActionResult> Crear()
    {
        var productos = await _productoService.ObtenerTodosAsync();
        ViewBag.Productos = productos;
        return View();
    }

    // POST: Pedidos/Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(CrearPedidoVM vm)
    {
        if (!ModelState.IsValid || vm.ProductosSeleccionados.Count == 0)
        {
            TempData["Error"] = "Debe seleccionar al menos un producto";
            var productos = await _productoService.ObtenerTodosAsync();
            ViewBag.Productos = productos;
            return View(vm);
        }

        try
        {
            var pedido = new Pedido
            {
                FechaPedido = DateTime.Now,
                TipoPago = vm.TipoPago
            };

            // Agregar items al pedido
            foreach (var productoId in vm.ProductosSeleccionados)
            {
                var producto = await _productoService.ObtenerPorIdAsync(productoId);
                if (producto != null && vm.Cantidades.TryGetValue(productoId, out var cantidad) && cantidad > 0)
                {
                    pedido.AgregarItem(producto, cantidad);
                }
            }

            if (pedido.Items.Count == 0)
            {
                TempData["Error"] = "El pedido debe tener al menos un producto con cantidad válida";
                var productos = await _productoService.ObtenerTodosAsync();
                ViewBag.Productos = productos;
                return View(vm);
            }

            // Procesar pago
            var estrategiaPago = PagoFactory.Crear(vm.TipoPago);
            pedido.CalcularTotal();

            if (!estrategiaPago.Procesar(pedido.Total, out string mensajePago))
            {
                TempData["Error"] = $"Error en el pago: {mensajePago}";
                var productos = await _productoService.ObtenerTodosAsync();
                ViewBag.Productos = productos;
                return View(vm);
            }

            // Cambiar estado a procesado
            pedido.SetEstado(EstadoPedido.Procesado);

            // Guardar en BD
            var pedidoId = await _pedidoService.CrearAsync(pedido);

            TempData["Mensaje"] = $"Pedido creado exitosamente. {mensajePago}";
            return RedirectToAction(nameof(Detalle), new { id = pedidoId });
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al crear pedido: {ex.Message}";
            var productos = await _productoService.ObtenerTodosAsync();
            ViewBag.Productos = productos;
            return View(vm);
        }
    }

    // GET: Pedidos/Detalle/5
    public async Task<IActionResult> Detalle(int id)
    {
        var pedido = await _pedidoService.ObtenerPorIdAsync(id);
        if (pedido == null)
        {
            TempData["Error"] = "Pedido no encontrado";
            return RedirectToAction(nameof(Index));
        }

        return View(pedido);
    }
}
