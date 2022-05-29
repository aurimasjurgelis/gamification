using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPController : MonoBehaviour
{
    Dictionary<string, int> stats;

    public GameObject textXp;
    public Slider progressBarLevel;
    public GameObject progression;

    void Update()
    {
        if (ProgressionController.Instance)
        {
            stats = ProgressionController.Instance.GetStats();
            UpdateScoreboard();
            UpdateLevelProgress();
        }
    }

    void UpdateXP(int num, int total)
    {
        textXp.GetComponent<TextMeshProUGUI>().text = "Level: " + (stats["level"] + 1) + " XP: " + num + "/" + total;

    }




    void UpdateLevelProgress()
    {
        float progress = (float)stats["xp"] / (float)stats["next_xp"] * 100.0f;
        progressBarLevel.value = progress;

    }

    void UpdateScoreboard()
    {
        UpdateXP(stats["xp"], stats["next_xp"]);
    }
}
