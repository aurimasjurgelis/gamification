using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/Achievement")]
public class Achievement : ScriptableObject
{
	new public string name = "New Item";
	public Sprite icon = null;

	public string description = "This is a description";

	public virtual void Use()
	{

	}




}
