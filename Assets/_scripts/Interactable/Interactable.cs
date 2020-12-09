using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float radius = 2f;

    public Transform interactionTransform; 
    //Assign the item itself to interactionTransform if the interactable doesn't have restriction
    //Assign another object if specific point of transform needed (e.g. treasure chest face, car cockpit, etc)
    
    [SerializeField] Transform player;
    [SerializeField] GameObject itemSign;
    TempInteractable tempInteractable;

    bool isFocus = false;
    public bool hasInteracted = false; //need to control from inherited script
    public bool canInteract = false;

    private void Awake() //or OnEnable()
    {
        itemSign = transform.Find("ItemSign").gameObject;
        player = GameObject.Find("Player").transform;
    }

    private void OnEnable()
    {
        PlayerMovement.OnInteract += InteractCheck;
    }

    private void OnDisable()
    {
        PlayerMovement.OnInteract -= InteractCheck;
    }

    public void InteractCheck(PlayerMovement player)
    {
        if (canInteract)
            Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("Interact with " + transform.name);
        //This function is being override on the interactable object scripts
        //for item, it could be picked by the player
        //Display floating button '[SPACE] Pick Item'
        //On player, add pickup item state, set space to pick item, announce item pick
        //here, OnItemPick Announce, if isFocus, destroy, add to inventory
    }
    //how to handle stacked interactible?



    private void OnTriggerEnter(Collider col)  //which is better? collider or calculate distance on Update()?
    {
        if(col.gameObject.tag == "Player" && !hasInteracted)
        {
            Debug.Log("Player TRIGGERED");
            canInteract = true;

            //Put the object on this class on the player so that the player only can interact with one interactable
            //if (col.gameObject.GetComponent<SomePlayerclass>().currentObjectPlayerInteractsWith == null)
            //    col.gameObject.GetComponent<SomePlayerclass>().currentObjectPlayerInteractsWith = this; 
            //check the distance on OnTriggerStay to prioritize who can interact with the player

            itemSign.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" && !hasInteracted)
        {
            Debug.Log("Player UNTRIGGERED");
            canInteract = false;
            //col.gameObject.GetComponent<SomePlayerclass>().currentObjectPlayerInteractsWith = null;
            itemSign.SetActive(false);
        }
            
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    /*
    private void Update()
    {
        if(!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Debug.Log(transform.name + " can interact with player");
                Interact();
                hasInteracted = true;


                
            }
        }

    }
    */

}
