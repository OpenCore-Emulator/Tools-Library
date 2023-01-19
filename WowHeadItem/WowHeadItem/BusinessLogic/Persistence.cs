using WowHeadItem.Entities;
using WowHeadItem.Helpers;

namespace WowHeadItem.BusinessLogic;

public class Persistence
{
    public static void SaveItem(Item item, string queryType)
    {
        var fileName = $"{item.entry} - {item.name}.sql";
        var query = queryType.ToUpper().ToSql(item);
        
        File.WriteAllText(fileName, query);
    }
}