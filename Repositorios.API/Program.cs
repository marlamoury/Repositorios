using Microsoft.EntityFrameworkCore;
using Repositorios.Persistencia.Auxiliares;
using Repositorios.Persistencia.Contexto;
using Repositorios.Servicos.Auxiliares;
using Repositorios.Servicos.Interfaces;
using Repositorios.Servicos.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RepositorioContexto>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Repositorios")));
InjetorServicos.Registrar(builder.Services);
InjetorRepositorios.Registrar(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<RepositorioContexto>();
    context.Database.EnsureCreated();
}

app.Run();
