using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    public static AchievementUI Instance { get; private set; }

    public Transform itemsParent;

    public GameObject achivementUI;

    AchievementSlot[] slots;

    Achievements achievements;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        achievements = Achievements.instance;
        achievements.onAchievementChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<AchievementSlot>();
        Debug.Log("Achievement Slots length: " + slots.Length);

        if (Achievements.instance.achievements.Count > 0)
        {
            UpdateUI();
        }
    }



    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < achievements.achievements.Count)
            {
                slots[i].AddAchievement(achievements.achievements[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
