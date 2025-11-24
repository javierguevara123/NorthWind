using NorthWind.Membership.Backend.Core.Interfaces.Common;
using NorthWind.Membership.Backend.Core.Interfaces.UserManagement;

namespace NorthWind.Membership.Backend.Core.UseCases.UserManagement
{
    internal class GetAllUsersInteractor(
        IMembershipService membershipService,
        IGetAllUsersOutputPort presenter) : IGetAllUsersInputPort
    {
        public async Task Handle()
        {
            var users = await membershipService.GetAllUsers();
            await presenter.Handle(users);
        }
    }
}
