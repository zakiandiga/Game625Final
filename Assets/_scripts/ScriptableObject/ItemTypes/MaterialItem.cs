using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Material")]
public class MaterialItem : Item
{
    
    public override void Use()
    {
        base.Use();
        //Display description tooltip
        //Broadcast this.material is used, observed by crafting logic

        //How to make it behave differently based on crafting menu Enabled?
        Debug.Log("Using MATERIAL " + name);

    }
}
