using WebApplication2.Dtos;
using WebApplication2.Entities;

namespace WebApplication2.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateDto game)
    {
         return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                price = game.Price,
                Releasedate = game.ReleaseDate
            };
    }

    public static Game ToEntity(this UpdateDto game,int id)
    {
         return new Game()
            {
                Id =id,
                Name = game.Name,
                GenreId = game.GenreId,
                price = game.Price,
                Releasedate = game.ReleaseDate
            };
    }
    public static AppDto ToDto(this Game game)
    {
        return  new (
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.price,
                game.Releasedate
            );
    }

        public static AppDtoDetails ToDtoDetails(this Game game)
    {
        return  new (
                game.Id,
                game.Name,
                game.GenreId,
                game.price,
                game.Releasedate
            );
    }
}
