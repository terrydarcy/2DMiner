using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockGen : MonoBehaviour {

    //int blockSize = 10;
    int levelWidth;
    int levelHeight;

    public GameObject grass;
    public GameObject dirt;
    public GameObject stone;
    public GameObject coal;

    void Start () {
        levelWidth = 13;
        levelHeight = 1000;

        Vector2 topLeft = Camera.main.ScreenToWorldPoint (new Vector2 (0, Screen.height));

        for (int yy = 0; yy < levelHeight; yy++) {
            for (int xx = 0; xx < levelWidth; xx++) {
                GameObject currentBlock = dirt;
                if (yy == 0) currentBlock = grass;
                if (yy > Random.Range (1, 100)) {
                    currentBlock = stone;
                }
                if (yy > 100) {
                    if (Random.Range (0, 100) < 90) currentBlock = stone;
                    else if (Random.Range (0, 100) < 50) {
                        currentBlock = dirt;
                    } else if (Random.Range (0, 100) < 30 && xx < 10) {
                        currentBlock = coal;
                    }
                }
                GameObject block = Instantiate (currentBlock, new Vector2 ((topLeft.x - 0.001F) + xx, topLeft.y - yy), Quaternion.identity, GameObject.Find ("BlockHolder").transform) as GameObject;
            }
        }

    }

    void Update () {

    }
}