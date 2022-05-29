using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

	public EquipmentSlot equipSlot;

	public override void Use()
	{
		//base.Use();
		//EquipmentManager.instance.Equip(this);
		////remove it from the inventory
		//RemoveFromInventory();
		Debug.Log("Equipment Item Used!");
	}

}

public enum EquipmentSlot
{
	Head,
	Chest,
	Legs,
	Feet,
	Weapon,
	Shield,
	PowerUp
}
