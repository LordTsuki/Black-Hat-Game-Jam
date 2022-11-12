using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    [Header("Components")]
    private Transform target;
    private Rigidbody2D rig;
    private Animator anim;

    [Header("Status")]
    public float speed;
    public float selfDestruct;
    public int health;
    public int damage;
    public int score;
    public bool proximity;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void FixedUpdate()
    {
        Follow();
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

    void Follow()
    {
        //StartCoroutine("Dash");
        if (target.position.x > transform.position.x)
        {
            rig.velocity = Vector2.right * speed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (target.position.x < transform.position.x)
        {
            rig.velocity = Vector2.left * speed;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if(Vector2.Distance(transform.position, target.position) < 10)
        {
            proximity = true;
        }
        if(proximity)
        {
            //anim.SetInteger("Transition", 1);
            rig.velocity = Vector2.zero;
            //yield return new WaitForSeconds(1f);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }

        if(collision.gameObject.layer == 3)
        {
            Damage(damage);
        }
    }
}