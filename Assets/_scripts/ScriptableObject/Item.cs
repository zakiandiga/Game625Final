using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject 
    //Should make this abstract instead?
    //Item exist in player data and UI (soul of ItemPick)
{
    new public string name = "NewItem";
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType
    {
        Material,
        Part,
        Equipment,
        Tool,
        Consumable
    }
    //Should I seperate consumable and equipable items abstract class?

    public virtual void Use() //public because is used in InventorySlot
    {
        //use effect (consume, nothing, equip, open craft menu, etc)
        //Can we make different implementations based on ItemType here?

        //Is it better to seperate the scriptable objects of different ItemTypes?  
        Debug.Log("Using item " + name);
    }
}

//References: https://answers.unity.com/questions/1415831/inheritance-from-a-scriptableobject.html#:~:text=First%20thing%2C%20no%2C%20you%20can,the%20transitivity%20property%20of%20inheritance.

