using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Hat : MonoBehaviour
{

    public float HatSpeed;
    public GameObject Fedora;
    public float currentTime;
    public float startingTime = 2f;
    private GameObject Fed;
    public bool hasShot;
    public GameObject player;
    
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

        while (GameObject.Find("Fedora(Clone)"))
        {
            currentTime -= 1 * Time.deltaTime;
            if (currentTime<=0)
            {
               Fed.transform.position = Vector3.MoveTowards(Fed.transform.position,player.transform.position,100f);
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
            Fed =  Instantiate(Fedora,transform.position,quaternion.identity);
            Fed.GetComponent<Rigidbody2D>().AddTorque(200f);
            Fed.GetComponent<Rigidbody2D>().velocity = new Vector2(HatSpeed, 0f);
        }

        if (transform.localScale.x < 0)
        {
            hasShot = true;
            Fed =  Instantiate(Fedora,transform.position,quaternion.identity);
            Fed.GetComponent<Rigidbody2D>().AddTorque(200f);
            Fed.GetComponent<Rigidbody2D>().velocity = new Vector2(-HatSpeed, 0f);
        }
    }
    
    
    
    
    
}
