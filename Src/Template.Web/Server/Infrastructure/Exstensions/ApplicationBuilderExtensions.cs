using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Template.Domain.Entities;
using Template.Infrastructure.Persistence;

namespace Template.Server.Infrastructure.Exstensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebServices(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHealthChecks("/health")
               .UseHttpsRedirection()
               .UseBlazorFrameworkFiles()
               .UseStaticFiles()
               .UseRouting()
               .UseCors(x => x
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Add(ClaimTypes.NameIdentifier, ClaimTypes.NameIdentifier);
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Add(ClaimTypes.Name, ClaimTypes.Name);
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Add(ClaimTypes.Role, ClaimTypes.Role);

            app.UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            return app;
        }

        public static async Task<IApplicationBuilder> Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            try
            {
                var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }

                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var mediator = serviceScope.ServiceProvider.GetService<IMediator>();

                await ApplicationDbContextSeed.SeedSampleDataAsync(userManager, roleManager, context, CancellationToken.None);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return app;
        }
    }
}
