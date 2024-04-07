using WebApplication1.DB;

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
    var zwierz = DB.Zwierze.FirstOrDefault((zwierz1 => zwierz1.getId() == id));
    return Results.Ok(zwierz);
});

app.UseHttpsRedirection();

app.Run();