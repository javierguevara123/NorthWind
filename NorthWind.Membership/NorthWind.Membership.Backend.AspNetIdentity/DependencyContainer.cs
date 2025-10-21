﻿using Microsoft.Extensions.DependencyInjection;
using NorthWind.Membership.Backend.AspNetIdentity.DataContexts;
using NorthWind.Membership.Backend.AspNetIdentity.Entities;
using NorthWind.Membership.Backend.AspNetIdentity.Options;
using NorthWind.Membership.Backend.AspNetIdentity.Services;
using NorthWind.Membership.Backend.Core.Interfaces.Common;

namespace NorthWind.Membership.Backend.AspNetIdentity
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMembershipIdentityServices(
       this IServiceCollection services,
       Action<MembershipDBOptions> configureMembershipDBOptions)
        {
            services.AddDbContext<NorthWindMembershipContext>();
            // Configurar Identity
            services.AddIdentityCore<NorthWindUser>()
            .AddEntityFrameworkStores<NorthWindMembershipContext>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.Configure(configureMembershipDBOptions);
            return services;
        }
    }

}
