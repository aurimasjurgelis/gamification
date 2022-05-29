using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVirtualItems : MonoBehaviour
{
	#region Singleton
	public static NonVirtualItems instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance detected!");
			return;
		}
		instance = this;
	}
	#endregion


	public delegate void OnNonVirtualItemChanged();
	public OnNonVirtualItemChanged onNonVirtualItemChangedCallback;



	public int space = 8;

    public List<NonVirtualItem> nonVirtualItems = new List<NonVirtualItem>();


    public void Start()
    {
		if(nonVirtualItems.Count > 0)
        {
			//onNonVirtualItemChangedCallback.Invoke();
        }			
    }

    public bool Add(NonVirtualItem item)
	{

			if (nonVirtualItems.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}
		nonVirtualItems.Add(item);

			if (onNonVirtualItemChangedCallback != null)
			{
			Debug.Log("this callback is not null");
			onNonVirtualItemChangedCallback.Invoke();
			} 
		
		return true;
	}

	public void Remove(NonVirtualItem item)
	{
		nonVirtualItems.Remove(item);
		if (onNonVirtualItemChangedCallback != null)
		{
			onNonVirtualItemChangedCallback.Invoke();
		}
	}
}
