
using JWT.API_.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWT.API_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.services.addauthentication(cfg =>
            //{
            //    cfg.defaultauthenticatescheme = jwtbearerdefaults.authenticationscheme;
            //    cfg.defaultchallengescheme = jwtbearerdefaults.authenticationscheme;
            //    cfg.defaultscheme = jwtbearerdefaults.authenticationscheme;
            //}).addjwtbearer(x =>
            //{
            //    x.requirehttpsmetadata = false;
            //    x.savetoken = false;
            //    x.tokenvalidationparameters = new tokenvalidationparameters
            //    {
            //        validateissuersigningkey = true,
            //        issuersigningkey = new symmetricsecuritykey(
            //            encoding.utf8
            //            .getbytes(configuration["applicationsettings.jwt_secret"])
            //            ),
            //        validateissuer = false,
            //        validateaudience = false,
            //        clockskew = timespan.zero
            //    };
            //});

          
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
