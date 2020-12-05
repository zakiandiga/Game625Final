using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblingLogic : MonoBehaviour
{
    //var blueprintType
    //Golem golem  // (scriptable object)

    //List blueprintSlots
    //List items submitted

    //On item submitted, add item to the blueprint slot
    //if blueprint slot is full, set active Assemble button

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

    public GolemBlueprint currentGolem;
    public Transform spawnPoint;

    public int assemblySlot = 3; //this should be specific per slot later
    public List<Item> parts = new List<Item>();

    public bool AddPart(Item part)
    {

        parts.Add(part);

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
    }

    public void Assemble()
    {

        Instantiate(currentGolem.golemResult, spawnPoint.position , Quaternion.identity);

        foreach (Item part in parts)
        {
            parts.Remove(part);
        }
        assemblingButton.interactable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
