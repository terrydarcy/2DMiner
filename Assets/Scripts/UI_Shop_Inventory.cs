using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Shop_Inventory : MonoBehaviour {

    private Shop_Inventory shop_Inventory;
    public Transform itemContainer;
    public Transform itemSlotRect;
    public Transform itemSlotText;
    public Transform itemButtonRow;
    public RectTransform content;
    public Transform itemInfoContainer;
    public Transform itemSelector;
    public Transform priceText;
    public Transform speedText;
    public Transform toolTipText;
    public Transform buyButton;
    public GameObject moneyDrop;
    public static bool canBuy = true;

    private void Awake () {

    }

    public void setInventory (Shop_Inventory shop_Inventory) {
        this.shop_Inventory = shop_Inventory;
        refreshInventoryItems ();
    }

    private void refreshInventoryItems () {
        int x = 0;
        int y = 0;
        int cellSize = 10;
        foreach (Transform child in itemInfoContainer) {
            GameObject.Destroy (child.gameObject);
        }
        foreach (Item item in shop_Inventory.GetItemList ()) {
            RectTransform itemSlotRectTransform = Instantiate (itemSlotRect, itemContainer).GetComponent<RectTransform> ();
            RectTransform itemSlotTextTransform = Instantiate (itemSlotText, itemContainer).GetComponent<RectTransform> ();
            RectTransform itemButton = Instantiate (itemButtonRow, itemContainer).GetComponent<RectTransform> ();
            itemButton.tag = item.getName ();
            if (EventSystem.current.currentSelectedGameObject != null) {
                if (item.getName () == EventSystem.current.currentSelectedGameObject.tag) {
                    RectTransform itemSelectorRect = Instantiate (itemSelector, itemContainer).GetComponent<RectTransform> ();
                    itemSelectorRect.gameObject.SetActive (true);
                    itemSelectorRect.anchoredPosition = new Vector2 ((x - 5f) * cellSize, y * cellSize);
                }
            }

            itemSlotRectTransform.gameObject.SetActive (true);
            itemSlotTextTransform.gameObject.SetActive (true);
            itemButton.gameObject.SetActive (true);

            itemSlotRectTransform.anchoredPosition = new Vector2 (x * cellSize, y * cellSize);
            itemSlotTextTransform.anchoredPosition = new Vector2 ((x + 37f) * cellSize, y * cellSize);
            itemButton.anchoredPosition = new Vector2 ((x - 5f) * cellSize, y * cellSize);

            itemSlotTextTransform.GetComponent<Text> ().text = item.getName ();
            Image image = itemSlotRectTransform.GetComponent<Image> ();
            image.sprite = item.getSprite ();
            content.sizeDelta = new Vector2 (content.sizeDelta.x, content.sizeDelta.y + 100f);
            //content.anchoredPosition = new Vector2 (x * cellSize, y * cellSize);

            y -= cellSize;
        }
    }
    private void Update () {
        if (EventSystem.current.currentSelectedGameObject == null) {
            foreach (Transform child in itemInfoContainer) {
                GameObject.Destroy (child.gameObject);
            }
        }
    }

    public void shopItemSelect () {
        //refreshInventoryItems ();
        int x = 0;
        int y = 0;
        int cellSize = 10;
        foreach (Transform child in itemInfoContainer) {
            GameObject.Destroy (child.gameObject);
        }
        foreach (Item item in shop_Inventory.GetItemList ()) {
            if (item.getName () == EventSystem.current.currentSelectedGameObject.tag) {
                RectTransform priceTextRect = Instantiate (priceText, itemInfoContainer).GetComponent<RectTransform> ();
                RectTransform speedTextRect = Instantiate (speedText, itemInfoContainer).GetComponent<RectTransform> ();
                RectTransform toolTipTextRect = Instantiate (toolTipText, itemInfoContainer).GetComponent<RectTransform> ();
                RectTransform buyButtonRect = Instantiate (buyButton, itemInfoContainer).GetComponent<RectTransform> ();
                buyButtonRect.tag = item.getName ();

                priceTextRect.gameObject.SetActive (true);
                speedTextRect.gameObject.SetActive (true);
                toolTipTextRect.gameObject.SetActive (true);
                buyButtonRect.gameObject.SetActive (true);

                priceTextRect.anchoredPosition = new Vector2 ((x - 4f) * cellSize, y * cellSize);
                speedTextRect.anchoredPosition = new Vector2 ((x - 4f) * cellSize, (y - 5.5f) * cellSize);
                toolTipTextRect.anchoredPosition = new Vector2 ((x - 4f) * cellSize, (y - 11f) * cellSize);
                buyButtonRect.anchoredPosition = new Vector2 (59.3f, -170.8f);
                if (item.getPrice () == 0) {
                    priceTextRect.GetComponent<Text> ().text = "price: free";
                } else {
                    priceTextRect.GetComponent<Text> ().text = "price: $" + item.getPrice ().ToString ();

                }
                speedTextRect.GetComponent<Text> ().text = "mining speed: " + item.getMineSpeed ();
                toolTipTextRect.GetComponent<Text> ().text = item.getToolTip ();
            }
        }
    }

    public void buy () {
        foreach (Item item in shop_Inventory.GetItemList ()) {
            if (item.getName () == EventSystem.current.currentSelectedGameObject.tag) {
                if (shop_Inventory.canAfford (item) && canBuy) {
                    canBuy = false;
                    shop_Inventory.buyItem (item);
                    GameObject drop = Instantiate (moneyDrop, new Vector2 (buyButton.transform.position.x + 100f, buyButton.transform.position.y), Quaternion.identity, GameObject.Find ("Canvas").transform) as GameObject;
                    drop.GetComponent<MoneyDrop> ().destination = GameObject.Find ("MoneyCounterText");
                    drop.GetComponent<MoneyDrop> ().setValue (-item.getPrice ());
                }
            }
        }
    }

}