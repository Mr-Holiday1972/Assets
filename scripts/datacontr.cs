using UnityEngine;
using System.IO;

[System.Serializable]
public class WorldData
{
    public string worldname;//default=new drive
    public int gamemode;//race, openworld, mission, timeattack
    public int maptemplate;//circuit、教習所、松の森、テスト（スーパーフラット）、メサ（アンプリファイド）、メサ（荒野）
    public int cartype;//challenger,crown,
    public float carx;
    public float cary;
    public float carz;
    public int fuel;
    public int damage;
    public int daycyc;//eg 0000-3600
    public bool traffics;

    // Add other world-related data here.

    // Constructor to initialize default values if needed.
    /*public WorldData()
    {
        worldName = "DefaultWorld";
        seed = 0;
    }
    */
}

public class datacontr : MonoBehaviour
{
    // Path where the JSON files will be stored. You can organize them into separate folders.
    private string savePath = "saves/";
    public bool rrr;

    public void SaveWorldData(WorldData worldData, string fileName)
    {
        fileName = "new drive";

        // Convert the WorldData object to JSON format.
        string jsonData = JsonUtility.ToJson(worldData);

        // Combine the save path and file name.
        string filePath = Path.Combine(savePath, fileName + ".json");

        // Write the JSON data to the file.
        File.WriteAllText(filePath, jsonData);
    }

    public WorldData LoadWorldData(string fileName)
    {
        fileName = "new drive";

        // Combine the save path and file name.
        string filePath = Path.Combine(savePath, fileName + ".json");

        if (File.Exists(filePath))
        {
            //rrr = false;
            // Read the JSON data from the file.
            string jsonData = File.ReadAllText(filePath);

            // Deserialize the JSON data into a WorldData object.
            WorldData loadedData = JsonUtility.FromJson<WorldData>(jsonData);

            return loadedData;
        }
        else
        {
            rrr = true;
            Debug.LogWarning("File not found: " + filePath);
            return null;
        }
    }

    public static bool IsEmptyDirectory(string path)
    {
        if (!Directory.Exists(path)) return false;

        try
        {
            var entries = Directory.GetFileSystemEntries(path);
            return entries == null || entries.Length == 0;
        }
        catch
        {
            return false;
        }
    }
}
