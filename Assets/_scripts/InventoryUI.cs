using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //Put this in Start() for static slot number

        PlayerMovement.OnOpenMenu += OpenMenu;
    }

    private void OnDisable()
    {
        PlayerMovement.OnOpenMenu -= OpenMenu;
    }

    private void OpenMenu(PlayerMovement p)
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");

        for (int i = 0; i < slots.Length; i++)  //loop through item slot to find an item to add
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot(); //if no more item on the inventory, but there are still UI slot
            }
        }
    }
}
