using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour {

    public float money = 0f;
    Text txt;
    private GameObject player;

    void Start () {
        player = GameObject.Find ("Player");
        txt = gameObject.GetComponent<Text> ();
    }

    void Update () {
        txt.text = "$" + Mathf.Abs(money).ToString ();

        if (money >= 10) transform.localPosition = new Vector3 (393.1f, 628.2f, 0f);
        if (money >= 100) transform.localPosition = new Vector3 (355.0f, 628.2f, 0f);
        if (money >= 1000) transform.localPosition = new Vector3 (315.0f, 628.2f, 0f);
        if (money >= 10000) transform.localPosition = new Vector3 (274.48f, 628.2f, 0f);
    }

    public void updateMoney (float num) {
        money = num;
    }

}