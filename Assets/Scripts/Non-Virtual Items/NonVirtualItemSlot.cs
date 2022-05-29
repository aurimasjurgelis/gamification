using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NonVirtualItemSlot : MonoBehaviour
{
    [Header("Image")]
    public Image icon;

    [Header("Additional Information")]
    public GameObject tooltipPanel;
    public bool toggle = false;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;


    NonVirtualItem nonVirtualItem;

    public void AddNonVirtualItem(NonVirtualItem newNonVirtualItem)
    {
        Debug.Log("Non virtual item Added!");
        nonVirtualItem = newNonVirtualItem;
        icon.sprite = nonVirtualItem.icon;
        cost.text = "Cost: " + nonVirtualItem.cost.ToString();
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        nonVirtualItem = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void TooltipToggle()
    {
        toggle = !toggle;
        if (toggle && nonVirtualItem != null)
        {
            tooltipPanel.SetActive(true);
            title.text = nonVirtualItem.name;
            description.text = nonVirtualItem.description;
        }
        else
        {
            tooltipPanel.SetActive(false);
        }
    }

    public void TooltipClose()
    {
        if (toggle)
        {
            toggle = !toggle;
            tooltipPanel.SetActive(false);
        }
    }

    public void OnRemoveButton()
    {
        NonVirtualItems.instance.Remove(nonVirtualItem);
    }

}
