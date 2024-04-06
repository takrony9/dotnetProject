using WebApplication2.AppEndPoints;
using WebApplication2.Data;
using WebApplication2.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();
app.MapEndPoints();
await app.MigrateDB();
app.Run();