using LaundryReservationAPI.Data;
using LaundryReservationAPI.Interfaces;
using LaundryReservationAPI.Proxies;
using LaundryReservationAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LaundryReservationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var appSettingsSection = builder.Configuration.GetSection("AppSettings");
            builder.Services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            builder.Services.AddControllers();
            builder.Services.AddDbContext<LaundryDbContext>(
                option => option.UseSqlServer(appSettings.LaundryDbConnectionString)
                );
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IMachineRepository, MachineRepository>();
            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient<MachineApiProxy>(
               client =>
               {
                   client.BaseAddress = new Uri(appSettings.BaseAddress);
                   client.DefaultRequestHeaders.Add("Accept", "application/json");
               });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    SeedMachineData.Initialize(services);
                }
                app.UseRouting();
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
