using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    readonly List<Quest> questList = new List<Quest>();

    public GameObject quest;
    public GameObject contentQuestArea;

    //public TMP_Dropdown priorityDropdown;
    //public TMP_Dropdown complexityDropdown;

    public static int xpMultiplier = 100;
    public static int coinMultiplier = 10;


    public enum Priority
    {
        Low,
        Normal,
        Important,
        Critical
    }

    public enum Complexity
    {
        Easy,
        Medium,
        Hard
    }

    public static int CalculateXPReward(Complexity complexity, Priority priority)
    {
        return (((int)priority + 1) + ((int)complexity + 1)) * xpMultiplier;
    }

    public static int CalculateCoinReward(Complexity complexity, Priority priority)
    {
        return (((int)priority + 1) + ((int)complexity + 1)) * coinMultiplier;
    }

    void Start()
    {

        questList.Add(new Quest("Finish fixing a bug", Complexity.Medium, Priority.Normal));
        questList.Add(new Quest("Complete a multiplayer challenge", Complexity.Easy, Priority.Low));
        questList.Add(new Quest("Implement a backend functionality", Complexity.Hard, Priority.Critical));

        RenderQuests();
    }

    void CleanUp()
    {
        foreach (GameObject prefab in GameObject.FindGameObjectsWithTag("PrefabTask"))
        {
            Destroy(prefab);
        }
    }

    void RenderQuests()
    {
        CleanUp();

        for (int i = 0; i < questList.Count; i++)
        {
            GameObject prefab;

            float defaultY = -24.0f;
            float factorY = -56.0f;
            float y = (defaultY + (i * factorY)); // Y Co-ordinate of each subsequent task

            // Instantiate task prefab and attach it to 'content' area (game object) of 'ScrollPane' UI component
            prefab = Instantiate(quest, Vector3.zero, Quaternion.identity) as GameObject;
            contentQuestArea.GetComponent<RectTransform>().SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            prefab.transform.SetParent(contentQuestArea.transform, false);

            // Render prefab content:
            prefab.transform.Find("Panel").Find("Description Text").GetComponent<TMP_Text>().text = questList[i].description;
            prefab.GetComponent<Quest>().complexity = questList[i].complexity;
            prefab.GetComponent<Quest>().priority = questList[i].priority;

            // Render pefab's transformations
            prefab.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(400.0f, 50.0f);
            prefab.GetComponent<RectTransform>().position = new Vector3(0.0f, y, 0.0f);
            prefab.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, y, 0.0f);
        }
    }

    //public void CreateQuest(string description)
    //{
    //    Debug.Log("Complexity: " + complexityDropdown.options[complexityDropdown.value].text + " Value: " + complexityDropdown.value);
    //    Debug.Log("Priority: " + priorityDropdown.options[priorityDropdown.value].text + " Value: " + priorityDropdown.value);
    //    questList.Add(new Quest(description, (Complexity)complexityDropdown.value,  (Priority)priorityDropdown.value));
    //    RenderQuests();
    //}
}
