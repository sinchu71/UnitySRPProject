using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MainMenuSystem : MonoBehaviour
{
    [Header("Scene Loading Confirmation Panel")]
    [SerializeField] private GameObject loadScenePopup; // Popup UI for scene loading confirmation
    [SerializeField] private TextMeshProUGUI loadConfirmationText; // Text for displaying the confirmation message

    [Header("Audio Settings")]
    [SerializeField] private AudioClip backgroundMusic; // Background music clip
    [SerializeField] private AudioClip buttonClickSound; // Sound played on button click

    private string sceneToLoad; // The scene name to be loaded
    private AudioSource audioSource; // AudioSource component for playing sounds
    private bool isMusicPlaying = true; // Flag to check if music is currently playing

    private void Start()
    {
        if (loadScenePopup != null)
            loadScenePopup.SetActive(false); // Hide popup at start

        audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource component
        audioSource.loop = true;

        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play(); // Start playing background music
        }
    }

    private void Update()
    {
        HandleMusicControl(); // Handle music control using the 'M' key
    }

    public void OnSceneButtonClicked(string sceneName)
    {
        PlayButtonClickSound(); // Play click sound
        sceneToLoad = sceneName; // Store the scene name to load
        loadConfirmationText.text = $"Do you want to load {sceneName}?"; // Show scene name in confirmation
        loadScenePopup.SetActive(true); // Display the confirmation popup
    }

    public void OnYesLoadButtonClicked()
    {
        PlayButtonClickSound(); // Play click sound
        SceneManager.LoadScene(sceneToLoad); // Load the selected scene
    }

    public void OnNoLoadButtonClicked()
    {
        PlayButtonClickSound(); // Play click sound
        loadScenePopup.SetActive(false); // Close the confirmation popup
    }

    public void OnExitButtonClicked()
    {
        PlayButtonClickSound(); // Play click sound
        Application.Quit(); // Quit the application
    }

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound); // Play the click sound effect
    }

    private void HandleMusicControl()
    {
        if (Input.GetKeyDown(KeyCode.M)) // Toggle music playback with the 'M' key
        {
            if (isMusicPlaying)
            {
                audioSource.Pause();
                isMusicPlaying = false;
            }
            else
            {
                audioSource.Play();
                isMusicPlaying = true;
            }
        }
    }
}
