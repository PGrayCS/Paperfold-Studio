using System;
using UnityEngine;

[Serializable]
public class OrigamiAssistant
{
    public int Level = 0;
    public int BaseCost = 10;
    public float BaseFoldsPerSecond = 1f;

    public float FoldsPerSecond => Level * BaseFoldsPerSecond;

    public int NextCost => Mathf.CeilToInt(BaseCost * Mathf.Pow(1.15f, Level));

    public void Upgrade()
    {
        Level++;
    }
}
