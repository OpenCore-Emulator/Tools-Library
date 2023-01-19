using System.Text.RegularExpressions;
using System.Xml;
using HtmlAgilityPack;

namespace WowHeadItem.BusinessLogic;

public static class Client
{
    public static HtmlWeb Web { get; } = new();
    public static XmlDocument XmlDocument { get; } = new();
    
    public static Dictionary<string, string> NodeName = new()
    {
        ["json"] = String.Empty,
        ["jsonEquip"] = String.Empty,
    };

    private static string ConvertToJson(string text) => text.Insert(0, "{").Insert(text.Length + 1, "}");

    public static string GetData(int itemId)
    {
        using (HttpClient webClient = new HttpClient())
        {
            HttpResponseMessage httpResponseMessage = webClient.GetAsync($"https://www.wowhead.com/item={itemId}&xml").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string htmlDocument = httpResponseMessage.Content.ReadAsStringAsync().Result;
                XmlDocument.LoadXml(htmlDocument);
                
                NodeName.ToList().ForEach(node =>
                {
                    XmlNode? htmlNode = XmlDocument.GetElementsByTagName(node.Key)[0];
                    if (htmlNode?.InnerText != null)
                        NodeName[node.Key] = ConvertToJson(htmlNode.InnerText);
                });
            }
        }

        string mergeJson = ConvertComparer.CompareJson(NodeName["json"], NodeName["jsonEquip"]);
        return mergeJson;
    }

    
    private static string RemoveComment(string html)
    {
        return Regex.Replace(html, "<!--.*?-->", "", RegexOptions.Singleline);
    }
    
    private static string RemoveHtmlTags(string? html)
    {
        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);
        
        return htmlDocument.DocumentNode.InnerText;
    }
}