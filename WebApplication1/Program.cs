using Microsoft.AspNetCore.Mvc;
using WebApplication1.DB;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

new DB();

app.MapGet("/api/zwierze", () =>
{
    return Results.Ok(DB.Zwierze);
});

app.MapGet("/api/zwierze/{id:int}", (int id) =>
{
    var zwierz = DB.Zwierze.FirstOrDefault((zwierz1 => zwierz1.id == id));
    return Results.Ok(zwierz);
});

app.MapPost("/api/zwierze", ([FromBody] Zwierz zwierz) =>
{
    DB.Zwierze.Add(zwierz);
    return Results.Created($"/api/zwierze/{zwierz.id}", zwierz);
});

app.MapPut("/api/zwierze/{id:int}", (int id, [FromBody] Zwierz data) =>
{
    var zwierz = DB.Zwierze.FirstOrDefault(zw => zw.id == id);
    if (zwierz is null) return Results.NotFound($"Zwierz with id {id} not found");
    
    zwierz.imie = data.imie;
    zwierz.kategoria = data.kategoria;
    zwierz.masa = data.masa;
    zwierz.kolorsiersci = data.kolorsiersci;
    return Results.Ok(zwierz);
});

app.MapDelete("/api/zwierze/{id:int}", (int id) =>
{
    var zwierzes = DB.Zwierze.Where(zw => zw.id != id);
    DB.Zwierze = zwierzes.ToList();
    return Results.Ok();
});

app.MapGet("/api/zwierze/{id:int}/wizyty", (int id) =>
{
    var zwierz = DB.Zwierze.FirstOrDefault((zwierz1 => zwierz1.id == id));
    var wizytyZwierzaka = DB.Wizyty.Where(wizyta => wizyta.zwierze == zwierz);
    return Results.Ok(wizytyZwierzaka);
});

app.MapPost("/api/zwierze/{id:int}/wizyty", (int id, [FromBody] Wizyta data) =>
{
    var zwierz = DB.Zwierze.FirstOrDefault((zwierz1 => zwierz1.id == id));
    data.zwierze = zwierz;
    DB.Wizyty.Add(data);
    return Results.Created($"/api/zwierze/{zwierz.id}/wizyty", data);
});

app.UseHttpsRedirection();

app.Run();