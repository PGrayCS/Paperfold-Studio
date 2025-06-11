using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int FoldCount { get; private set; }
    public int FoldsPerClick = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        ProgressionSystem.Instance.Tick(Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.S))
            SaveSystem.SaveGame();
        if (Input.GetKeyDown(KeyCode.L))
            SaveSystem.LoadGame();
    }

    public void AddFold(int amount)
    {
        FoldCount += amount;
        ProgressionSystem.Instance.OnFoldChanged(FoldCount);
    }

    public void OnFoldButtonClicked()
    {
        AddFold(FoldsPerClick);
        // play sound / animation via UIController
        UIController.Instance.PlayFoldFeedback();
    }
}
