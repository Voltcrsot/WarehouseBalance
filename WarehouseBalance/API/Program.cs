using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Geo;
using Core.DTOs;
using Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов
builder.Services.AddSingleton<InMemoryDbContext>();
builder.Services.AddTransient<InMemoryWarehouseRepository>();
builder.Services.AddTransient<InMemoryConstructionSiteRepository>();
builder.Services.AddTransient<InMemoryInventoryRepository>();
builder.Services.AddTransient<WarehouseService>();
builder.Services.AddTransient<ConstructionSiteService>();
builder.Services.AddTransient<BalanceService>();
builder.Services.AddTransient<GeoService>();
builder.Services.AddTransient<DistanceCalculator>();

var app = builder.Build();

app.MapGet("/warehouses", (WarehouseService service) => service.GetAllWarehouses());

app.MapPost("/warehouses", (WarehouseService service, WarehouseDTO warehouse) =>
{
    service.AddWarehouse(warehouse);
    return Results.Ok();
});

app.MapGet("/constructionsites", (ConstructionSiteService service) => service.GetAllConstructionSites());

app.MapPost("/constructionsites", (ConstructionSiteService service, ConstructionSiteDTO constructionSite) =>
{
    service.AddConstructionSite(constructionSite);
    return Results.Ok();
});

app.MapPost("/balance", (BalanceService balanceService, GeoService geoService, InMemoryWarehouseRepository warehouseRepo, InMemoryDbContext context, BalanceRequest request) =>
{
    var nearestWarehouse = geoService.GetNearestWarehouse(
        new ConstructionSiteDTO
        {
            Latitude = request.ConstructionSite.Latitude,
            Longitude = request.ConstructionSite.Longitude
        },
        context.Warehouses.Select(w => new WarehouseDTO
        {
            Id = w.Id,
            Name = w.Name,
            Latitude = w.Latitude,
            Longitude = w.Longitude
        }).ToList()
    );

    var warehouse = warehouseRepo.GetById(nearestWarehouse.Id);
    var result = balanceService.BalanceMaterials(request, warehouse);
    return Results.Ok(result);
});

app.Run();
