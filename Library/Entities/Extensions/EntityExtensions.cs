namespace Library.Entities.Extensions;
using System.Text.Json;
using Library.Entities;
using Library.Repositories;
public static class EntityExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : IEntity
    {
        var json = JsonSerializer.Serialize<T>(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }
}
