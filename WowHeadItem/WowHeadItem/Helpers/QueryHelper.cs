using WowHeadItem.Entities;

namespace WowHeadItem.Helpers;

public static class QueryHelper
{
    public static string ToSql(this string queryType, Item item)
    {
        switch (queryType)
        {
            case "INSERT":
                return $"INSERT INTO item_template (id, name, description) VALUES ({item.entry}, \'{item.name}\', \'{item.description}\');";
            case "UPDATE":
                return $"UPDATE item_template SET name = \'{item.name}\', description = \'{item.description}\' WHERE id = {item.entry};";
            default:
                throw new Exception("Invalid query type");
        }
    }
}