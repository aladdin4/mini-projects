using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;
using TodoLibrary.DataAccess;

namespace TodoApi.StartupConfig;

public static class DependecyInjectionExtenstions
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.AddStandardServices();
        builder.AddCustomServices();
        builder.AddAuthServices();
        builder.AddHealthcheckService();
    }
    public static void AddStandardServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void AddCustomServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();   //Singletn because we don't save data.
        builder.Services.AddSingleton<ITodoData, TodoData>();
    }
    public static void AddAuthServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(opts =>
        {
            opts.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        });

        builder.Services.AddAuthentication("Bearer").AddJwtBearer(opts =>
        {
            opts.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                //So, the _config that we fed is originally coming from here? from the builder?
                ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
                ValidateAudience = true,
                ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Authentication:SecretKey")))
            };

        });
    }
    public static void AddHealthcheckService(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("Default"));
    }
}
