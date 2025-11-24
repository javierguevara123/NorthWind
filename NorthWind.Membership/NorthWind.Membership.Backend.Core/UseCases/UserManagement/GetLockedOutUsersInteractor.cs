using NorthWind.Membership.Backend.Core.Interfaces.Common;
using NorthWind.Membership.Backend.Core.Interfaces.UserManagement;

namespace NorthWind.Membership.Backend.Core.UseCases.UserManagement
{
    internal class GetLockedOutUsersInteractor(
        IMembershipService membershipService,
        IGetLockedOutUsersOutputPort presenter) : IGetLockedOutUsersInputPort
    {
        public async Task Handle()
        {
            var users = await membershipService.GetLockedOutUsers();
            await presenter.Handle(users);
        }
    }
}
