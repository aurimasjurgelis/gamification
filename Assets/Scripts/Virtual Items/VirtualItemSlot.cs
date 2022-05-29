using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VirtualItemSlot : MonoBehaviour
{
    [Header("Image")]
    public Image icon;

    [Header("Additional Information")]
    public GameObject tooltipPanel;
    public bool toggle = false;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;



    VirtualItem virtualItem;

    public void AddVirtualItem(VirtualItem newVirtualItem)
    {
        Debug.Log("Achievement Added!");
        virtualItem = newVirtualItem;
        icon.sprite = virtualItem.icon;
        cost.text = "Cost: " + virtualItem.cost.ToString();
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        virtualItem = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void TooltipToggle()
    {
        toggle = !toggle;
        if (toggle && virtualItem != null)
        {
            tooltipPanel.SetActive(true);
            title.text = virtualItem.name;
            description.text = virtualItem.description;
        }
        else
        {
            tooltipPanel.SetActive(false);
        }
    }

    public void TooltipClose()
    {
        if(toggle)
        {
            toggle = !toggle;
            tooltipPanel.SetActive(false);
        }
    }

    public void OnRemoveButton()
    {
        VirtualItems.instance.Remove(virtualItem);
    }

}
