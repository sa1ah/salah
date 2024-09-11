
using Kashkha.BL;
using Kashkha.BL.Managers.CartManager;
using Kashkha.BL.Mapping;
using Kashkha.DAL;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Kashkha.DAL.Models;
namespace Kashkha.API
{
	public class Program
	{
		public void ConfigureServices(IServiceCollection services)
{
  

          services.AddAutoMapper(typeof(MappingProfile));

  
}
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers().ConfigureApiBehaviorOptions(op=>
			op.SuppressModelStateInvalidFilter=true);
            builder.Services.AddDbContext<KashkhaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KashkhaDb")));
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<IProductManager, ProductManager>();
		    builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICartManager, CartManager>();
			builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICartManager, CartManager>();
            builder.Services.AddSingleton<IConnectionMultiplexer>(option =>
            {
                var connection = builder.Configuration.GetConnectionString("RedisConnection");
                return ConnectionMultiplexer.Connect(connection!);
            });

            builder.Services.AddScoped<IReviewManager, ReviewManager>();

			builder.Services.AddAutoMapper(typeof(MappingProfile));
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
            //identity
            builder.Services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<KashkhaContext>();
            //configure authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//api reply when dta is unauthen
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    var keyfrmconfig = builder.Configuration.GetValue<string>("SecretKey");

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyfrmconfig!));
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        //ValidIssuer = "http://localhost:5127",
                        ValidateAudience = false,
                        //ValidAudience = "http://localhost:4200",
                        IssuerSigningKey = key
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
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
