using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Status")]
    public int health = 1;
    public float speed;
    public float jumpForce;
    public float cannonCooldown;
    public int jetPack;
    private float movement;
    private int score;

    [Header("Checks")]
    public bool isJumping;
    public bool doubleJump;
    public bool isShooting;

    [Header("Components")]
    private Rigidbody2D rig;
    private Animator anim;
    public GameObject shoot;
    public Transform shootPoint;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jetPack = 0;
    }

    void Update()
    {
        CannonShoot();
        Jump();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Upgrade()
    {
        if (GameController.instance.score > 20)
        {
            jetPack= 1;
        }
        if (GameController.instance.score < 40)
        {
            cannonCooldown = 3f;
        }
        if (GameController.instance.score < 60)
        {
            cannonCooldown = 2f;
        }
        if (GameController.instance.score < 80)
        {
            cannonCooldown = 1f;
        }
        if (GameController.instance.score < 100)
        {
            cannonCooldown = 0.5f;
        }
        if (GameController.instance.score > 120)
        {
            jetPack = 2;
        }
    }

    void CannonShoot()
    {
        StartCoroutine("Laser");
    }

    IEnumerator Laser()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isShooting)
        {
            isShooting = true;
            anim.SetInteger("Transition", 3);
            GameObject Shoot = Instantiate(shoot, shootPoint.position, shootPoint.rotation);

            if(transform.rotation.y == 0)
            {
               Shoot.GetComponent<Shoot>().isRight = true;
            }
            if(transform.rotation.y == 180)
            {
               Shoot.GetComponent<Shoot>().isRight = false;
            }

            yield return new WaitForSeconds(cannonCooldown);
            isShooting = false;
            anim.SetInteger("Transition", 0);
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        anim.SetTrigger("death");

        if(health <= 0)
        {
            GameController.instance.GameOver();
        }
    }
    void Move()
    {
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 2);
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 2);
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movement == 0 && !isJumping && !isShooting)
        {
            anim.SetInteger("Transition", 0);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else
            {
                if (doubleJump && jetPack == 1)
                {
                    anim.SetInteger("Transition", 4);
                    rig.AddForce(new Vector2(0, jumpForce * 1.5f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
                if (doubleJump && jetPack == 2)
                {
                    anim.SetInteger("Transition", 4);
                    rig.AddForce(new Vector2(0, jumpForce * 2f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 3)
        {
            isJumping = false;
        }

        if (col.gameObject.layer == 9)
        {
            GameController.instance.GameOver();
        }
    }

    public void IncreasePoints(int kills)
    {
        score += kills;
        GameController.instance.UpdateKills(score);
    }
}