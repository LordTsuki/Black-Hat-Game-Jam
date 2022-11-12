
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Shoot : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rig;

    [Header("Status")]
    public float speed;
    public int damage;
    //public int score;

    [Header("Rotation")]
    public bool isRight;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
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
            collision.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
