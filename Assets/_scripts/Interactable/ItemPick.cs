using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : Interactable
{
    public Item item;

    //Item object exist in the world

    public override void Interact()
    {
        

        PickUp(); //Tell player to pick the item instead of directly PickUp()
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.AddItem(item);

        if (wasPickedUp)
            Destroy(this.gameObject);
    }
}
