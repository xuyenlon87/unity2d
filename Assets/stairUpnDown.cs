using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairUpnDown : MonoBehaviour
{
    private float lowY;
    public float range = 2;
    public float speed = 0.02f;
    private int X = 1;
    // Start is called before the first frame update
    void Start()
    {
        lowY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * X);
            if(transform.position.y < lowY || transform.position.y > lowY + range)
        {
            X *= -1;
        }
    }
}
