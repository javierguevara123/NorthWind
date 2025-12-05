using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Sales.Backend.DataContexts.EFCore.DataContexts
{
    internal class NorthWindDomainLogsContextFactory : IDesignTimeDbContextFactory<NorthWindDomainLogsContext>
    {
        public NorthWindDomainLogsContext CreateDbContext(string[] args)
        {
            // OPCIÓN DIRECTA: 
            // Escribir la cadena de conexión aquí directamente (Hardcoded).
            // Esto soluciona el error de "file not found" inmediatamente para las migraciones.

            var connectionString = "Data Source=JAVIER;Initial Catalog=NorthWindLogsDB;Integrated Security=True;Trust Server Certificate=True";

            // 3. Construir las opciones del DbContext
            var optionsBuilder = new DbContextOptionsBuilder<NorthWindDomainLogsContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // 4. Crear el contexto pasando las opciones correctas
            return new NorthWindDomainLogsContext(optionsBuilder.Options);
        }
    }
}