using UnityEngine;
using System;
using System.Collections;

public abstract class Projectile : MonoBehaviour
{
    protected float power = 1f;

    protected float maxLife;

    [SerializeField] public bool isPlayer = false;

    protected float fadeOutTime = 0.5f;

    private SpriteRenderer spriteRenderer;

    private Action returnToPool;

    public void InitialiseReturn(Action returnToPool) => this.returnToPool = returnToPool;

    public void ReturnToPool() => returnToPool?.Invoke();

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetAlpha(1f);
        StartCoroutine(Lifetime());
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isPlayer)
        {
            IDamageable enemy = collision.GetComponentInParent<IDamageable>();
            enemy.Damage(power);
            ReturnToPool();
        }
        else if (collision.gameObject.tag == "Player" && !isPlayer)
        {
            IDamageable player = collision.GetComponentInParent<IDamageable>();
            player.Damage(power);
            ReturnToPool();
        }
        else if (collision.gameObject.tag == "Environment")
            ReturnToPool();
    }

    private IEnumerator Lifetime()
    {
        float lifeTime = Mathf.Max(0f, maxLife - fadeOutTime);
        yield return new WaitForSeconds(lifeTime);

        float time = 0f;
        while (time < fadeOutTime)
        {
            time += Time.deltaTime;
            SetAlpha(1f - time / fadeOutTime);
            yield return null;
        }

        ReturnToPool();
    }

    private void SetAlpha(float alpha)
    {
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = alpha;
        spriteRenderer.color = spriteColor;
    }
}
