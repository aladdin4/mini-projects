
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoApi.StartupConfig;
using TodoLibrary.DataAccess;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. (through extension method)
            builder.AddServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();   //should be first then authorization
            app.UseAuthorization();
            app.MapControllers();
            app.MapHealthChecks("/health").AllowAnonymous();
            app.Run();
        }
    }
}
