using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one Inventory instance found!");
            return;
        }
        instance = this;
    }
    #endregion

    public int itemSpace = 20;
    public List<Item> items = new List<Item>();

    public delegate void OnItemChange();  //Why delegate over static event action?
    public OnItemChange onItemChangeCallback;

    public bool AddItem(Item item)
    {
        if(items.Count >= itemSpace)
        {
            Debug.Log("Your backpack is full!");
            return false;
        }
        items.Add(item);
        //If needed, add condition so that item cannot be added to the list (On the scriptable object)
        //Unpickable for example

        if (onItemChangeCallback != null)
            onItemChangeCallback.Invoke();

        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangeCallback != null)
            onItemChangeCallback.Invoke();
    }
}
