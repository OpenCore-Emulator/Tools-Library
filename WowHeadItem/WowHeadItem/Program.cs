using System.Text.Json;
using WowHeadItem.BusinessLogic;
using WowHeadItem.Entities;

namespace WowHeadItem;

public static class Program
{
    public static void Main()
    {
        ConvertComparer.ConvertIncompatibleStatistic();
        
        Statistic Statistic = new Statistic();

        Statistic.Add("ITEM_MOD_AGILITY", 12);
    }
}