using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rig;

    [Header("Status")]
    public float speed;
    public int damage;
    public int score;

    [Header("Rotation")]
    public bool isRight;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 0.5f);
    }

    private void FixedUpdate()
    {
        if(isRight)
        {
            rig.velocity = Vector2.right * speed;
        }
        if(!isRight)
        {
            rig.velocity = Vector2.left * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Player>().IncreasePoints(score);
            Destroy(gameObject);
        }
    }
}
