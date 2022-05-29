using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSlot : MonoBehaviour
{
    [Header("Image")]
    public Image icon;

    [Header("Additional Information")]
    public GameObject tooltipPanel;
    public bool toggle = false;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    Achievement achievement;

    public void AddAchievement(Achievement newAchievement)
    {
        Debug.Log("Achievement Added!");
        achievement = newAchievement;
        icon.sprite = achievement.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        achievement = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void TooltipToggle()
    {
        toggle = !toggle;
        if (toggle && achievement != null)
        {
            tooltipPanel.SetActive(true);
            title.text = achievement.name;
            description.text = achievement.description;
        }
        else
        {
            tooltipPanel.SetActive(false);
        }
    }

}
