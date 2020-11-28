using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "NewItem";
    public Sprite icon;
    public ItemType itemType; //should I describe it here or in Interactable?

    public enum ItemType
    {
        Material,
        Part,
        Equipment,
        Tool,
        Consumable
    }

    public virtual void Use()
    {
        //use effect (consume, nothing, equip, open craft menu, etc)

        Debug.Log("Using " + name);
    }
}
    
