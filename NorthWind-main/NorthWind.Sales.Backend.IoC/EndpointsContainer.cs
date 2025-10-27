
namespace Microsoft.AspNetCore.Builder;
public static class EndpointsContainer
{
    public static WebApplication MapNorthWindSalesEndpoints(
   this WebApplication app)
    {
        app.UseCreateOrderController();
        app.UseCreateProductController();
        app.UseUpdateProductController();
        app.UseDeleteProductController();
        app.UseGetProductByIdController();
        app.UseMembershipEndpoints();

        return app;
    }
}
