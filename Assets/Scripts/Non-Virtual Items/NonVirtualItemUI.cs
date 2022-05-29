using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVirtualItemUI : MonoBehaviour
{
	public static NonVirtualItemUI Instance { get; private set; }

	public Transform itemsParent;


	NonVirtualItemSlot[] slots;

	NonVirtualItems nonVirtualItems;

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
		nonVirtualItems = NonVirtualItems.instance;
		nonVirtualItems.onNonVirtualItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<NonVirtualItemSlot>();
		Debug.Log("Non-Virtual Item Slots length: " + slots.Length);

		if (NonVirtualItems.instance.nonVirtualItems.Count > 0)
		{
			UpdateUI();
		}
	}


    public void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < nonVirtualItems.nonVirtualItems.Count)
			{
				slots[i].AddNonVirtualItem(nonVirtualItems.nonVirtualItems[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}
}
