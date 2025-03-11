using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private TMP_Dropdown DifficultyDropdown;
    [SerializeField] private TMP_InputField PlayerNameInput;
    [SerializeField] private Button CloseButton;
    [SerializeField] private GameObject settingsPanel;

    [Header("Settings")]
    public GameSetting settings;

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
        VolumeSlider.onValueChanged.AddListener(updateVolume);
        DifficultyDropdown.onValueChanged.AddListener(updateDifficulty);
        PlayerNameInput.onEndEdit.AddListener(updatePlayerName);
        CloseButton.onClick.AddListener(toggleSettingsPanel);

        // Hide the panel initially
        settingsPanel.SetActive(false);
    }

    private void updateVolume(float value)
    {
        settings.volume = value;
    }

    private void updateDifficulty(int value)
    {
        settings.difficulty = value;
    }

    private void updatePlayerName(string name)
    {
        settings.playerName = name;
    }

    public void toggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleSettingsPanel();
        }
    }
}

