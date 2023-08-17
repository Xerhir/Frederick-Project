using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVMTST : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speedx;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speedx = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speedx * speed, rb.velocity.y);


        if (speedx>0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        else if (speedx<0)
        {
            transform.localScale = new Vector3(-1f, -1f, -1f);
        }
    }
}
