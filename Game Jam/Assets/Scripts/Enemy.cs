using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
<<<<<<< HEAD
{
    [Header("Movement")]
    public float speed;
    public float walkTime;

    [Header("Status")]
    public int health;
    public int damage;

    [Header("Commands")]
    private bool walkRight = true;
    private float timer;

    [Header("Components")]
    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }
        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        //anim.SetTrigger("hit");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }
=======
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
>>>>>>> 8df377cd0ad4b5988e1bf9cdcc3924307ec7ee07
    }
}
