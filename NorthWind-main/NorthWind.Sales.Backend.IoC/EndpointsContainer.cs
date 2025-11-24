
namespace Microsoft.AspNetCore.Builder;
public static class EndpointsContainer
{
    public static WebApplication MapNorthWindSalesEndpoints(
   this WebApplication app)
    {
        app.UseCreateOrderController();
        app.UseMembershipEndpoints();
        app.UseProductsController();
        app.UseCustomersController();

        return app;
    }
}
