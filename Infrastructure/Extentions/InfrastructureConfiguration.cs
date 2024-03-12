using Domain.Movie.Data;
using Infrastructure.Movie.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extentions
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            return services;
        }
    }
}
