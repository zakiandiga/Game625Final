using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblingLogic : MonoBehaviour
{

    public static AssemblingLogic instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Assembling instance found!");
            return;
        }
        instance = this;
    }

    public Button assemblingButton;

    public GolemBlueprint currentGolem; //Should be assigned when player choose it, from blueprint selection for example
    public Transform spawnPoint;

    public int assemblySlot = 3; //this should be specific according to the blueprints later
    public List<Item> parts = new List<Item>();

    [SerializeField] ParticleSystem assembleParticle = null;

    public bool AddPart(Item part)  //Check if all items already in the blueprint slots to activate the button
    {

        parts.Add(part);  //how to send this info to the UI?

        if (parts.Count >= assemblySlot)
        {
            AssembleCheck();
            return false;
        }

        return true;
    }

    void AssembleCheck()
    {
        assemblingButton.interactable = true;
        // send message to UI
    }

    public void Assemble()
    {
        assembleParticle.Play();
        Invoke("InstantiateGolem", 0.3f);
        Debug.Log("Golem created!!");

        //How to clean the parts from the list?

        //foreach (Item part in parts)
        //{
        //    parts.Remove(part);
        //}

        parts.Clear();

        assemblingButton.interactable = false;
    }

    void InstantiateGolem()
    {
        Instantiate(currentGolem.golemResult, spawnPoint.position, Quaternion.identity);
        //Instantiated or pooled?

    }

}
