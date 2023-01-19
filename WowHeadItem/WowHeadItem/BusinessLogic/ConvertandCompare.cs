using System.Reflection;
using System.Text.Json;
using WowHeadItem.Helpers;

namespace WowHeadItem.BusinessLogic;
public static class ConvertComparer
{
    public static readonly Dictionary<string, string> StatisticsReplacements = new();
    
    public static string CompareJson(string json, string jsonEquip)
    {
        Dictionary<string, object> jsonDict = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;
        Dictionary<string, object> jsonEquipDict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonEquip)!;
        
        Dictionary<string, object> mergeJson = CompareObjects(jsonDict!, jsonEquipDict!);
        return JsonSerializer.Serialize(mergeJson);
    }

    private static Dictionary<string, object> CompareObjects(Dictionary<string, object> jsonDict, Dictionary<string, object> jsonEquipDict, Dictionary<string, object>? mergeJson = null)
    {
        if (mergeJson is null)
            mergeJson = new();
        
        HashSet<string> keys = new HashSet<string>(jsonDict.Keys);
        keys.UnionWith(jsonEquipDict.Keys);

        foreach (var key in keys)
        {
            if (jsonDict.ContainsKey(key) && jsonEquipDict.ContainsKey(key))
            {
                if (!jsonDict[key].Equals(jsonEquipDict[key]))
                    mergeJson![key] = jsonDict[key];
            }
            else if (jsonDict.ContainsKey(key))
                mergeJson![key] = jsonDict[key];
            else
                mergeJson![key] = jsonEquipDict[key];
        }

        return mergeJson;
    }

    public static void ConvertIncompatibleStatistic()
    {
        Type enumType = typeof(StatType);
        
        // Obtenir toutes les valeurs de l'enum
        Array values = Enum.GetValues(enumType);

        // Parcourir toutes les valeurs de l'enum
        foreach (var value in values)
        {
            // Récupérer le nom de la valeur de l'enum
            string name = Enum.GetName(enumType, value);

            // Obtenir l'attribut StatisticAttribute pour cette valeur
            var attribute = (StatisticAttribute)enumType.GetField(name).GetCustomAttribute(typeof(StatisticAttribute));

            // Si l'attribut existe et que la statistique n'est pas compatible
            if (attribute != null && !attribute.IsCompatibleWithTLK)
            {
                // Ajouter la valeur dans le dictionnaire
                StatisticsReplacements[name] = attribute.CorrectStatisticName;
            }
        }
    }
}