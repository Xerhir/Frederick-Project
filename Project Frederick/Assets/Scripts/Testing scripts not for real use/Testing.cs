using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject player;
    public GameObject movingObject;
    public float moveAmount;
    void Start()
    {
        
    }

    void Update()
    {
       movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, player.transform.position, moveAmount);
    }
}
