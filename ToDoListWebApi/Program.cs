
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoListBAL;
using ToDoListBAL.Auth;
using ToDoListBAL.jwt;
using ToDoListDAL.Data;
using ToDoListDAL.DataRepo;

namespace ToDoListWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            var jwtSection = builder.Configuration.GetSection("Jwt");

            builder.Services.Configure<JwtSetting>(jwtSection);
            var jwtSettings = jwtSection.Get<JwtSetting>();
            builder.Services.AddSingleton(jwtSettings);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = jwtSettings.Issuer,
                           ValidAudience = jwtSettings.Audience,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey))
                       };
                   });

            builder.Services.AddScoped<IUserManage, UserManage>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IAuthRepo, AuthRepo>();
            builder.Services.AddScoped<IAuthServices, AuthServices>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddControllers();
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
