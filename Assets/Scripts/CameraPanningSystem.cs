using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraPanningSystem : MonoBehaviour
{
    public static CameraPanningSystem Instance;

    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private float transitionSpeed = 2f;
    [SerializeField] private float verticalOffset = 2f;
    [SerializeField] private Light highlightLight = null;
    [SerializeField] private List<Color> ballColors = new List<Color>(); // Track ball colors
    [SerializeField] private AudioClip ballSpawnSound = null;
    [SerializeField] private AudioClip ballDespawnSound = null;
    [SerializeField] private float zoomInFOV = 40f;  // Zoomed in Field of View
    [SerializeField] private float zoomOutFOV = 60f; // Normal Field of View
    [SerializeField] private float shakeAmount = 0.2f;  // Shake intensity
    [SerializeField] private float shakeDuration = 0.1f; // Shake duration
    [SerializeField] private float cameraMovementSpeed = 1f; // Speed for up/down camera movement

    private int currentBallIndex = -1;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isReturningToInitial = false;
    private AudioSource audioSource;
    private Vector3 originalCameraPosition;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        initialPosition = transform.position;
        initialRotation = transform.rotation;

        audioSource = GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
        originalCameraPosition = mainCamera.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) SwitchToNextBall();
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) SwitchToPreviousBall();
        else if (Input.GetKeyDown(KeyCode.Z)) ZoomIn();
        else if (Input.GetKeyDown(KeyCode.X)) ZoomOut();

        if (isReturningToInitial)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * transitionSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * transitionSpeed);

            if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
                isReturningToInitial = false;
        }
    }

    public void RegisterBall(Color color)
    {
        ballColors.Add(color);
        PlaySound(ballSpawnSound);

        if (ballColors.Count == 1)
        {
            currentBallIndex = 0;
            UpdateHighlightLight();
            ZoomIn();  
        }
    }

    public void UnregisterBall(Color color)
    {
        if (ballColors.Contains(color))
        {
            ballColors.Remove(color);
            PlaySound(ballDespawnSound);

            if (ballColors.Count == 0)
            {
                currentBallIndex = -1;
                isReturningToInitial = true;
                highlightLight.enabled = false;
                ZoomOut();  
            }
            else
            {
                SwitchToNextBall(); 
            }
        }
    }

    private void SwitchToNextBall()
    {
        if (ballColors.Count == 0) return;

        currentBallIndex = (currentBallIndex + 1) % ballColors.Count;
        UpdateHighlightLight();
        StartCoroutine(ShakeCamera());
    }

    private void SwitchToPreviousBall()
    {
        if (ballColors.Count == 0) return;

        currentBallIndex = (currentBallIndex - 1 + ballColors.Count) % ballColors.Count;
        UpdateHighlightLight();
        StartCoroutine(ShakeCamera());
    }

    private void UpdateHighlightLight()
    {
        if (currentBallIndex >= 0 && currentBallIndex < ballColors.Count)
        {
            highlightLight.color = ballColors[currentBallIndex];
            highlightLight.enabled = true;
            Vector3 targetPosition = transform.position + Vector3.up * verticalOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraMovementSpeed);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }

    private void ZoomIn() => mainCamera.fieldOfView = zoomInFOV;
    private void ZoomOut() => mainCamera.fieldOfView = zoomOutFOV;

    private IEnumerator ShakeCamera()
    {
        Vector3 originalPosition = mainCamera.transform.position;

        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeAmount;
            float y = Random.Range(-1f, 1f) * shakeAmount;

            mainCamera.transform.position = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.position = originalPosition;
    }
}
