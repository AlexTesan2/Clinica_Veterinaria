using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Clinica_Veterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clinica_Veterinaria.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 
        }

        public DbSet<AnimalModel> Animales { get; set; }
        public DbSet<AnimalCapaModel> AnimalesCapas { get; set; }
        public DbSet<CapaModel> Capas { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }
        public DbSet<ProductoModel> Productos { get; set; }
        public DbSet<ConsultaProductoModel> ConsultaProductos { get; set; }
        public DbSet<EspecieModel> Especies { get; set; }
        public DbSet<RazaModel> Razas { get; set; }
        public DbSet<ProvinciaModel> Provincias { get; set; }
        public DbSet<TipoConsultaModel> TipoConsultas { get; set; }
        public DbSet<TipoPeloModel> TipoPelos { get; set; }
        public DbSet<TipoProductoModelo> TipoProductos { get; set; }


    }
}
