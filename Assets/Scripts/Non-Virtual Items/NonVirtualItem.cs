using UnityEngine;

[CreateAssetMenu(fileName = "New Non-Virtual Item", menuName = "Rewards/Non-Virtual Item")]
public class NonVirtualItem : ScriptableObject
{
	[Header("Item Information")]
	new public string name = "New Item";
	public Sprite icon = null;
	public string description = "This is a description for the virtual item";

	[Header("Item Properties")]
	public int cost = 0;

	public virtual void Use()
	{

	}




}
