using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour {

    int count = 0;
    public int value;
    public GameObject moneyDrop;
    bool overTextEntity = false;
    private GameObject shop;
    private Player player;

    void Start () {
        shop = GameObject.Find ("Shop");
        player = GameObject.Find ("Player").GetComponent<Player> ();
    }

    void Update () {

        if (Input.touchCount > 0 && player.hasItemEquipt ()) {
            Touch touch = Input.GetTouch (0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint (touch.position);
            if (count == 0 && (touchPos.x > transform.position.x && touchPos.x < transform.position.x + 1 &&
                    touchPos.y < transform.position.y && touchPos.y > transform.position.y - 1) && (!EventSystem.current.IsPointerOverGameObject ())) {
                //  if (shop.activeSelf) shop.SetActive (false);
                string objectName = transform.name.Replace ("(Clone)", "");
                if(player.getEquiptItem().canBreak(objectName)) {
                GameObject drop = Instantiate (moneyDrop, new Vector2 (touch.position.x + 100f, touch.position.y + 100f), Quaternion.identity, GameObject.Find ("Canvas").transform) as GameObject;
                drop.GetComponent<MoneyDrop> ().setValue (value);
                Destroy (gameObject);
                }
            }
            count++;
        } else if (Input.GetMouseButtonDown (0) && player.hasItemEquipt ()) {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if (count == 0 && (clickPos.x > transform.position.x && clickPos.x < transform.position.x + 1 &&
                    clickPos.y < transform.position.y && clickPos.y > transform.position.y - 1) && (!EventSystem.current.IsPointerOverGameObject ())) {
                string objectName = transform.name.Replace ("(Clone)", "");
                if(player.getEquiptItem().canBreak(objectName)) {
                // if (shop.activeSelf) shop.SetActive (false);
                GameObject drop = Instantiate (moneyDrop, new Vector2 (Input.mousePosition.x + 100f, Input.mousePosition.y + 100f), Quaternion.identity, GameObject.Find ("Canvas").transform) as GameObject;
                drop.GetComponent<MoneyDrop> ().destination = GameObject.Find ("MoneyCounterText");
                drop.GetComponent<MoneyDrop> ().setValue (value);
                Destroy (gameObject);
                }
            }
            count++;
        } else {
            count = 0;

        }

    }
}