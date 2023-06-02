using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairLeftnRight : MonoBehaviour
{
    private float lowX;
    public float range = 2f;
    public float speed = 0.005f;
    private int X = 1;
    // Start is called before the first frame update
    void Start()
    {
        lowX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * X, transform.position.y);
        if (transform.position.x < lowX || transform.position.x > lowX + range)
        {
            X *= -1;
        }
        Debug.Log("LnR");


    }
}
