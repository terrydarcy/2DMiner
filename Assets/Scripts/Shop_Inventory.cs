using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Inventory {

    public List<Item> itemList;
    private Player player;
    public UI_Inventory playerInventory;

    public Shop_Inventory () {
        player = GameObject.Find ("Player").GetComponent<Player> ();
        playerInventory = GameObject.Find ("Inventory").GetComponent<UI_Inventory> ();
        itemList = new List<Item> ();
        addItem (new Item { itemType = Item.ItemType.woodPickaxe, amount = 1});
        addItem (new Item { itemType = Item.ItemType.woodShovel, amount = 1});
        addItem (new Item { itemType = Item.ItemType.woodSword, amount = 1});

    }

    public void addItem (Item item) {
        if (itemList.Count < 14) {
            itemList.Add (item);
        }
    }

    public void removeItem (Item item) {
        if (itemList.Count > 0) {
            itemList.Remove (item);
        }
    }

    public bool canAfford (Item item) {
        if (player.getMoney () >= item.getPrice ()) return true;
        else return false;
    }

    public void buyItem (Item item) {
        //player.removeMoney (item.getPrice ());
        player.inventory.addItem (item);
        playerInventory.refreshInventoryItems ();

    }

    public List<Item> GetItemList () {
        return itemList;
    }
}