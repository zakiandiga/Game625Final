using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipes", menuName = "Recipe")]
public class CraftingRecipes : ScriptableObject
{
    public string itemName = "NewItem";
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType
    {
        Material,
        Part,
        Equipment,
        Tool,
        Consumable
    }

    public List<Item> requiredMaterials;
    public List<Item> requiredTools;
}

// reference link: https://www.youtube.com/watch?v=bTPEMt1RG3s