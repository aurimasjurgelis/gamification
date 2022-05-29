using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Gamification")]
    public GameObject playerStats;


    [Header("Global Buttons & Settings")]
    public Button closeButton;
    public int inputAllowance = 4;
    public bool isMultiplayer = false;


    [Header("Login Panel")]
    public GameObject loginPanel;
    public TMP_InputField usernameLoginInput;
    public TMP_InputField passwordLoginInput;
    public Button loginButton;

    [Header("Main Panel")]
    public GameObject mainPanel;


    [Header("Mode Select")]
    public GameObject modeSelectPanel;

    [Header("Challenges")]
    public GameObject challengesPanel;

    [Header("Multiplayer Lobby")]
    public GameObject multiplayerLobbyPanel;


    [Header("Quests")]
    public GameObject questsPanel;

    [Header("Rewards")]
    public GameObject rewardsPanel;

    [Header("Profile")]
    public GameObject profilePanel;

    [Header("To Do")]
    public GameObject todoPanel;



    [Header("Password Change Panel")]
    public GameObject changePasswordPanel;
    public TMP_InputField securityCodeInput;
    public TMP_InputField usernamePassChangeInput;
    public TMP_InputField passwordChangeInput;
    public TMP_InputField repeatPasswordChangeInput;
    public Button changePasswordButton;

    [Header("Register Panel")]
    public GameObject registerPanel;
    public TMP_InputField usernameRegisterInput;
    public TMP_InputField passwordRegisterInput;
    public TMP_InputField positionRegisterInput;
    public TMP_InputField fullnameRegisterInput;
    public Button signUpButton;


    [Header("Options Panel")]
    public GameObject optionsPanel;
    public bool optionsPanelOpened = false;

    [Header("Error Panel")]
    public GameObject errorPanel;
    public TextMeshProUGUI errorText;
    public Button closeErrorButton;

    [Header("Message Panel")]
    public GameObject messagePanel;
    public TextMeshProUGUI messageTitleText;
    public TextMeshProUGUI messageText;
    public Button messageOkButton;

    [Header("Debug")]
    public TextMeshProUGUI debugText;

    public enum PanelStates
    {
        Login,
        Main,
        ChangePassword,
        Register,
        Options,
        Message,
        Error,
        ModeSelect,
        ChallengeSelect,
        MultiplayerLobby,
        ToDo,
        Rewards,
        Profile,
        Quests
    };

    public PanelStates states;

    public void Start()
    {
        states = PanelStates.Login;
        loginPanel.SetActive(true);
    }


    public void Login()
    {
        if(usernameLoginInput.text == "admin" && passwordLoginInput.text == "admin" || (PlayerPrefs.GetString("username") == usernameLoginInput.text && PlayerPrefs.GetString("password") == passwordLoginInput.text))
        {
            states = PanelStates.Main;
            loginPanel.SetActive(false);
            mainPanel.SetActive(true);
            playerStats.SetActive(true);


            Debug.Log(usernameLoginInput.text);
            Debug.Log(passwordLoginInput.text);
        } else
        {
            ErrorMessage("Wrong username or password. Please try again.");
            usernameLoginInput.text = "";
            passwordLoginInput.text = "";
        }
        
    }



    public void OpenRegisterPanel()
    {
        registerPanel.SetActive(true);
        states = PanelStates.Register;
    }


    public void OpenOptionsPanel()
    {
        if (optionsPanelOpened)
        {
            states = PanelStates.Main;
            optionsPanel.SetActive(false);
            optionsPanelOpened = false;
        }
        else
        {
            states = PanelStates.Options;
            optionsPanel.SetActive(true);
            optionsPanelOpened = true;
        }
    }

    public void OpenPasswordChangePanel()
    {
        states = PanelStates.ChangePassword;
        changePasswordPanel.SetActive(true);
    }

    public void CloseButton()
    {
        Debug.Log("State" + states);
        switch (states)
        {
            case PanelStates.Login:
                Debug.Log("Application Quit()");
                Application.Quit();
                break;
            case PanelStates.Main:
                mainPanel.SetActive(false);
                loginPanel.SetActive(true);
                states = PanelStates.Login;
                break;
            case PanelStates.ChangePassword:
                changePasswordPanel.SetActive(false);
                loginPanel.SetActive(true);
                states = PanelStates.Login;
                break;
            case PanelStates.Register:
                registerPanel.SetActive(false);
                loginPanel.SetActive(true);
                states = PanelStates.Login;
                break;
            case PanelStates.Message:
                messagePanel.SetActive(false);
                break;
            case PanelStates.Error:
                errorPanel.SetActive(false);
                break;
            case PanelStates.Profile:
                states = PanelStates.Main;
                profilePanel.SetActive(false);
                mainPanel.SetActive(true);
                break;
            case PanelStates.Quests:
                states = PanelStates.Main;
                questsPanel.SetActive(false);
                mainPanel.SetActive(true);
                break;
            case PanelStates.Rewards:
                states = PanelStates.Main;
                rewardsPanel.SetActive(false);
                mainPanel.SetActive(true);
                break;
            case PanelStates.ToDo:
                states = PanelStates.Main;
                todoPanel.SetActive(false);
                mainPanel.SetActive(true);
                break;
            case PanelStates.MultiplayerLobby:
                states = PanelStates.ModeSelect;
                multiplayerLobbyPanel.SetActive(false);
                modeSelectPanel.SetActive(true);
                break;
            case PanelStates.ModeSelect:
                states = PanelStates.Main;
                modeSelectPanel.SetActive(false);
                mainPanel.SetActive(true);
                break;
            case PanelStates.ChallengeSelect:
                states = PanelStates.ModeSelect;
                challengesPanel.SetActive(false);
                break;
            default:
                states = PanelStates.Main;
                loginPanel.SetActive(true);
                break;
        }

    }

    public void ErrorMessage(string msg)
    {
        states = PanelStates.Error;
        errorText.text = msg;
        errorPanel.SetActive(true);
    }

    public void Message(string msg, string titleText = "Warning!")
    {
        states = PanelStates.Message;
        messageText.text = msg;
        messageTitleText.text = titleText;
        messagePanel.SetActive(true);
    }

    public void NotImplemented()
    {
        Message("Not Implemented.");
    }

    public void CloseErrorButton()
    {
        errorPanel.SetActive(false);
    }
    public void CloseMessageButton()
    {
        messagePanel.SetActive(false);
    }

    public void Register()
    {
        registerPanel.SetActive(false);
        PlayerPrefs.SetString("username", usernameRegisterInput.text);
        PlayerPrefs.SetString("password", passwordRegisterInput.text);
        PlayerPrefs.SetString("position", positionRegisterInput.text);
        PlayerPrefs.SetString("fullname", fullnameRegisterInput.text);
        Debug.Log("Registered: " + usernameRegisterInput.text + " " + passwordRegisterInput.text);
    }

    public void ChangePassword()
    {
        Message("The password was changed successfully!");
        changePasswordPanel.SetActive(false);
    }

    public void VerifySignUpInputs()
    {
        signUpButton.interactable = (usernameRegisterInput.text.Length >= inputAllowance && passwordRegisterInput.text.Length >= inputAllowance && positionRegisterInput.text.Length >= inputAllowance);
    }
    public void VerifyLoginInputs()
    {
        loginButton.interactable = (usernameLoginInput.text.Length >= inputAllowance && passwordLoginInput.text.Length >= inputAllowance);
    }

    public void VerifyPasswordChangeInputs()
    {
        changePasswordButton.interactable = (securityCodeInput.text.Length == 6 &&
            usernamePassChangeInput.text.Length >= inputAllowance &&
            passwordChangeInput.text.Length >= inputAllowance &&
            repeatPasswordChangeInput.text.Length >= inputAllowance &&
            repeatPasswordChangeInput.text == passwordChangeInput.text);
    }

    public void OpenQuests()
    {
        states = PanelStates.Quests;
        questsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OpenRewards()
    {
        states = PanelStates.Rewards;
        rewardsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OpenTODO()
    {
        states = PanelStates.ToDo;
        todoPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OpenProfile()
    {
        ProfileController.Instance.FetchData();
        states = PanelStates.Profile;
        profilePanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OpenChallenges(bool isMultiplayer)
    {
        states = PanelStates.ChallengeSelect;
        Debug.Log(isMultiplayer ? "Singleplayer is active" : "Multiplayer is active");
        this.isMultiplayer = isMultiplayer;
        challengesPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OpenModeSelect()
    {
        states = PanelStates.ModeSelect;
        modeSelectPanel.SetActive(true);
        mainPanel.SetActive(false);
    }


    public void StartChallenge()
    {
        if(isMultiplayer)
        {
            states = PanelStates.MultiplayerLobby;
            multiplayerLobbyPanel.SetActive(true);
            challengesPanel.SetActive(false);
            mainPanel.SetActive(false);

        } else
        {
            SceneManager.LoadScene("Singleplayer");
        }
    }

    public void StartMultiplayerChallenge()
    {
        SceneManager.LoadScene("Multiplayer");
    }    




}
