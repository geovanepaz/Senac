using Microsoft.EntityFrameworkCore;
using Senac.BemStar.Application.Interfaces;
using Senac.BemStar.Application.Services;
using Senac.BemStar.Domain.Interfaces;
using Senac.BemStar.Infra.Context;
using Senac.BemStar.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Adiciona AutoMapper e registra os perfis
builder.Services.AddAutoMapper(typeof(MapeamentoProfile));

builder.Services.AddDbContext<BemStarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BemStarBase")));

// IoC
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAlunoService, AlunoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
