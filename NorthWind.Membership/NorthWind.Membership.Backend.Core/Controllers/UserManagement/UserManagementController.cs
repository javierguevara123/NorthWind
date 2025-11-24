using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NorthWind.Membership.Backend.Core.Interfaces.UserManagement;
using NorthWind.Membership.Entities.Dtos.UserManagement;
using NorthWind.Membership.Entities.ValueObjects;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Builder;
internal static class UserManagementController
{
    public static WebApplication UseUserManagementController(this WebApplication app)
    {
        // GET: Obtener todos los usuarios (Solo Admin y SuperUser)
        app.MapGet(Endpoints.GetAllUsers,
            [Authorize(Roles = "Administrator,SuperUser")]
        async (IGetAllUsersInputPort inputPort,
            IGetAllUsersOutputPort presenter) =>
            {
                await inputPort.Handle();
                return presenter.Result;
            })
            .RequireAuthorization();

        // GET: Obtener usuarios bloqueados (Solo Admin y SuperUser)
        app.MapGet(Endpoints.GetLockedOutUsers,
            [Authorize(Roles = "Administrator,SuperUser")]
        async (IGetLockedOutUsersInputPort inputPort,
            IGetLockedOutUsersOutputPort presenter) =>
            {
                await inputPort.Handle();
                return presenter.Result;
            })
            .RequireAuthorization();

        // POST: Desbloquear usuario (Solo Admin y SuperUser)
        app.MapPost(Endpoints.UnlockUser,
            [Authorize(Roles = "Administrator,SuperUser")]
        async (UnlockUserDto unlockData,
            IUnlockUserInputPort inputPort,
            IUnlockUserOutputPort presenter) =>
            {
                await inputPort.Handle(unlockData);
                return presenter.Result;
            })
            .RequireAuthorization();

        // POST: Cambiar rol de usuario (Solo SuperUser)
        app.MapPost(Endpoints.ChangeUserRole,
            [Authorize(Roles = "SuperUser")]
        async (ChangeUserRoleDto roleData,
            IChangeUserRoleInputPort inputPort,
            IChangeUserRoleOutputPort presenter) =>
            {
                await inputPort.Handle(roleData);
                return presenter.Result;
            })
            .RequireAuthorization();

        // PUT: Actualizar usuario
        app.MapPut(Endpoints.UpdateUser,
            [Authorize]
        async (UpdateUserDto updateData,
            HttpContext httpContext,
            IUpdateUserInputPort inputPort,
            IUpdateUserOutputPort presenter) =>
            {
                // Obtener el email del usuario autenticado desde el token JWT
                var currentUserEmail = httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                updateData.CurrentUserEmail = currentUserEmail;

                await inputPort.Handle(updateData);
                return presenter.Result;
            })
            .RequireAuthorization();

        // DELETE: Eliminar usuario
        app.MapDelete(Endpoints.DeleteUser,
            [Authorize]
        async (string email,
            HttpContext httpContext,
            IDeleteUserInputPort inputPort,
            IDeleteUserOutputPort presenter) =>
            {
                // Obtener el email del usuario autenticado desde el token JWT
                var currentUserEmail = httpContext.User.FindFirst(ClaimTypes.Name)?.Value;

                var deleteData = new DeleteUserDto
                {
                    Email = email,
                    CurrentUserEmail = currentUserEmail
                };

                await inputPort.Handle(deleteData);
                return presenter.Result;
            })
            .RequireAuthorization();

        return app;
    }
}