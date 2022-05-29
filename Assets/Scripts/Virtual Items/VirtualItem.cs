using UnityEngine;

[CreateAssetMenu(fileName = "New Virtual Item", menuName = "Rewards/Virtual Item")]
public class VirtualItem : ScriptableObject
{
	[Header("Item Information")]
	new public string name = "New Item";
	public Sprite icon = null;
	public string description = "This is a description for the virtual item";

	[Header("Item Properties")]
	public int cost = 0;

	[Header("Item Relationship")]
	public Item item;


	public virtual void Use()
	{

	}




}
