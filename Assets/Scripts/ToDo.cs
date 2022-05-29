using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToDo : MonoBehaviour
{
    public GameObject toggle;

    public TodoController.Complexity complexity;
    public TodoController.Priority priority;

    public TextMeshProUGUI rewardText;

    public string description;

    public int xpReward;

    public int index;

    void Start()
    {
        Debug.Log(complexity.ToString() + priority.ToString());
        xpReward = TodoController.CalculateReward(complexity, priority);
        rewardText.text = "Reward: " + xpReward + " XP";
    }

    public ToDo(string description, TodoController.Complexity complexity, TodoController.Priority priority)
    {
        this.description = description;
        this.complexity = complexity;
        this.priority = priority;
        xpReward = TodoController.CalculateReward(complexity, priority);
    }



    public void OnTaskStatusChange()
    {
        bool status = toggle.GetComponent<Toggle>().isOn;
        Debug.Log(xpReward);
        ProgressionController.Instance.CompleteToDo(xpReward);
        TodoController.Instance.DeleteTodo(index);
    }
}
