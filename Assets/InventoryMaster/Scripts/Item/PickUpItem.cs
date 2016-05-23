using UnityEngine;
using System.Collections;



public class PickUpItem : MonoBehaviour
{
    public Item item;
    private Inventory _inventory;
    private GameObject _player;
    // Use this for initialization


    private bool actionPressed;

    void Start()
    {
        actionPressed = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
            _inventory = _player.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        /* actionPressed = (Input.GetKeyDown(KeyCode.E));
         if (actionPressed)
             Debug.Log("actionPressed Down");*/
        
          

    }


    void OnTriggerStay2D(Collider2D other)
    {


        if (Input.GetKey(KeyCode.E)) { 

        
        bool check = _inventory.checkIfItemAllreadyExist(item.itemID, item.itemValue);
        if (check)
            Destroy(this.gameObject);
        else if (_inventory.ItemsInInventory.Count < (_inventory.width * _inventory.height))
        {
            _inventory.addItemToInventory(item.itemID, item.itemValue);
            _inventory.updateItemList();
            _inventory.stackableSettings();
            Destroy(this.gameObject);
        }
        }



    }

}