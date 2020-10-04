using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour {

    private Inventory inventory;
    private Transform itemContainer;
    private Transform itemSlotRect;
    private Transform itemSlotSelector;
    private Transform itemButtonRect;
    private Player player;

    private void Awake () {
        itemContainer = transform.Find ("ItemContainer");
        itemSlotRect = transform.Find ("ItemSlotRect");
        itemButtonRect = transform.Find ("ItemButton");
        itemSlotSelector = transform.Find ("ItemSlotSelector");
        player = GameObject.Find ("Player").GetComponent<Player> ();
    }

    public void setInventory (Inventory inventory) {
        this.inventory = inventory;
        refreshInventoryItems ();
    }

    void Start () {

    }

    void Update () {

    }

    public void refreshInventoryItems () {
        int x = 0;
        int y = 0;
        int cellSize = 10;
        foreach (Transform child in itemContainer) {
            GameObject.Destroy (child.gameObject);
        }
        foreach (Item item in inventory.GetItemList ()) {
            RectTransform itemSlotRectTransform = Instantiate (itemSlotRect, itemContainer).GetComponent<RectTransform> ();
            RectTransform itemSlotSelectorTransform = Instantiate (itemSlotSelector, itemContainer).GetComponent<RectTransform> ();
            itemSlotRectTransform.gameObject.SetActive (true);
            itemSlotSelectorTransform.gameObject.SetActive (true);
            itemSlotRectTransform.tag = item.getName ();
            itemSlotSelectorTransform.tag = item.getName () + "";
            itemSlotRectTransform.anchoredPosition = new Vector2 (x * cellSize, y * cellSize);
            itemSlotSelectorTransform.anchoredPosition = new Vector2 (x * cellSize, y * cellSize);
            Image image = itemSlotRectTransform.GetComponent<Image> ();
            image.sprite = item.getSprite ();
            y += cellSize;
        }
    }

    public void equip () {
        foreach (Item item in inventory.GetItemList ()) {
            if (item.getName () == EventSystem.current.currentSelectedGameObject.tag) {
                player.equip (item);
            }
        }
    }
}