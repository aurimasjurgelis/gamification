using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualItemUI : MonoBehaviour
{
	public static VirtualItemUI Instance { get; private set; }

	public Transform itemsParent;


	VirtualItemSlot[] slots;

	VirtualItems virtualItems;

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
		virtualItems = VirtualItems.instance;
		virtualItems.onVirtualItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<VirtualItemSlot>();
		Debug.Log("Virtual Items Slots length: " + slots.Length);

		if(VirtualItems.instance.virtualItems.Count > 0)
        {
			UpdateUI();
        }
	}



    public void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < virtualItems.virtualItems.Count)
			{
				slots[i].AddVirtualItem(virtualItems.virtualItems[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}
}
