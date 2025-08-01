﻿using Microsoft.Extensions.DependencyInjection;

namespace Web.Extendes
{
    public static class AddAutoMapperApp
    {
        public static IServiceCollection AddMapperApp(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Utilities.MappersApp.Card.PlayerMap));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;

        }
    }
}
