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

       

            int randomNumber = Random.Range(1, inventoryItemList.itemList.Count - 1);


          
                GameObject randomLootItem = (GameObject)Instantiate(inventoryItemList.itemList[0].itemModel);
                PickUpItem item = randomLootItem.AddComponent<PickUpItem>();
                item.item = inventoryItemList.itemList[0];

          
                

    }

}
