using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    public GameObject toggle;
    //public GameObject progressionController;

    public QuestController.Complexity complexity;
    public QuestController.Priority priority;

    public TextMeshProUGUI descriptionText;

    public TextMeshProUGUI xPRewardText;
    public TextMeshProUGUI coinRewardText;


    public string description;

    public int xpReward;
    public int coinReward;

    public enum Trigger
    {
        PopUpClick,
        ConsecutivePopUpClick,
        ContentCompletion,
        AssignedTodo
    }

    public Trigger trigger;



    void Start()
    {
        //progressionController = GameObject.Find("ProgressionController");
        //rewardText.text = "Reward: " + xpReward + " XP";
        Debug.Log(complexity.ToString() + priority.ToString());
        xpReward = QuestController.CalculateXPReward(complexity, priority);
        coinReward = QuestController.CalculateCoinReward(complexity, priority);
        xPRewardText.text = xpReward + " XP";
        coinRewardText.text = coinReward.ToString();

    }

    public Quest(string description, QuestController.Complexity complexity, QuestController.Priority priority)
    {
        this.description = description;
        this.complexity = complexity;
        this.priority = priority;
        xpReward = QuestController.CalculateXPReward(complexity, priority);
        coinReward = QuestController.CalculateCoinReward(complexity, priority);
    }

    public Quest(string description, QuestController.Complexity complexity, QuestController.Priority priority, Trigger trigger)
    {
        this.description = description;
        this.complexity = complexity;
        this.priority = priority;
        xpReward = QuestController.CalculateXPReward(complexity, priority);
        coinReward = QuestController.CalculateCoinReward(complexity, priority);
        this.trigger = trigger;
    }



    public void OnTaskStatusChange()
    {
        bool status = toggle.GetComponent<Toggle>().isOn;
        string command = status ? "task_finished" : "task_unfinished";
        //progressionController.GetComponent<ProgressionController>().UpdateProgress(command);
    }
}
