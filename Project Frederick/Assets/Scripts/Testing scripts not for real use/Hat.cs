using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Hat : MonoBehaviour
{

    public float HatSpeed;
    public float currentTime;
    public float startingTime = 2f;
    public GameObject Fed;
    public bool hasShot;
    public GameObject player;
    public float hatBackSpeed;
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& hasShot==false)
        {
            Debug.Log(currentTime);
            ShootHat();
        }

        while (GameObject.Find("Fedora"))
        {
            currentTime -= 1 * Time.deltaTime;
            if (currentTime<=0)
            {
               Fed.transform.position = Vector3.MoveTowards(Fed.transform.position,player.transform.position,hatBackSpeed);
                hasShot = false;
                currentTime = startingTime;
            }
            break;
        }
        
    }



    public void ShootHat()
    {
        if (transform.localScale.x > 0)
        {
            hasShot = true;
            Fed.SetActive(true);
            Fed.GetComponent<Rigidbody2D>().AddTorque(200f);
            Fed.GetComponent<Rigidbody2D>().velocity = new Vector2(HatSpeed, 0f);
        }

        if (transform.localScale.x < 0)
        {
            hasShot = true;
            Fed.SetActive(true);
            Fed.GetComponent<Rigidbody2D>().AddTorque(200f);
            Fed.GetComponent<Rigidbody2D>().velocity = new Vector2(-HatSpeed, 0f);
        }
    }
    
    
    
    
    
}
