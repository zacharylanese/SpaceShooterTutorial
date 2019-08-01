using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
     public float speed;
     private Rigidbody rb;

     void Start()
     {
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
     }
     void Update()
     {
          if (GameController.zPress == true)
          {
               speed = -10;
          }
     }
}