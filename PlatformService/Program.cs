using Microsoft.EntityFrameworkCore;
using Platform.Domain;
using Platform.Service.Data;
using Platform.Service.PrepDb;
using Platform.Service.Repo;
using Platform.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    option => option.UseInMemoryDatabase("InMem")
    );
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddTransient<PlatformService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
PrepDb.PrePopulation(app);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
