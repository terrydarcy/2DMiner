using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public float life = 50;
    private float timer = 0;

    void Start () {
        //life = Random.Range (20, 40);
    }

    void Update () {
        timer++;
        if (timer >= life) {
            Destroy (gameObject);
        }
    }
}