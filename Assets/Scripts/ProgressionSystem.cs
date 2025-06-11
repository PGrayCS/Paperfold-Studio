using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OrigamiSet
{
    public string Name;
    public int Cost;
    public bool Completed;
}

public class ProgressionSystem : MonoBehaviour
{
    public static ProgressionSystem Instance { get; private set; }

    public List<OrigamiSet> origamiSets = new List<OrigamiSet>
    {
        new OrigamiSet { Name = "Crane Set", Cost = 100 },
        new OrigamiSet { Name = "Flower Set", Cost = 500 }
    };

    public OrigamiAssistant assistant = new OrigamiAssistant();
    public int skillPoints = 0;
    private float tick;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Tick(float delta)
    {
        tick += delta;
        if (tick >= 1f)
        {
            int amount = Mathf.RoundToInt(assistant.FoldsPerSecond * PrestigeSystem.Instance.GetMultiplier());
            GameManager.Instance.AddFold(amount);
            tick = 0f;
        }
    }

    public void OnFoldChanged(int foldCount)
    {
        foreach (var set in origamiSets)
        {
            if (!set.Completed && foldCount >= set.Cost)
            {
                set.Completed = true;
                skillPoints += 1;
                UIController.Instance.PlaySetComplete();
            }
        }
    }

    public void HireAssistant()
    {
        int cost = assistant.NextCost;
        if (GameManager.Instance.FoldCount >= cost)
        {
            GameManager.Instance.AddFold(-cost);
            assistant.Upgrade();
        }
    }

    public void ResetProgress()
    {
        foreach (var set in origamiSets)
        {
            set.Completed = false;
        }
        skillPoints = 0;
        assistant.Level = 0;
    }
}
