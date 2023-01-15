namespace BlizzardNet.Helpers
{
    public static class Link
    {
        public static string Region { get; set; } = "us";
        public static string Locale { get; set; } = "en_US";
        
        /// <summary>
        /// Returns the URL for the specified region and locale.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private static string RegionLink(string region)
        {
            switch (region)
            {
                case "us":
                    return "https://us.api.blizzard.com";
                case "eu":
                    return "https://eu.api.blizzard.com";
                case "kr":
                    return "https://kr.api.blizzard.com";
                case "tw":
                    return "https://tw.api.blizzard.com";
                case "cn":
                    return "https://cn.api.blizzard.com";
                default:
                    return "https://us.api.blizzard.com";
            }
        }
        
        /// <summary>
        /// Achievement links
        /// </summary>
        /// <returns></returns>
        public static string AchievementCategoriesIndex() => $"{RegionLink(Region)}/data/wow/achievement-category/index?namespace=static-{Region}&locale={Locale}";
        public static string AchievementCategory(int id) => $"{RegionLink(Region)}/data/wow/achievement-category/{id}?namespace=static-{Region}&locale={Locale}";
        public static string AchievementIndex() => $"{RegionLink(Region)}/data/wow/achievement/index?namespace=static-{Region}&locale={Locale}";
        public static string Achievement(int id) => $"{RegionLink(Region)}/data/wow/achievement/{id}?namespace=static-{Region}&locale={Locale}";
        public static string AchievementMedia(int id) => $"{RegionLink(Region)}/data/wow/media/achievement/{id}?namespace=static-{Region}&locale={Locale}";
        
        /// <summary>
        /// Azerite Essence links
        /// </summary>
        /// <returns></returns>
        public static string AzeriteEssenceIndex() => $"{RegionLink(Region)}/data/wow/azerite-essence/index?namespace=static-{Region}&locale={Locale}";
        public static string AzeriteEssence(int id) => $"{RegionLink(Region)}/data/wow/azerite-essence/{id}?namespace=static-{Region}&locale={Locale}";
        public static string AzeriteEssenceSearch(string name) => $"{RegionLink(Region)}/data/wow/search/azerite-essence?name.{name}?namespace=static-{Region}&locale={Locale}";
        public static string AzeriteEssenceMedia(int id) => $"{RegionLink(Region)}/data/wow/media/azerite-essence/{id}?namespace=static-{Region}&locale={Locale}";
        
        /// <summary>
        /// Covenant links
        /// </summary>
        /// <returns></returns>
        public static string CovenantIndex() => $"{RegionLink(Region)}/data/wow/covenant/index?namespace=static-{Region}&locale={Locale}";
        public static string Covenant(int id) => $"{RegionLink(Region)}/data/wow/covenant/{id}?namespace=static-{Region}&locale={Locale}";
        public static string CovenantMedia(int id) => $"{RegionLink(Region)}/data/wow/media/covenant/{id}?namespace=static-{Region}&locale={Locale}";
        public static string SoulbindIndex() => $"{RegionLink(Region)}/data/wow/soulbind/index?namespace=static-{Region}&locale={Locale}";
        public static string Soulbind(int id) => $"{RegionLink(Region)}/data/wow/soulbind/{id}?namespace=static-{Region}&locale={Locale}";
        public static string ConduitIndex() => $"{RegionLink(Region)}/data/wow/conduit/index?namespace=static-{Region}&locale={Locale}";
        public static string Conduit(int id) => $"{RegionLink(Region)}/data/wow/conduit/{id}?namespace=static-{Region}&locale={Locale}";
        
        /// <summary>
        /// Creature links
        /// </summary>
        /// <returns></returns>
        public static string CreatureFamiliesIndex() => $"{RegionLink(Region)}/data/wow/creature-family/index?namespace=static-{Region}&locale={Locale}";
        public static string CreatureFamily(int id) => $"{RegionLink(Region)}/data/wow/creature-family/{id}?namespace=static-{Region}&locale={Locale}";
        public static string CreatureTypesIndex() => $"{RegionLink(Region)}/data/wow/creature-type/index?namespace=static-{Region}&locale={Locale}";
        public static string CreatureType(int id) => $"{RegionLink(Region)}/data/wow/creature-type/{id}?namespace=static-{Region}&locale={Locale}";
        public static string Creature(int id) => $"{RegionLink(Region)}/data/wow/creature/{id}?namespace=static-{Region}&locale={Locale}";
        public static string CreatureSearch(string name) => $"{RegionLink(Region)}/data/wow/search/creature?name.{name}?namespace=static-{Region}&locale={Locale}";
        public static string CreatureDisplayMedia(int id) => $"{RegionLink(Region)}/data/wow/media/creature-display/{id}?namespace=static-{Region}&locale={Locale}";
        public static string CreatureFamilyMedia(int id) => $"{RegionLink(Region)}/data/wow/media/creature-family/{id}?namespace=static-{Region}&locale={Locale}";
        
        /// <summary>
        /// Guild Crest links
        /// </summary>
        /// <returns></returns>
        public static string GuildCrestComponentsIndex() => $"{RegionLink(Region)}/data/wow/guild-crest/index?namespace=static-{Region}&locale={Locale}";
        public static string GuildCrestBorderMedia(int id) => $"{RegionLink(Region)}/data/wow/media/guild-crest/border/{id}?namespace=static-{Region}&locale={Locale}";
        public static string GuildCrestEmblemMedia(int id) => $"{RegionLink(Region)}/data/wow/media/guild-crest/emblem/{id}?namespace=static-{Region}&locale={Locale}";
        
        /// <summary>
        /// Item links
        /// </summary>
        /// <returns></returns>
        public static string ItemClassesIndex() => $"{RegionLink(Region)}/data/wow/item-class/index?namespace=static-{Region}&locale={Locale}";
        public static string ItemClass(int id) => $"{RegionLink(Region)}/data/wow/item-class/{id}?namespace=static-{Region}&locale={Locale}";
        public static string ItemSetsIndex() => $"{RegionLink(Region)}/data/wow/item-set/index?namespace=static-{Region}&locale={Locale}";
        public static string ItemSet(int id) => $"{RegionLink(Region)}/data/wow/item-set/{id}?namespace=static-{Region}&locale={Locale}";
        public static string ItemSubClass(int classId, int subClassId) => $"{RegionLink(Region)}/data/wow/item-class/{classId}/item-subclass/{subClassId}?namespace=static-{Region}&locale={Locale}";
        public static string Item(int id) => $"{RegionLink(Region)}/data/wow/item/{id}?namespace=static-{Region}&locale={Locale}";
        public static string ItemMedia(int id) => $"{RegionLink(Region)}/data/wow/media/item/{id}?namespace=static-{Region}&locale={Locale}";
        public static string ItemSearch(string name) => $"{RegionLink(Region)}/data/wow/search/item?name.{name}?namespace=static-{Region}&locale={Locale}";
        
        /// <summary>
        /// Journal links
        /// </summary>
        /// <returns></returns>
        public static string JournalExpansionsIndex() => $"{RegionLink(Region)}/data/wow/journal-expansion/index?namespace=static-{Region}&locale={Locale}";
        public static string JournalExpansion(int id) => $"{RegionLink(Region)}/data/wow/journal-expansion/{id}?namespace=static-{Region}&locale={Locale}";
        public static string JournalEncountersIndex() => $"{RegionLink(Region)}/data/wow/journal-encounter/index?namespace=static-{Region}&locale={Locale}";
        public static string JournalEncounter(int id) => $"{RegionLink(Region)}/data/wow/journal-encounter/{id}?namespace=static-{Region}&locale={Locale}";
        public static string JournalEncounterSearch(string name) => $"{RegionLink(Region)}/data/wow/search/journal-encounter?name.{name}?namespace=static-{Region}&locale={Locale}";
        public static string JournalInstancesIndex() => $"{RegionLink(Region)}/data/wow/journal-instance/index?namespace=static-{Region}&locale={Locale}";
        public static string JournalInstance(int id) => $"{RegionLink(Region)}/data/wow/journal-instance/{id}?namespace=static-{Region}&locale={Locale}";
        public static string JournalInstanceMedia(int id) => $"{RegionLink(Region)}/data/wow/media/journal-instance/{id}?namespace=static-{Region}&locale={Locale}";

        
        /// <summary>
        /// Quest links
        /// </summary>
        /// <returns></returns>
        public static string QuestIndex() => $"{RegionLink(Region)}/data/wow/quest/index?namespace=static-{Region}&locale={Locale}";
        public static string Quest(int id) => $"{RegionLink(Region)}/data/wow/quest/{id}?namespace=static-{Region}&locale={Locale}";
        public static string QuestCategoriesIndex() => $"{RegionLink(Region)}/data/wow/quest/category/index?namespace=static-{Region}&locale={Locale}";
        public static string QuestCategory(int id) => $"{RegionLink(Region)}/data/wow/quest/category/{id}?namespace=static-{Region}&locale={Locale}";
        public static string QuestAreasIndex() => $"{RegionLink(Region)}/data/wow/quest/area/index?namespace=static-{Region}&locale={Locale}";
        public static string QuestArea(int id) => $"{RegionLink(Region)}/data/wow/quest/area/{id}?namespace=static-{Region}&locale={Locale}";
        public static string QuestTypeIndex() => $"{RegionLink(Region)}/data/wow/quest/type/index?namespace=static-{Region}&locale={Locale}";
        public static string QuestType(int id) => $"{RegionLink(Region)}/data/wow/quest/type/{id}?namespace=static-{Region}&locale={Locale}";
    }
}