using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [Header("UI References")]
    public TMP_Text foldText;
    public Button foldButton;
    public AudioSource audioSource;
    public AudioClip foldClip;
    public ParticleSystem foldEffect;
    public float punchStrength = 0.1f;
    public float punchDuration = 0.3f;

    [Header("Set Complete Popup")]
    public CanvasGroup setCompleteGroup;
    public TMP_Text setCompleteText;
    public ParticleSystem setCompleteEffect;
    public float setCompleteDuration = 1.5f;

    private Color originalTextColor;

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
        originalTextColor = foldText.color;
    }

    private void Start()
    {
        foldButton.onClick.AddListener(() => GameManager.Instance.OnFoldButtonClicked());
        UpdateFoldText();
    }

    public void PlayFoldFeedback()
    {
        if (audioSource != null && foldClip != null)
            audioSource.PlayOneShot(foldClip);
        if (foldEffect != null)
            foldEffect.Play();
        // DOTween punch scale for button
        foldButton.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 8, 1);
        // DOTween text punch and color flash
        foldText.transform.DOPunchScale(Vector3.one * 0.15f, 0.4f, 10, 1);
        foldText.DOFade(1f, 0.05f).From(0.5f).OnComplete(() =>
            foldText.DOColor(Color.yellow, 0.2f).OnComplete(() =>
                foldText.DOColor(originalTextColor, 0.5f)));
        UpdateFoldText();
    }

    public void UpdateFoldText()
    {
        foldText.text = $"Folds: {GameManager.Instance.FoldCount}";
    }

    public void PlaySetComplete(string setName)
    {
        UpdateFoldText();
        ShowSetComplete(setName);
    }

    private void ShowSetComplete(string setName)
    {
        setCompleteText.text = $"{setName} Unlocked!";
        setCompleteGroup.alpha = 0f;
        setCompleteGroup.gameObject.SetActive(true);
        setCompleteGroup.DOFade(1f, 0.4f).SetEase(Ease.OutBack)
            .OnComplete(() =>
                setCompleteGroup.DOFade(0f, 0.8f).SetDelay(setCompleteDuration - 0.8f)
                    .OnComplete(() => setCompleteGroup.gameObject.SetActive(false)));
        if (setCompleteEffect != null)
            setCompleteEffect.Play();
    }
}
