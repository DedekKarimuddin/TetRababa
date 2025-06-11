using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/settings.json";
    private static string pathMatch = Application.persistentDataPath + "/match.json";

    public static void Save(SettingsData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public static SettingsData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<SettingsData>(json);
        }
        else
        {
            return new SettingsData(); 
        }
    }

    public static void SaveMatch(MatchData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(pathMatch, json);
    }

    public static MatchData LoadMatch()
    {
        if (File.Exists(pathMatch))
        {
            string json = File.ReadAllText(pathMatch);
            return JsonUtility.FromJson<MatchData>(json);
        }
        else
        {
            return new MatchData();
        }
    }
}
