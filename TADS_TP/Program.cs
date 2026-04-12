
using Microsoft.EntityFrameworkCore;
using TADS_TP.Repositories;
using TADS_TP.Services;

namespace TADS_TP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=LocadoraDB;Trusted_Connection=True;TrustServerCertificate=True"));

            builder.Services.AddControllers();
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<ClienteRepository>();

            builder.Services.AddScoped<VeiculoService>();
            builder.Services.AddScoped<VeiculoRepository>();

            builder.Services.AddScoped<AluguelService>();
            builder.Services.AddScoped<AluguelRepository>();

            builder.Services.AddScoped<PagamentoService>();
            builder.Services.AddScoped<PagamentoRepository>();

            builder.Services.AddScoped<FabricanteService>();
            builder.Services.AddScoped<FabricanteRepository>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
