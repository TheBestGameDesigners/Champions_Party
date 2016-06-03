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

        for (int i = 0; i < inventoryItemList.itemList.Count; i++)
        {
            GetComponent<StorageInventory>().addItemToStorage(i, 1);

        }
            
    }

}
