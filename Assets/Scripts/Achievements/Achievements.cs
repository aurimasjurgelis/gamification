using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
	#region Singleton
	public static Achievements instance;

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


	public delegate void OnAchievementChanged();
	public OnAchievementChanged onAchievementChangedCallback;



	public int space = 8;

	public List<Achievement> achievements = new List<Achievement>();

    public void Start()
    {
		if(achievements.Count > 0)
        {
			
			//onAchievementChangedCallback.Invoke();
        }			
    }

    public bool Add(Achievement item)
	{

			if (achievements.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}
			achievements.Add(item);

			if (onAchievementChangedCallback != null)
			{
			Debug.Log("this callback is not null");
				onAchievementChangedCallback.Invoke();
			} 
		
		return true;
	}
}
