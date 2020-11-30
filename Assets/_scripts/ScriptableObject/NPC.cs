using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPC : ScriptableObject
{
    new public string name = "NPC name";
    public Sprite icon;
    public GameObject prefab;

}
