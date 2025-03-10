using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField]
    private Slider VolumeSlider;

    [SerializeField]
    private TMP_Dropdown DifficultyDropdown;

    [SerializeField]
    private TMP_InputField PlayerNameInput;

    [SerializeField]
    private Button CloseButton;

    [Header("Settings")]
    public GameSetting settings;  // Make sure it's GameSettings (plural)

    private void Start()
    {
        if (settings == null)
        {
            Debug.LogError("GameSetting ScriptableObject is not assigned!");
            return;
        }

        // Load saved settings
        VolumeSlider.value = settings.volume;
        DifficultyDropdown.value = settings.difficulty;
        PlayerNameInput.text = settings.playerName;

        // Add Listeners
        VolumeSlider.onValueChanged.AddListener(UpdateVolume);
        DifficultyDropdown.onValueChanged.AddListener(UpdateDifficulty);
        PlayerNameInput.onEndEdit.AddListener(UpdatePlayerName);
        CloseButton.onClick.AddListener(ToggleSettingsPanel);

        // Hide the panel initially
        gameObject.SetActive(false);
    }

    private void UpdateVolume(float value)
    {
        settings.volume = value;  // Use lowercase 'volume'
    }

    private void UpdateDifficulty(int value)
    {
        settings.difficulty = value;
    }

    private void UpdatePlayerName(string name)
    {
        settings.playerName = name;
    }

    public void ToggleSettingsPanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingsPanel();
        }
    }
}
