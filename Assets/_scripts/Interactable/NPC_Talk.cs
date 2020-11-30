using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Talk : Interactable
{
    public NPC npc;

    public enum NPC_State
    {
        Talking,
        Idle,
        Busy
    }

    private NPC_State npcState = NPC_State.Idle;  //Here or on NPC_Behaviour script?

    public override void Interact()
    {
        base.Interact();

        //Tell player that there is an NPC to interact with (press [T] to talk)
        TalkToNPC(); //Change this later

    }

    // Update is called once per frame
    void TalkToNPC()
    {
        Debug.Log("Talking with " + npc.name);
        //Innitiate dialogue line(s)
    }
}
