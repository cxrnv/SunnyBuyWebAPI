using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SunnyBuy.Domain;
using SunnyBuy.Services;
using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.CreditCardServices;
using SunnyBuy.Services.PurchaseServices;

namespace SunnyBuy.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SunnyBuyContext>
                (
                    options => { options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));}
                );

            services.AddScoped<CartService>();
            services.AddScoped<ClientService>();
            services.AddScoped<ProductService>();
            services.AddScoped<PurchaseService>();
            services.AddScoped<CreditCardService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
