using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    private float playTime;
    private int foldsClicked;

    private void Update()
    {
        playTime += Time.deltaTime;
    }

    public void OnFoldClicked()
    {
        foldsClicked++;
    }

    public void SaveStats()
    {
        PlayerPrefs.SetFloat("playTime", playTime);
        PlayerPrefs.SetInt("foldsClicked", foldsClicked);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        SaveStats();
    }
}
