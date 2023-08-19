using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHat : MonoBehaviour
{
    public Transform _player;
    bool isShooting;
    bool isComingBack;
    Vector2 direction;
    float timer;
    public float totalAirTime = 2f;
    public float speed = 300f;
    Rigidbody2D rb;

    public void Awake()
    {
        this.enabled = false;
        rb = GetComponent<Rigidbody2D>(); 
    }

    public void Setup(Transform player)
    {
        _player = player;
    }

    public void Shoot()
    {
        //get player look rotation
        if(isShooting) return;
        this.enabled = true;
        isShooting = true;
        direction = new Vector2( Mathf.Sign(_player.localScale.x), 0f);
    }

    public void Stop()
    {
        this.enabled = false;
        isShooting = false;
    }

    public void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        isComingBack = timer > totalAirTime /2f;
        Vector3 newPos;
        if(isComingBack) 
        {
            newPos = Vector3.Lerp(rb.position, _player.position, ((timer/totalAirTime)-.5f)*2f );
        }
        else
        {
            newPos = rb.position + speed  * Time.fixedDeltaTime * direction;
        }   
     
    
        rb.MovePosition(newPos);

        if(timer > totalAirTime) Stop();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            Stop();
        }
        
    }
}
