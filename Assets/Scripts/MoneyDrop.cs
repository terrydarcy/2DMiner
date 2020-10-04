using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDrop : MonoBehaviour {

    GameObject moneyCounter;
    private Player player;
    public float num;
    Text txt;
    public Material green;
    public Material red;
    public GameObject destination;
    private Vector3 startPos;
    public float lerpSpeed = 10.0F;
    private float startTime;
    private float journeyLength;
    private float timer = 0;
    public float pauseTime = 50f;
    private float pauseCount = 0;

    void Start () {
        player = GameObject.Find ("Player").GetComponent<Player> ();
        moneyCounter = GameObject.Find ("MoneyCounterText");
        txt = gameObject.GetComponent<Text> ();
        startPos = gameObject.transform.position; //new Vector3 (gameObject.transform.position.x - 10f, gameObject.transform.position.y,gameObject.transform.position.z);
        journeyLength = Vector3.Distance (startPos, destination.transform.position);
    }

    public void setValue (float val) {
        txt = gameObject.GetComponent<Text> ();
        num = val;
        if (num <= 0) {
            txt.text = "-$" + Mathf.Abs (val).ToString ();
            gameObject.GetComponent<Text> ().material = red;
        } else {
            txt.text = "+$" + Mathf.Abs (val).ToString ();
            gameObject.GetComponent<Text> ().material = green;
        }
    }

    void FixedUpdate () {
        timer++;
        if (timer > pauseTime) {
            if (pauseCount == 0) {
                startTime = Time.time;
                pauseCount++;
            }
            float distCovered = (Time.time - startTime) * lerpSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            gameObject.transform.position = Vector3.Lerp (startPos, destination.transform.position, fractionOfJourney);

        }
        if (gameObject.transform.position == destination.transform.position) {
            player.addMoney (num);
            UI_Shop_Inventory.canBuy = true;
            Destroy (gameObject);
        }
    }
}