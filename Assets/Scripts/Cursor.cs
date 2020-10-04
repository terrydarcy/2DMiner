using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour {

    public GameObject woodPickaxe;

    int count = 0;

    void Start () { }

    void FixedUpdate () {

        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject ()) {
            Touch touch = Input.GetTouch (0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint (touch.position);
            if (count == 0) {
                Instantiate (woodPickaxe, touchPos, Quaternion.identity, GameObject.Find ("BlockHolder").transform);
                count++;
            }
        } else {
            count = 0;
        }
        if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if (count == 0) {
                Instantiate (woodPickaxe, clickPos, Quaternion.identity, GameObject.Find ("BlockHolder").transform);
                count++;
            }
        } else {
            count = 0;
        }

    }
}