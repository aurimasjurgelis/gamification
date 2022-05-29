using UnityEngine;

public class InventoryUI : MonoBehaviour
{

	public Transform itemsParent;

	public GameObject inventoryUI;

	InventorySlot[] slots;

	Inventory inventory;
	private void Start()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		Debug.Log("Inventory Slots length: " + slots.Length);

		if(Inventory.instance.items.Count > 0)
        {
			UpdateUI();
        }

	}


	void UpdateUI()
	{
		for(int i = 0;i < slots.Length;i++)
		{
			if(i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			} else
			{
				slots[i].ClearSlot();
			}
		}
	}

}
