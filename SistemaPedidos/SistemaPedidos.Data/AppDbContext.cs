using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Core.Models;

namespace SistemaPedidos.Data;

public class AppDbContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItemsPedidos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Configuración de Herencia para Productos
        modelBuilder.Entity<Producto>()
            .HasDiscriminator<string>("TipoProducto")
            .HasValue<ProductoFisico>("Fisico")
            .HasValue<ProductoDigital>("Digital");

        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ProductoFisico>()
            .Property(p => p.PesoKg)
            .HasColumnType("decimal(18,2)");

        // 2. Configuración de Pedido
        modelBuilder.Entity<Pedido>()
            .Property(p => p.Total)
            .HasColumnType("decimal(18,2)");

        // CRÍTICO: Ignorar la propiedad de solo lectura para evitar el PedidoId1
        modelBuilder.Entity<Pedido>().Ignore(p => p.Items);

        // 3. Configuración de ItemPedido (Relación Muchos a Muchos)
        modelBuilder.Entity<ItemPedido>()
            .HasKey(ip => ip.Id);

        modelBuilder.Entity<ItemPedido>()
            .Property(ip => ip.PrecioUnitario)
            .HasColumnType("decimal(18,2)");

        // Configuración explícita de la relación con Pedido
        modelBuilder.Entity<ItemPedido>()
            .HasOne(ip => ip.Pedido)
            .WithMany(p => p.ItemsNavigation) // Usamos explícitamente la lista interna
            .HasForeignKey(ip => ip.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(ip => ip.Producto)
            .WithMany()
            .HasForeignKey(ip => ip.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);

        // 4. Seed Data (Datos iniciales)
        modelBuilder.Entity<ProductoFisico>().HasData(
            new ProductoFisico { Id = 1, Nombre = "Laptop Dell XPS", Precio = 1200.00m, Stock = 5, PesoKg = 2.5m },
            new ProductoFisico { Id = 2, Nombre = "Mouse Logitech", Precio = 30.00m, Stock = 50, PesoKg = 0.1m }
        );

        modelBuilder.Entity<ProductoDigital>().HasData(
            new ProductoDigital { Id = 3, Nombre = "Software Visual Studio Professional", Precio = 499.99m, Stock = 999, UrlDescarga = "https://download.microsoft.com/vspr" }
        );
    }
}