using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [Header("UI References")]
    public Text foldText;
    public Button foldButton;

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

    private void Start()
    {
        foldButton.onClick.AddListener(() => GameManager.Instance.OnFoldButtonClicked());
        UpdateFoldText();
    }

    public void PlayFoldFeedback()
    {
        // TODO hook up sound and animation
        UpdateFoldText();
    }

    public void PlaySetComplete()
    {
        // TODO show spotlight effect or animation
        UpdateFoldText();
    }

    public void UpdateFoldText()
    {
        foldText.text = $"Folds: {GameManager.Instance.FoldCount}";
    }
}
