using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset;//khoảng cách từ cam đến player
    public Transform targetPlayer;//biến này gán vào player 
    private float lowY;
    void Start()
    {
        offset = transform.position - targetPlayer.position;
        lowY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = targetPlayer.position + offset;
        if(transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
