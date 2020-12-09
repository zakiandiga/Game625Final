using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : Interactable
{
    public Item item;
    //private Pooler pool;

    //Item object exist in the world
    private void Start()
    {
        //pool = transform.parent.GetComponent<Pooler>();
    }

    public override void Interact()
    {
        PickUp(); //Tell player to pick the item instead of directly PickUp()
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.AddItem(item);

        if (wasPickedUp)
        //Destroy(this.gameObject);
        {
            MaterialPooler.Instance.ReturnToPool(this.gameObject);
            canInteract = false;
            hasInteracted = false;
        }
            
    }
}
