using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleScreenController : MonoBehaviour
{
    [Header("UI References")]
    public CanvasGroup titleGroup;
    public Button startButton;
    public CanvasGroup gameUIGroup;
    public float fadeDuration = 0.8f;
    public float uiSlideDuration = 0.6f;
    public Vector3 gameUIStartOffset = new Vector3(0, -50, 0);

    private void Awake()
    {
        // Ensure initial states
        titleGroup.alpha = 0f;
        gameUIGroup.alpha = 0f;
        gameUIGroup.transform.localPosition += gameUIStartOffset;
    }

    private void Start()
    {
        // Fade in title
        titleGroup.DOFade(1f, fadeDuration).SetEase(Ease.OutBack);
        startButton.onClick.AddListener(OnStartClicked);
    }

    private void OnStartClicked()
    {
        // Fade out title
        titleGroup.DOFade(0f, fadeDuration).SetEase(Ease.InBack);
        // Slide and fade in game UI
        gameUIGroup.DOFade(1f, fadeDuration).From(0f);
        gameUIGroup.transform.DOLocalMove(gameUIGroup.transform.localPosition - gameUIStartOffset, uiSlideDuration).SetEase(Ease.OutCubic);
    }
}
