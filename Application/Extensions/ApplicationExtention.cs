﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ApplicationExtention
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            return services;
        }
    }
}
