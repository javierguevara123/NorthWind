using NorthWind.Membership.Backend.Core.Dtos;
using NorthWind.Membership.Entities.Dtos.UserManagement;
using NorthWind.Membership.Entities.Dtos.UserRegistration;
using NorthWind.Membership.Entities.UserLogin;
using NorthWind.Result.Entities;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Membership.Backend.Core.Interfaces.Common
{
    public interface IMembershipService
    {
        // Registro y Login
        Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDto userData, string role = "Employee");
        Task<UserDto> GetUserByCredentials(UserCredentialsDto userData);

        // Gestión de Bloqueos
        Task<bool> IsUserLockedOut(string email);
        Task<Result<IEnumerable<ValidationError>>> UnlockUser(string email);

        // Gestión de Usuarios y Roles
        Task<IEnumerable<UserInfoDto>> GetAllUsers();
        Task<IEnumerable<UserInfoDto>> GetLockedOutUsers();
        Task<Result<IEnumerable<ValidationError>>> ChangeUserRole(string email, string newRole);

        // Update y Delete
        Task<Result<IEnumerable<ValidationError>>> UpdateUser(
            string email,
            string firstName,
            string lastName,
            string cedula,
            string newPassword,
            string currentUserEmail);
        Task<Result<IEnumerable<ValidationError>>> DeleteUser(string email, string currentUserEmail);

        // Inicialización
        Task InitializeRoles();
    }
}