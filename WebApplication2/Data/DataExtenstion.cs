using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data;

public static class Class1DataExtenstion
{
public static async Task MigrateDB (this WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    await dbContext.Database.MigrateAsync();
}
}
