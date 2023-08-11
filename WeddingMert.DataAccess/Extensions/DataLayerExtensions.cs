﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeddingMert.DataAccess.Reositories.Abstract;
using WeddingMert.DataAccess.Reositories.Concrete;
using WeddingMert.DataAccess.UnitOfWorks;
using WeddingMert.Entity.Concrete;

namespace WeddingMert.DataAccess.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
           

            return services;
        }
    }
}
