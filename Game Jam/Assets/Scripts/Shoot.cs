
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
        if (collision.gameObject.tag == "EnemyDrone")
        {
            collision.GetComponent<EnemyDrone>().Damage(damage);
            Destroy(gameObject);
        }
        /*if (collision.gameObject.tag == "EnemyWheel")
        {
            collision.GetComponent<EnemyWheel>().Damage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "EnemyAndroid")
        {
            collision.GetComponent<EnemyAndroid>().Damage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "EnemyBoss")
        {
            collision.GetComponent<EnemyBoss>().Damage(damage);
            Destroy(gameObject);
        }*/
    }
}
