using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject completeLevelUI;

    public int pointsToComplete = 1000;
    public int playerPoints = 0;

    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI pointsToCompleteText;

    public GameObject player;
    public PlayerMovement playerMovement;


    public int powerUpSpeedCount = 0;
    public int powerUpDoubleCount = 0;

    public bool isDoublePowerUpActive = false;

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


    private void Start()
    {
        GameIsOver = false;

        powerUpSpeedCount = PlayerPrefs.GetInt("speed");
        powerUpDoubleCount = PlayerPrefs.GetInt("double");

        Debug.Log("Speed power up count: " + powerUpSpeedCount);
        Debug.Log("Double power up count: " + powerUpDoubleCount);


    }

    public void Update()
    {
        pointsToCompleteText.text = (pointsToComplete - playerPoints).ToString() + " Points left";
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

    public void AddPoints(int points)
    {
        playerPoints += points;
    }

    public void CompleteChallenge()
    {
        UIManager.Instance.OpenChallengeCompletedScreen();
    }

    public void ActivateSpeedPowerUp()
    {
        powerUpSpeedCount = PlayerPrefs.GetInt("speed");
            powerUpSpeedCount--;
            PlayerPrefs.SetInt("speed", powerUpSpeedCount);
            playerMovement.ActivateSpeedPowerUp();
        if (powerUpDoubleCount >= 0)
        {
        }
        else
        {
            Debug.Log("Not enough speed power ups...");
        }
    }

    public void ActivateDoublePowerUp()
    {
        powerUpDoubleCount = PlayerPrefs.GetInt("double");
        powerUpDoubleCount--;
        PlayerPrefs.SetInt("double", powerUpDoubleCount);
        //do something...
        if (powerUpDoubleCount >= 0)
        {
        }
        else
        {
            Debug.Log("Not enough speed power ups...");
        }
    }
}
