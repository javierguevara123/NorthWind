using Microsoft.AspNetCore.Http;
using NorthWind.Membership.Entities.Dtos.UserManagement;

namespace NorthWind.Membership.Backend.Core.Interfaces.UserManagement
{
    internal interface IGetAllUsersOutputPort
    {
        IResult Result { get; }
        Task Handle(IEnumerable<UserInfoDto> users);
    }
}
