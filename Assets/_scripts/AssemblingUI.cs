using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblingUI : MonoBehaviour
{
    public Button assemblingMenu;

    
    public Transform assemblingParent;
    public GolemBlueprint golem;
    private int blueprint = 1; //temporary

    public BlueprintSlot[] blueprintSlots;
    public List<Item> submittedItems;


    // Start is called before the first frame update
    void Start()
    {
        blueprintSlots = assemblingParent.GetComponentsInChildren<BlueprintSlot>();
    }

    void UpdateSlot()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
