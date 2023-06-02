using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starCoinMove : MonoBehaviour
{
    public float speed = 0.005f;
    public float range = 0.1f;
    private float lowY;
    private int X = 1;
    // Start is called before the first frame update
    void Start()
    {
        lowY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(transform.position.x, gameObject.transform.position.y + speed * X);
        if (gameObject.transform.position.y < lowY || gameObject.transform.position.y > lowY + range)
        {
            X *= -1;
        }
    }
}

