using UnityEngine;
using Newtonsoft.Json;

public static class SaveManager
{
    private static string filePath = Application.persistentDataPath + "/GameSave.txt";
    public static void Save(this SaveData save)
    {
        string json = JsonConvert.SerializeObject(save, Formatting.Indented);

        Debug.Log("Saving to: " + filePath);

        System.IO.File.WriteAllText(filePath, json);
    }

    public static SaveData Load(){
        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            SaveData save = JsonConvert.DeserializeObject<SaveData>(json);
            Debug.Log("Loading from: " + filePath);
            return save;
        }

        SaveData newSave = new SaveData();
        Save(newSave);
        return newSave;
    }
}

