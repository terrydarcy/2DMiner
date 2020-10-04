using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.007f;
    float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer+= 0.000000001f;
        speed+=timer;

        transform.position += new Vector3(0,speed,0f) ;
    }
}
