using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ToggableUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject uiPanel;               // The UI Panel to toggle
    [SerializeField] private Slider colorSlider;               // Slider for color adjustment
    [SerializeField] private TMP_InputField inputField;        // Input field for typing text
    [SerializeField] private Button showTextButton;            // Button to display entered text
    [SerializeField] private TextMeshProUGUI displayedText;     // TextMeshPro text for showing input

    [Header("Data Storage")]
    [SerializeField] private EditableData data;                // ScriptableObject for saving data

    private bool isUIActive = false;                           // Track if the UI is active

    private void Start()
    {
        // Initially hide the UI panel
        uiPanel.SetActive(false);

        // Load saved data
        if (data != null)
        {
            inputField.text = data.savedText;
            colorSlider.value = 0f;
        }

        // Adding listeners to UI elements
        colorSlider.onValueChanged.AddListener(UpdateColor);
        showTextButton.onClick.AddListener(ShowEnteredText);
    }

    private void Update()
    {
        // Toggle the UI panel when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleUI();
        }
    }

    private void ToggleUI()
    {
        isUIActive = !isUIActive; // Toggle the boolean
        uiPanel.SetActive(isUIActive); // Show/Hide the UI panel

        if (isUIActive)
        {
            // Focus on the InputField
            EventSystem.current.SetSelectedGameObject(inputField.gameObject);
            inputField.ActivateInputField();
        }
    }

    private void UpdateColor(float value)
    {
        if (data != null)
        {
            // Change UI panel color based on slider value
            data.uiColor = Color.Lerp(Color.white, Color.red, value);
            uiPanel.GetComponent<Image>().color = data.uiColor;
        }
    }

    private void ShowEnteredText()
    {
        if (data != null)
        {
            // Display the entered text in the displayedText UI element
            displayedText.text = inputField.text;
            data.savedText = inputField.text;
        }
    }
}
