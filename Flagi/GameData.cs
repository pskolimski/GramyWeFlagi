using System.IO;
using Newtonsoft.Json;

namespace Flagi;

public static class GameData
{
    public static string UserName { get; set; }
    public static List<Country> Countries { get; set; } = new List<Country>();
    public static int Score { get; set; }

    static GameData()
    {
        GetCountriesFromJson("./countries.json");
    }

     static void GetCountriesFromJson(string filePath)
    {
        string json = File.ReadAllText(filePath);
        Countries = JsonConvert.DeserializeObject<List<Country>>(json);
    }
}