using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private BallSettings settings; // Allows settings to be modified in Inspector
    [SerializeField] private GameObject ballPrefab; // Prefab of the ball to be spawned

    [SerializeField] private AudioClip spawnSound;    // Sound to play when a ball is spawned
    [SerializeField] private AudioClip despawnSound;  // Sound to play when a ball is despawned

    private int activeBallCount = 0;
    private AudioSource audioSource; 

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); 
        SpawnInitialBalls();
    }

    private void Update()
    {
        HandleInput();
    }

    private void SpawnInitialBalls()
    {
        for (int i = 0; i < settings.maxActiveBalls; i++)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-settings.spawnAreaSize.x / 2, settings.spawnAreaSize.x / 2),
            settings.spawnHeight,
            Random.Range(-settings.spawnAreaSize.y / 2, settings.spawnAreaSize.y / 2)
        );

        GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

        Material randomMaterial = new Material(settings.ballMaterial);
        Color ballColor = Random.ColorHSV();
        randomMaterial.color = ballColor;
        newBall.GetComponent<MeshRenderer>().material = randomMaterial;

        Ball ball = newBall.GetComponent<Ball>();
        ball.Initialize(settings, this);

        activeBallCount++;

        if (spawnSound != null)
            audioSource.PlayOneShot(spawnSound);

        newBall.transform.localScale = Vector3.zero;
        LeanTween.scale(newBall, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.rotateAround(newBall, Vector3.up, 360f, Random.Range(2f, 4f)).setLoopClamp();

        DisplayMessage($"Spawned Ball with Color: {ColorUtility.ToHtmlStringRGB(ballColor)}");
    }

    public void BallReturned(GameObject ball)
    {
        activeBallCount--;

        if (despawnSound != null)
            audioSource.PlayOneShot(despawnSound);

        Color ballColor = ball.GetComponent<MeshRenderer>().material.color;

        LeanTween.scale(ball, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.alpha(ball, 0f, 0.5f).setEase(LeanTweenType.easeInBack).setOnComplete(() =>
        {
            Destroy(ball);
            DisplayMessage($"Disappeared Ball with Color: {ColorUtility.ToHtmlStringRGB(ballColor)}");
        });

        if (activeBallCount < settings.maxActiveBalls)
        {
            SpawnBall();
        }

        DisplayMessage($"Despawned Ball with Color: {ColorUtility.ToHtmlStringRGB(ballColor)}");
    }

    private void DisplayMessage(string message)
    {
        Debug.Log(message);
        LeanTween.delayedCall(2f, () => Debug.ClearDeveloperConsole());
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            settings.maxBounces = Mathf.Clamp(settings.maxBounces + 1, settings.minBounces, settings.maxBounceLimit);
            Debug.Log("Max Bounces Increased: " + settings.maxBounces);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            settings.maxBounces = Mathf.Clamp(settings.maxBounces - 1, settings.minBounces, settings.maxBounceLimit);
            Debug.Log("Max Bounces Decreased: " + settings.maxBounces);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            settings.maxActiveBalls = Mathf.Max(1, settings.maxActiveBalls - 1);
            Debug.Log("Max Active Balls Decreased: " + settings.maxActiveBalls);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            settings.maxActiveBalls++;
            Debug.Log("Max Active Balls Increased: " + settings.maxActiveBalls);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            settings.bounceHeight += 1f;
            Debug.Log("Bounce Height Increased: " + settings.bounceHeight);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            settings.bounceHeight = Mathf.Max(0f, settings.bounceHeight - 1f);
            Debug.Log("Bounce Height Decreased: " + settings.bounceHeight);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            settings.spawnHeight += 1f;
            Debug.Log("Spawn Height Increased: " + settings.spawnHeight);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            settings.spawnHeight = Mathf.Max(0f, settings.spawnHeight - 1f);
            Debug.Log("Spawn Height Decreased: " + settings.spawnHeight);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            settings.spawnAreaSize.x += 1f;
            settings.spawnAreaSize.y += 1f;
            Debug.Log("Spawn Area Size Increased: " + settings.spawnAreaSize);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            settings.spawnAreaSize.x = Mathf.Max(1f, settings.spawnAreaSize.x - 1f);
            settings.spawnAreaSize.y = Mathf.Max(1f, settings.spawnAreaSize.y - 1f);
            Debug.Log("Spawn Area Size Decreased: " + settings.spawnAreaSize);
        }
    }
}
