using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualItems : MonoBehaviour
{
    #region Singleton
    public static VirtualItems instance;

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


    public delegate void OnVirtualItemChanged();
    public OnVirtualItemChanged onVirtualItemChangedCallback;



    public int space = 8;

    public List<VirtualItem> virtualItems = new List<VirtualItem>();

    public void Start()
    {
        if (virtualItems.Count > 0)
        {
            //onVirtualItemChangedCallback.Invoke();
        }
    }

    public bool Add(VirtualItem item)
    {

        if (virtualItems.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        virtualItems.Add(item);

        if (onVirtualItemChangedCallback != null)
        {
            Debug.Log("this callback is not null");
            onVirtualItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(VirtualItem item)
    {
        virtualItems.Remove(item);
        if (onVirtualItemChangedCallback != null)
        {
            onVirtualItemChangedCallback.Invoke();
        }
    }
}
