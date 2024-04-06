using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Dtos;
using WebApplication2.Entities;
using WebApplication2.Mapping;

namespace WebApplication2.AppEndPoints;

public static class EndPoints
{
    public static RouteGroupBuilder MapEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.Include(game => game.Genre)
        .Select(game => game.ToDto()).AsNoTracking().ToListAsync());

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(game.ToDtoDetails());
        }).WithName("GetGames");

        group.MapPost("/",async (CreateDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();
            AppDtoDetails gameDto = game.ToDtoDetails();
            return Results.CreatedAtRoute("GetGames", new { id = game.Id }, gameDto);
        });


        group.MapPut("/{id}",async (int id, UpdateDto updatedGame, GameStoreContext dbContext) =>
        {
            var exictingGame =await dbContext.Games.FindAsync(id);
            if (exictingGame is null) return Results.NotFound();
            dbContext.Entry(exictingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}",async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }
}
