using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;
using System.Linq;

public class TodoController : MonoBehaviour
{

    public static TodoController Instance { get; private set; }
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

    readonly List<ToDo> listToDo = new List<ToDo>();

    public GameObject toDo;
    public GameObject contentAreaToDo;
    public GameObject inputField;

    public TMP_Dropdown priorityDropdown;
    public TMP_Dropdown complexityDropdown;

    public static int xpMultiplier = 100;


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

    public static int CalculateReward(Complexity complexity, Priority priority)
    {
        return (((int)priority + 1) + ((int)complexity + 1)) * xpMultiplier;
    }


    void Start()
    {
        
        listToDo.Add(new ToDo("Finish fixing a bug", Complexity.Medium, Priority.Normal));
        listToDo.Add(new ToDo("Participate in a meeting", Complexity.Easy, Priority.Low));
        listToDo.Add(new ToDo("Fix an issue with an API endpoint", Complexity.Hard, Priority.Critical));

        inputField.GetComponent<TMP_InputField>().onEndEdit.AddListener(CreateTask);
        RenderTasks();
    }

    void CleanUp()
    {
        foreach (GameObject prefab in GameObject.FindGameObjectsWithTag("PrefabTask"))
        {
            Destroy(prefab);
        }
    }

    void RenderTasks()
    {
        CleanUp();

        for (int i = 0; i < listToDo.Count; i++)
        {
            GameObject prefab;

            float defaultY = -24.0f;
            float factorY = -56.0f;
            float y = (defaultY + (i * factorY)); // Y Co-ordinate of each subsequent task

            // Instantiate task prefab and attach it to 'content' area (game object) of 'ScrollPane' UI component
            prefab = Instantiate(toDo, Vector3.zero, Quaternion.identity) as GameObject;
            contentAreaToDo.GetComponent<RectTransform>().SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            prefab.transform.SetParent(contentAreaToDo.transform, false);

            // Render prefab content:
            prefab.transform.Find("Text").GetComponent<TMP_Text>().text = listToDo[i].description;
            prefab.GetComponent<ToDo>().complexity = listToDo[i].complexity;
            prefab.GetComponent<ToDo>().priority = listToDo[i].priority;
            prefab.GetComponent<ToDo>().index = i;

            // Render pefab's transformations
            prefab.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
            prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(800.0f, 40.0f);
            prefab.GetComponent<RectTransform>().position = new Vector3(0.0f, y, 0.0f);
            prefab.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, y, 0.0f);
        }
    }

    public void CreateTask(string description)
    {
        Debug.Log("Complexity: " + complexityDropdown.options[complexityDropdown.value].text + " Value: " + complexityDropdown.value);
        Debug.Log("Priority: " + priorityDropdown.options[priorityDropdown.value].text + " Value: " + priorityDropdown.value);
        listToDo.Add(new ToDo(description, (Complexity)complexityDropdown.value,  (Priority)priorityDropdown.value));
        RenderTasks();
    }

    public void DeleteTodo(int index)
    {
        Debug.Log("ToDo to delete params are: " + index);
        listToDo.RemoveAt(index);
        RenderTasks();
    }
}
