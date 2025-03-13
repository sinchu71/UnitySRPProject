using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private Slider sizeSlider;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Dropdown locationDropdown;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button submitButton;
    [SerializeField] private Button logoutButton;
    [SerializeField] private Button forgotPasswordButton;
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private TextMeshProUGUI successMessage;
    [SerializeField] private TextMeshProUGUI scrollingText; // For scrolling text effect
    [SerializeField] private TextMeshProUGUI userLoginPageText;

    [Header("User Data")]
    [SerializeField] private UserData userData;

    private float scrollingSpeed = 100f; // Scrolling speed of the text

    private void Start()
    {
        LoadUserData();
        uiPanel.SetActive(true);
        optionMenu.SetActive(false);
        
        sizeSlider.onValueChanged.AddListener(UpdateSize);
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        submitButton.onClick.AddListener(SubmitData);
        logoutButton.onClick.AddListener(Logout);
        forgotPasswordButton.onClick.AddListener(ForgotPassword);
        settingsButton.onClick.AddListener(OpenSettings);

        scrollingText.text = "Welcome to Login Page";
    }

    private void Update()
    {
        ScrollText();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearAllData();
        }
    }

    private void ScrollText()
    {
        scrollingText.rectTransform.anchoredPosition += Vector2.left * scrollingSpeed * Time.deltaTime;

        if (scrollingText.rectTransform.anchoredPosition.x <= -scrollingText.preferredWidth)
        {
            scrollingText.rectTransform.anchoredPosition = new Vector2(800, scrollingText.rectTransform.anchoredPosition.y);
        }
    }

    private void UpdateSize(float value)
    {
        int textSize = (int)value;
        userData.sizePreference = textSize;
        nameInputField.textComponent.fontSize = textSize;
        Debug.Log($"Text Size Changed to: {textSize}");
    }

    private void UpdateVolume(float value)
    {
        int volume = (int)value;
        userData.volumePreference = volume;
        Debug.Log($"Volume Level Changed to: {volume}");
    }

    private void OpenSettings()
    {
        optionMenu.SetActive(true);
        DisplaySettingsOptions();
    }

    private void DisplaySettingsOptions()
    {
        Debug.Log("Settings Menu Opened: Privacy, Profile, Account Management, Security, Downloads");
    }

    private void SubmitData()
    {
        if (passwordInputField.text.Length < 10)
        {
            Debug.Log("Password must be at least 10 characters long.");
            return;
        }

        userData.userEmail = emailInputField.text;
        userData.userName = nameInputField.text;
        userData.userPassword = passwordInputField.text;
        userData.locationPreference = locationDropdown.options[locationDropdown.value].text;

        Debug.Log("User Data Saved Successfully!");
        successMessage.text = "User Data Saved Successfully!";
        successMessage.gameObject.SetActive(true);
    }

    private void Logout()
    {
        Debug.Log("User Logged Out Successfully.");
    }

    private void ForgotPassword()
    {
        Debug.Log("Forgot Password Clicked! Support message: Go through this link for account recovery:https://support.google.com/accounts/answer/7682439?hl=en");
    }

    private void LoadUserData()
    {
        emailInputField.text = userData.userEmail;
        nameInputField.text = userData.userName;
        passwordInputField.text = userData.userPassword;
        sizeSlider.value = userData.sizePreference;
        volumeSlider.value = userData.volumePreference;
        locationDropdown.value = locationDropdown.options.FindIndex(option => option.text == userData.locationPreference);
    }

    private void ClearAllData()
    {
        emailInputField.text = "";
        nameInputField.text = "";
        passwordInputField.text = "";
        locationDropdown.value = 0;
        successMessage.gameObject.SetActive(false);
        optionMenu.SetActive(false);

        Debug.Log("All information cleared.");
    }
}
