using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame()
    {
        PlayerPrefs.SetInt("foldCount", GameManager.Instance.FoldCount);
        PlayerPrefs.SetInt("assistantLevel", ProgressionSystem.Instance.assistant.Level);
        PlayerPrefs.SetInt("skillPoints", ProgressionSystem.Instance.skillPoints);
        PlayerPrefs.SetInt("prestigeCount", PrestigeSystem.Instance.prestigeCount);
        PlayerPrefs.Save();
    }

    public static void LoadGame()
    {
        var folds = PlayerPrefs.GetInt("foldCount", 0);
        GameManager.Instance.AddFold(folds);
        ProgressionSystem.Instance.assistant.Level = PlayerPrefs.GetInt("assistantLevel", 0);
        ProgressionSystem.Instance.skillPoints = PlayerPrefs.GetInt("skillPoints", 0);
        PrestigeSystem.Instance.prestigeCount = PlayerPrefs.GetInt("prestigeCount", 0);
    }
}
