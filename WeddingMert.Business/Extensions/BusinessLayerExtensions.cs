using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using NovenaClinic.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Business.FluentValidation;
using WeddingMert.Business.Helpers.Images;
using WeddingMert.Business.Services.Abstract;
using WeddingMert.Business.Services.Concrete;

namespace WeddingMert.Business.Extensions
{
    public static class BusinessLayerExtensions
    {
        public static IServiceCollection LoadBusinessLayerExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();//automapperin eklendiği ism alan


            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IContactService, ContactService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(assembly);
            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<AboutValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            return services;
        }
    }
}
