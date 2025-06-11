using UnityEngine;

public class PrestigeSystem : MonoBehaviour
{
    public static PrestigeSystem Instance { get; private set; }

    public int prestigeCount = 0;
    public float prestigeBonus = 0.1f; // 10% per prestige

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

    public float GetMultiplier()
    {
        return 1f + prestigeCount * prestigeBonus;
    }

    public void Exhibit()
    {
        prestigeCount++;
        GameManager.Instance.AddFold(-GameManager.Instance.FoldCount);
        ProgressionSystem.Instance.ResetProgress();
    }
}
