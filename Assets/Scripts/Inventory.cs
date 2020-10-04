using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public List<Item> itemList;

    //https://youtu.be/2WnAOV7nHW0?t=553

    public Inventory () {
        itemList = new List<Item> ();
        
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

    public List<Item> GetItemList () {
        return itemList;
    }
}