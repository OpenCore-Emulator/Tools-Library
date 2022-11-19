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
        public static string AchievementCategoriesIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/achievement-category/index";
        public static string AchievementCategory(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/achievement-category/{id}";
        public static string AchievementIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/achievement/index";
        public static string Achievement(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/achievement/{id}";
        public static string AchievementMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/achievement/{id}";
        
        /// <summary>
        /// Azerite Essence links
        /// </summary>
        /// <returns></returns>
        public static string AzeriteEssenceIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/azerite-essence/index";
        public static string AzeriteEssence(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/azerite-essence/{id}";
        public static string AzeriteEssenceSearch(string name) => $"{RegionLink(Region)}/{Locale}/data/wow/search/azerite-essence?name.{name}";
        public static string AzeriteEssenceMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/azerite-essence/{id}";
        
        /// <summary>
        /// Covenant links
        /// </summary>
        /// <returns></returns>
        public static string CovenantIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/covenant/index";
        public static string Covenant(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/covenant/{id}";
        public static string CovenantMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/covenant/{id}";
        public static string SoulbindIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/soulbind/index";
        public static string Soulbind(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/soulbind/{id}";
        public static string ConduitIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/conduit/index";
        public static string Conduit(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/conduit/{id}";
        
        /// <summary>
        /// Creature links
        /// </summary>
        /// <returns></returns>
        public static string CreatureFamiliesIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/creature-family/index";
        public static string CreatureFamily(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/creature-family/{id}";
        public static string CreatureTypesIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/creature-type/index";
        public static string CreatureType(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/creature-type/{id}";
        public static string Creature(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/creature/{id}";
        public static string CreatureSearch(string name) => $"{RegionLink(Region)}/{Locale}/data/wow/search/creature?name.{name}";
        public static string CreatureDisplayMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/creature-display/{id}";
        public static string CreatureFamilyMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/creature-family/{id}";
        
        /// <summary>
        /// Guild Crest links
        /// </summary>
        /// <returns></returns>
        public static string GuildCrestComponentsIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/guild-crest/index";
        public static string GuildCrestBorderMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/guild-crest/border/{id}";
        public static string GuildCrestEmblemMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/guild-crest/emblem/{id}";
        
        /// <summary>
        /// Item links
        /// </summary>
        /// <returns></returns>
        public static string ItemClassesIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/item-class/index";
        public static string ItemClass(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/item-class/{id}";
        public static string ItemSetsIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/item-set/index";
        public static string ItemSet(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/item-set/{id}";
        public static string ItemSubClass(int classId, int subClassId) => $"{RegionLink(Region)}/{Locale}/data/wow/item-class/{classId}/item-subclass/{subClassId}";
        public static string Item(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/item/{id}";
        public static string ItemMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/item/{id}";
        public static string ItemSearch(string name) => $"{RegionLink(Region)}/{Locale}/data/wow/search/item?name.{name}";
        
        /// <summary>
        /// Journal links
        /// </summary>
        /// <returns></returns>
        public static string JournalExpansionsIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/journal-expansion/index";
        public static string JournalExpansion(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/journal-expansion/{id}";
        public static string JournalEncountersIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/journal-encounter/index";
        public static string JournalEncounter(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/journal-encounter/{id}";
        public static string JournalEncounterSearch(string name) => $"{RegionLink(Region)}/{Locale}/data/wow/search/journal-encounter?name.{name}";
        public static string JournalInstancesIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/journal-instance/index";
        public static string JournalInstance(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/journal-instance/{id}";
        public static string JournalInstanceMedia(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/media/journal-instance/{id}";

        
        /// <summary>
        /// Quest links
        /// </summary>
        /// <returns></returns>
        public static string QuestIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/quest/index";
        public static string Quest(int id) => $"{RegionLink(Region)}/data/wow/quest/{id}?namespace=static-{Region}&locale={Locale}";
        public static string QuestCategoriesIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/quest/category/index";
        public static string QuestCategory(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/quest/category/{id}";
        public static string QuestAreasIndex() => $"{RegionLink(Region)}/data/wow/quest/area/index?namespace=static-{Region}&locale={Locale}";
        public static string QuestArea(int id) => $"{RegionLink(Region)}/data/wow/quest/area/{id}?namespace=static-{Region}&locale={Locale}";
        public static string QuestTypeIndex() => $"{RegionLink(Region)}/{Locale}/data/wow/quest/type/index";
        public static string QuestType(int id) => $"{RegionLink(Region)}/{Locale}/data/wow/quest/type/{id}";
    }
}