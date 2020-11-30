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

    public void Use() //can we store this in scriptable object?
    {
        //use effect (consume, nothing, equip, open craft menu, etc)
        //Can we make different implementations based on ItemType here?

        if(itemType == ItemType.Consumable)
        {
            //Consume the item
        }
        else
        {
            Debug.Log("Using " + name);
        }
        
    }
}
    
