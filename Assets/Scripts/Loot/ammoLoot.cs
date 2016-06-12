using UnityEngine;
using System.Collections;

public class ammoLoot : MonoBehaviour
{

    public int amountOfLoot = 2;

    static ItemDataBaseList inventoryItemList;

    int counter = 0;

    // Use this for initialization
    void Start()
    {

        inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
        StorageInventory loot = GetComponent<StorageInventory>();
      

        for (int i = 0; i < amountOfLoot; i++)
        {


            int dropChance = Random.Range(0, 100);


            if (dropChance > 30)
                continue;
            else {
                Item item = inventoryItemList.getItemByID(4);
                item.itemValue = 1;
                loot.addItem(item);
            }


        }

    }
}
