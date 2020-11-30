using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemTalk : Interactable
{
    //public Golem golem; //Make Golem scriptable object

    //same case with NPC_Behaviour

    public override void Interact()
    {
        base.Interact();

        InteractToGolem();
    }

    void InteractToGolem()
    {
        Debug.Log("Interact with golem");

        //Open command menu
        //execute golem command -> broadcast for GolemBehaviour script?
        //talk
    }
}
