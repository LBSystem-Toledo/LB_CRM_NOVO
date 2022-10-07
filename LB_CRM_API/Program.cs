using LB_CRM_API.Context;
using LB_CRM_API.Repositories;
using LB_CRM_API.Repositories.Interface;
using LB_CRM_API.Services;
using LB_CRM_API.Services.Interface;
using LB_CRM_API.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IUnitOfCRM, UnitOfCRM>();
builder.Services.AddScoped<IModuloService, ModuloService>();
builder.Services.AddScoped<IPacoteService, PacoteService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IParceiroService, ParceiroService>();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

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

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
