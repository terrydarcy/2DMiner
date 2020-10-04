using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

    public Inventory inventory;
    private float money = 0;
    private MoneyCounter moneyCounter;
    private Shop_Inventory shop_Inventory;
    private Item currentItem;
    [SerializeField] private UI_Inventory UI_Inventory;
    [SerializeField] private UI_Shop_Inventory UI_Shop_Inventory;
    private float count = 0;
    private Transform cursorToolRect;

    void Start () {
        cursorToolRect = transform.Find ("CursorTool");
        moneyCounter = GameObject.Find ("MoneyCounterText").GetComponent<MoneyCounter> ();
        inventory = new Inventory ();
        shop_Inventory = new Shop_Inventory ();
        UI_Inventory.setInventory (inventory);
        UI_Shop_Inventory.setInventory (shop_Inventory);
    }

    void FixedUpdate () {

        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject () && hasItemEquipt ()) {
            Touch touch = Input.GetTouch (0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint (touch.position);
            if (count == 0) {
                RectTransform cursorTool = Instantiate (cursorToolRect, transform).GetComponent<RectTransform> ();
                cursorTool.gameObject.SetActive (true);
                cursorTool.GetComponent<SpriteRenderer> ().sprite = getEquiptItem ().getSprite ();
                cursorTool.position = new Vector2 (touchPos.x,touchPos.y);
                count++;
            }
        } else {
            count = 0;
        }
        if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject () && hasItemEquipt ()) {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if (count == 0) {
                RectTransform cursorTool = Instantiate (cursorToolRect, transform).GetComponent<RectTransform> ();
                cursorTool.gameObject.SetActive (true);
                cursorTool.GetComponent<SpriteRenderer> ().sprite = getEquiptItem ().getSprite ();
                cursorTool.position = new Vector2 (clickPos.x,clickPos.y);
                count++;
            }
        } else {
            count = 0;
        }

    }

    public void removeMoney (float num) {
        if (money >= num) {
            money -= num;
            moneyCounter.updateMoney (money);
        }
    }

    public void addMoney (float num) {
        money += num;
        moneyCounter.updateMoney (money);
    }

    public void equip (Item item) {
        if (item.isEquipable ()) {
            this.currentItem = item;
        }
    }

    public bool hasItemEquipt () {
        if (currentItem == null) return false;
        else return true;
    }

    public Item getEquiptItem () {
        if (hasItemEquipt ()) {
            return currentItem;
        } else {
            return null;
        }
    }

    public float getMoney () {
        return money;
    }
}