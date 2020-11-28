using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    public Transform interactionTransform; 
    //Assign the item itself to interactionTransform if the interactable doesn't have restriction
    //Assign another object if specific point of transform needed (e.g. treasure chest face, car cockpit, etc)
    
    [SerializeField] Transform player; //Temporary public 

    bool isFocus = false;
    bool hasInteracted = false;


    public virtual void Interact()
    {
        Debug.Log("Interact with " + transform.name);
        //This function is being override on the interactable object scripts
        //for item, it could be picked by the player
        //Display floating button '[SPACE] Pick Item'
        //On player, add pickup item state, set space to pick item, announce item pick
        //here, OnItemPick Announce, if isFocus, destroy, add to inventory
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
    }


    private void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    private void Update()
    {
        if(!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Debug.Log(transform.name + " interact with player");
                Interact();
                hasInteracted = true;
                
            }
        }

    }

}
