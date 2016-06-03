using UnityEngine;
using System.Collections;

public class WeaponLoot : MonoBehaviour
{

    public int amountOfLoot = 10;
    static ItemDataBaseList inventoryItemList;

    int counter = 0;

    // Use this for initialization
    void Start()
    {

        inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
        StorageInventory loot = GetComponent<StorageInventory>();

        for (int i = 0; i < inventoryItemList.itemList.Count; i++)
        {
            

            Item item = inventoryItemList.getItemByID(i);
            item.itemValue = 1;

            if (item.itemType == ItemType.Weapon)
                loot.addItem(item);

        }
            
    }

}
