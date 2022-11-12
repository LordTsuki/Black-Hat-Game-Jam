using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]


    [Header("Status")]
    public int health;
    public int damage;
    public int score;

    //[Header("Commands")]
    //private bool walkRight = true;
    //private float timer;

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

    }

    public void Damage(int damage)
    {
        health -= damage;
        //anim.SetTrigger("hit");

        if (health <= 0)
        {
            Destroy(gameObject);
            RandomSpawner.enemyNumber--;
            GameController.instance.UpdateKills(score);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
}
