using NorthWind.Sales.Backend.DataContexts.EFCore.Configurations;
using NorthWind.Sales.Backend.Repositories.Entities;

namespace NorthWind.Sales.Backend.DataContexts.EFCore.DataContexts
{
    internal class NorthWindDomainLogsContext : DbContext
    {
        // Constructor existente...
        public NorthWindDomainLogsContext(DbContextOptions<NorthWindDomainLogsContext> options) : base(options) { }

        public DbSet<DomainLog> DomainLogs { get; set; }

        // NUEVO DBSETA
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ERROR COMÚN:
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // ^ Esto carga TODAS las configuraciones (Orders, Products, etc.), lo cual NO queremos aquí.

            // SOLUCIÓN:
            // Aplicar explícitamente SOLO las configuraciones que pertenecen a este contexto.

            // 1. Configuración de ErrorLogs (tienes el archivo ErrorLogConfiguration)
            modelBuilder.ApplyConfiguration(new ErrorLogConfiguration());

            // 2. Configuración de DomainLogs
            // Si no tienes una clase "DomainLogConfiguration" separada y usas convenciones por defecto, 
            // Entity Framework configurará la tabla basándose en la clase DomainLog automáticamente.
        }
    }
}
