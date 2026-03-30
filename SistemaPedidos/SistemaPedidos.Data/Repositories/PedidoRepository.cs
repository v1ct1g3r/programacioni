using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using SistemaPedidos.Core.Interfaces;
using SistemaPedidos.Core.Models;

namespace SistemaPedidos.Data.Repositories;

/// <summary>
/// Repositorio para la entidad Pedido
/// Utiliza EF Core para CRUD y Dapper para reportes complejos
/// </summary>
public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> ObtenerTodosAsync()
    {
        return await _context.Pedidos
            .Include(p => p.ItemsNavigation)
                .ThenInclude(i => i.Producto)
            .ToListAsync();
    }

    public async Task<Pedido?> ObtenerPorIdAsync(int id)
    {
        return await _context.Pedidos
            .Include(p => p.ItemsNavigation)
                .ThenInclude(i => i.Producto)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> CrearAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido.Id;
    }

    public async Task ActualizarAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var pedido = await ObtenerPorIdAsync(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Obtiene un resumen de pedidos usando Dapper
    /// Realiza un JOIN entre Pedidos e ItemsPedidos
    /// </summary>
    public async Task<List<PedidoResumenDTO>> ObtenerResumenAsync()
    {
        using var connection = _context.Database.GetDbConnection();
        
        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync();

        var sql = @"
            SELECT 
                p.Id as PedidoId,
                p.FechaPedido,
                p.Total,
                COUNT(ip.Id) as CantidadProductos,
                p.TipoPago
            FROM Pedidos p
            LEFT JOIN ItemsPedidos ip ON p.Id = ip.PedidoId
            GROUP BY p.Id, p.FechaPedido, p.Total, p.TipoPago
            ORDER BY p.FechaPedido DESC
        ";

        var resumen = (await connection.QueryAsync<PedidoResumenDTO>(sql)).ToList();
        return resumen;
    }
}
