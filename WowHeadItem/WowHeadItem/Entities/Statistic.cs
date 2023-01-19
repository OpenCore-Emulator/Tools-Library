using WowHeadItem.BusinessLogic;
using WowHeadItem.Helpers;

namespace WowHeadItem.Entities;

public class Statistic : Dictionary<StatType, int>
{
    private StatType FirstInsert { get; set; } = StatType.None;
    private StatType LastInsert { get; set; } = StatType.None;
    public new void Add(string statType, int statValue)
    {
        if (this.Count == 10)
            throw new Exception("Statistic is full");

        StatType statEnum = GetStatTypeFromString(statType);

        if (FirstInsert.Equals(StatType.None))
            FirstInsert = statEnum;

        LastInsert = statEnum;
        base.Add(statEnum, statValue);
    }
    
    public StatType GetStatTypeFromString(string statName)
    {
        statName = "ITEM_MOD_" + statName.ToUpper();

        int minDistance = int.MaxValue;
        string matchingStatName = null;
        
        // pour chaque nom de l'enum
        var t = Enum.GetNames(typeof(StatType));
        foreach (string name in Enum.GetNames(typeof(StatType)))
        {

            // calculer la distance de Levenshtein entre le nom et le texte d'entrée
            int distance = LevenshteinDistance.Calculate(statName, name.ToUpper());
            
            // si la distance est plus petite que la distance minimale enregistrée
            if (distance < minDistance)
            {
                minDistance = distance;
                matchingStatName = name;
            }
        }

        if (ConvertComparer.StatisticsReplacements[matchingStatName] != null)
            matchingStatName = ConvertComparer.StatisticsReplacements[matchingStatName];
        
        return (StatType)Enum.Parse(typeof(StatType), matchingStatName);
    }

    public void RemoveFirstStatistic()
    {
        if (FirstInsert.Equals(-1))
            throw new Exception("Statistic is empty");

        Remove(FirstInsert);
    }

    public void RemoveLastStatistic()
    {
        if (LastInsert.Equals(-1))
            throw new Exception("Statistic is empty");
                
        Remove(LastInsert);
    }
}