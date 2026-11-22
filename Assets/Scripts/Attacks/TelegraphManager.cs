using System.Collections;
using UnityEngine;

public class TelegraphManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer teleRenderer;
    [SerializeField] private Sprite[] teleIcon;
    [SerializeField] private Color[] teleColor;
    private float fadeInTime = 0.5f;

    private void Awake() => TelegraphDeactivate();

    public void TelegraphActivate(AttackPatternList pattern, ProjectileList projectile)
    {
        teleRenderer.sprite = teleIcon[(int)pattern];
        teleRenderer.enabled = true;

        StartCoroutine(FadeIn(teleColor[(int)projectile]));
    }

    public void TelegraphDeactivate() => teleRenderer.enabled = false;

    public IEnumerator FadeIn(Color alpha)
    {
        float time = 0f;
        while (time < fadeInTime)
        {
            time += Time.deltaTime;
            Color color = alpha;
            color.a = Mathf.Lerp(0f, color.a, time / fadeInTime);
            teleRenderer.color = color;
            yield return null;
        }
        teleRenderer.color = alpha;
    }
}
