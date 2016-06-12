using UnityEngine;
using System.Collections;

public class Healthloot : MonoBehaviour {

    public int amountOfLoot = 5;

    static ItemDataBaseList inventoryItemList;

    int counter = 0;

    // Use this for initialization
    void Start()
    {

        inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
        StorageInventory loot = GetComponent<StorageInventory>();
        int id = 0;

        for (int i = 0; i < amountOfLoot; i++)
        {


            int dropChance = Random.Range(0, 100);


            if (dropChance > 60)
                continue;
            else if (dropChance > 0 && dropChance < 10)
                id = 6;
            else if (dropChance > 10 && dropChance < 30)
                id = 5;
            else
                id = 7;







            Item item = inventoryItemList.getItemByID(id);
            item.itemValue = 1;
            loot.addItem(item);


        }

    }
}
