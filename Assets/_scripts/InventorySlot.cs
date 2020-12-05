using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    /*
     * ITEM CONTROL
     * A: Use
     * B: Drop
     * X: Detail 
     * 
     */

    public void DetailItem()
    {
        //Open/Close tooltip window
        //Reference Tooltip window here, SetActive control here
        //Tooltip window is a part of InventorySlot control
        Debug.Log("Item description opened");
    }

    public void DropItem()  //UI Button triggered
    {
        //Open Confirm window
        //reference confirm window here
        //c
        //Instantiate item in world

        Inventory.instance.RemoveItem(item);
    }

    public void UseItem() //UI Button triggered
    {
        if(item != null)
        {
            item.Use();
        }

        //Temporary for golem assembly demo
        //add item to assembling UI & logic
        AssemblingLogic.instance.AddPart(item);


        ClearSlot();
    }
}
