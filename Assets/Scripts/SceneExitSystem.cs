using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneExitSystem : MonoBehaviour
{
    [Header("Exit Popup Panel")]
    [SerializeField] private GameObject exitPopup;            // Reference to the Exit Popup Panel
    [SerializeField] private TextMeshProUGUI exitConfirmationText; // Reference to the Exit Confirmation Text

    private bool isPopupActive = false;                       // Keeps track of whether the popup is active or not

    private void Start()
    {
        if (exitPopup != null)
            exitPopup.SetActive(false); // Hide exit popup at start

        SceneManager.sceneLoaded += OnSceneLoaded; // Register the sceneLoaded event
    }

    private void Update()
    {
        // Check for Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            TriggerExitPopup();
        }

        // Check for Tab key press (if you want to keep this functionality)
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab key pressed");
            TriggerExitPopup();
        }
    }

    private void TriggerExitPopup()
    {
        isPopupActive = !isPopupActive;
        exitPopup.SetActive(isPopupActive);

        if (isPopupActive)
        {
            exitConfirmationText.text = "Do you want to exit the scene?";
            Time.timeScale = 0; // Pause the game
            Debug.Log("Exit Popup Activated");
        }
        else
        {
            Time.timeScale = 1; // Resume the game
            Debug.Log("Exit Popup Deactivated");
        }
    }

    public void OnYesExitButtonClicked()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene("MainMenuScene"); // Load the Main Menu Scene
    }

    public void OnNoExitButtonClicked()
    {
        TriggerExitPopup(); // Close the exit popup
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene {scene.name} loaded. Ready to show exit popup.");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unregister the event
    }
}
