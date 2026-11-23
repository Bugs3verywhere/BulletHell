using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image[] segments;
    [SerializeField] private float showTime = 0.5f;
    [SerializeField] private float fadeTime = 0.5f;

    private Coroutine showBar;

    private void OnEnable() => playerHealth.HealthChange += OnHealthChange;
    private void OnDisable() => playerHealth.HealthChange -= OnHealthChange;

    private void Start()
    {
        SetSegments(playerHealth.currentHealth);
        canvasGroup.alpha = 0;
    }

    private void OnHealthChange(float current, float max)
    {
        SetSegments(current);
        if (showBar != null) StopCoroutine(showBar);
        showBar = StartCoroutine(Appear());
    }

    private void SetSegments(float current)
    {
        int filled = Mathf.CeilToInt(current);
        for (int i = 0; i < segments.Length; i++)
            segments[i].enabled = i < filled;
    }

    private IEnumerator Appear()
    {
        canvasGroup.alpha = 1;
        yield return new WaitForSecondsRealtime(showTime);

        float time = 0f;
        while (time < fadeTime)
        {
            time += Time.unscaledDeltaTime;
            canvasGroup.alpha = 1f - time / fadeTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}
