
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization( opts =>
            {
                opts.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });

            builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("Default"));
            builder.Services.AddAuthentication("Bearer").AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    //So, the _config that we fed is originally coming from here? from the builder?
                    ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
                    ValidateAudience = true,
                    ValidAudience= builder.Configuration.GetValue<string>("Authentication: Audience"),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Authentication:SecretKey")))

                };

            });


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
