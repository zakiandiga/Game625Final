using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Blueprint", menuName = "BluePrint")]
public class GolemBlueprint : ScriptableObject
{
    public string golemName = "NewGolem";
    public Sprite icon;
    
    public List<Item> requiredParts;

    public GameObject golemResult;
}

