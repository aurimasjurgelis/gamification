using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("General")]
    public SceneFader sceneFader;

    [Header("Power up buttons")]
    public Button speedPowerUpButton;
    public Button doublePowerUpButton;

    [Header("Task Submit Form")]
    public GameObject taskSubmitForm;
    public TextMeshProUGUI speedPowerUpCountText;
    public TextMeshProUGUI doublePowerUpCountText;
    public bool isFormClosedAfterSubmit = false;

    [Header("Challenge Completed")]
    public GameObject challengeCompletedPanel;


    [Header("Pause Menu")]
    public GameObject pauseMenu;

    public static UIManager Instance { get; private set; }
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SubmitForm()
    {
        GameManager.Instance.AddPoints(100);
        if (isFormClosedAfterSubmit) CloseTaskSubmitForm();
    }

    public void OpenTaskSubmitForm()
    {
        taskSubmitForm.SetActive(true);
    }

    public void CloseTaskSubmitForm()
    {
        taskSubmitForm.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && taskSubmitForm.activeSelf == true)
        {
            taskSubmitForm.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.ActivateSpeedPowerUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.ActivateDoublePowerUp();
        }

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)))
        {
            TogglePause();
        }

    }

    public void OpenChallengeCompletedScreen()
    {
        challengeCompletedPanel.SetActive(true);
    }

    public void ExitChallengePauseMenu()
    {
        TogglePause();
        sceneFader.FadeTo("Menu");
    }

    public void ExitChallange()
    {
        sceneFader.FadeTo("Menu");
    }

    public void ResumeChallange()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
