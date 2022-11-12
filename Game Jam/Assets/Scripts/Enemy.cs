using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    private Rigidbody2D enemyRb;
 
    public float moveSpeed;
  
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        enemyRb.velocity = new Vector2(moveSpeed, enemyRb.velocity.y);
    }
}
