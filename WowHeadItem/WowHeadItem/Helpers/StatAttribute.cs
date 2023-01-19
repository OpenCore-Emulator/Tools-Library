namespace WowHeadItem.Helpers;

[AttributeUsage(AttributeTargets.Field)]
class StatisticAttribute : Attribute
{
    public bool IsCompatibleWithTLK { get; set; }
    public string CorrectStatisticName { get; set; }
}