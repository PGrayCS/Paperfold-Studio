using UnityEngine;

[System.Serializable]
public class Skill
{
    public string Name;
    public int Cost;
    public bool Purchased;
}

public class SkillTree : MonoBehaviour
{
    public Skill[] skills = new Skill[]
    {
        new Skill { Name = "Faster Assistants", Cost = 1 },
        new Skill { Name = "+1 Fold/Click", Cost = 1 }
    };

    public void PurchaseSkill(int index)
    {
        if (index < 0 || index >= skills.Length) return;
        var skill = skills[index];
        if (!skill.Purchased)
        {
            if (ProgressionSystem.Instance.skillPoints >= skill.Cost)
            {
                ProgressionSystem.Instance.skillPoints -= skill.Cost;
                skill.Purchased = true;
                ApplySkill(skill);
            }
        }
    }

    private void ApplySkill(Skill skill)
    {
        if (skill.Name == "Faster Assistants")
        {
            ProgressionSystem.Instance.assistant.BaseFoldsPerSecond += 0.5f;
        }
        else if (skill.Name == "+1 Fold/Click")
        {
            GameManager.Instance.FoldsPerClick += 1;
        }
    }
}
