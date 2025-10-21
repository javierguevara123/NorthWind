﻿using NorthWind.Membership.Backend.Core.Interfaces.UserLogin;
using NorthWind.Membership.Entities.UserLogin;
using NorthWind.Membership.Entities.ValueObjects;

namespace Microsoft.AspNetCore.Builder;
internal static class UserLoginController
{
    public static WebApplication UseUserLoginController(
   this WebApplication app)
    {
        app.MapPost(Endpoints.Login,
        async (UserCredentialsDto userCredentials,
        IUserLoginInputPort inputPort,
        IUserLoginOutputPort presenter) =>
        {
            await inputPort.Handle(userCredentials);
            return presenter.Result;
        });
        return app;
    }
}

