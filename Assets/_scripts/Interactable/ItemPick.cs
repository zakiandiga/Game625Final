using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

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
