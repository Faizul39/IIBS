﻿
using IIBS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IIBS.StartupExtension
{
    public static class DatabaseExtensionsHelper
    {
        public static IServiceCollection AddDatabaseExtensionHelper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(Opt =>
            {
                Opt.UseSqlServer(configuration.GetConnectionString(name:"DefaultConnection"));

            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IApplicationBuilder RunMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            return app;
        }
    }
}
