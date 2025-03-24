using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    [SerializeField] private BallSettings settings;  // ✅ Serialized to allow setting adjustments in the Inspector
    [SerializeField] private BallSpawner spawner;    // ✅ Serialized to link the BallSpawner in the Inspector

    private int bounceCount = 0;  // Keeping track of the number of bounces
    private float lifetime;       // The remaining lifetime of the ball

    public void Initialize(BallSettings ballSettings, BallSpawner ballSpawner)
    {
        settings = ballSettings;
        spawner = ballSpawner;
        lifetime = settings.ballLifetime;

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && settings.ballMaterial != null)
        {
            renderer.material = settings.ballMaterial;
        }

        bounceCount = 0;
        gameObject.SetActive(true);

        StartCoroutine(BounceBall());
    }

    private IEnumerator BounceBall()
    {
        while (bounceCount < settings.maxBounces && lifetime > 0)
        {
            LeanTween.moveY(gameObject, settings.bounceHeight, 0.5f).setEase(LeanTweenType.easeOutQuad);
            yield return new WaitForSeconds(0.5f);

            LeanTween.moveY(gameObject, 0, 0.5f).setEase(LeanTweenType.easeInQuad);
            yield return new WaitForSeconds(0.5f);

            bounceCount++;
            lifetime -= 1f; // Reduce lifetime with each bounce
        }

        ReturnToPool();
    }

    private void ReturnToPool()
    {
        spawner.BallReturned(gameObject); // ✅ Passes the ball itself
        LeanTween.scale(gameObject, Vector3.zero, 0.5f).setOnComplete(() => gameObject.SetActive(false));
    }
}
