using Asp_net_Postgres_Docker;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", () => "pong");
app.MapGet(
    "/some-entyti",
    async ( ApplicationDBContext db) => await db.EntytiMies.ToListAsync()
    );

app.MapGet(
    "/some-entyti {id:int}",
    async (int id, ApplicationDBContext db) => await db.EntytiMies.FirstOrDefaultAsync(se => se.Id == id)
    );

app.MapPost("/some-entyti",
    async (EntytiMy entity, ApplicationDBContext db) =>
    {
        db.EntytiMies.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    });

app.Run();
