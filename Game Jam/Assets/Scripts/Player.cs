using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Status")]
    public int health = 1;
    public float speed;
    public float jumpForce;
    private float movement;
    private int score;

    
    [Header("Checks")]
    public bool isJumping;
    public bool isShooting;

    [Header("Components")]
    private Rigidbody2D rig;
    private Animator anim;

   // public GameObject shoot;
   //public Transform shootPoint;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

      //  GameController.instance.UpdateScore(score);
    }

<<<<<<< HEAD

    private void Update()
    {
        //CannonShoot();
=======
    void Update()
    {
        CannonShoot();
        Jump();
>>>>>>> 46d6df766fd97700a0ab913e8eadc93decf0aa5d
    }
    void FixedUpdate()
    {
        Move();
    }
    /*
    void CannonShoot()
    {
        StartCoroutine("ShootLaser");
    }
<<<<<<< HEAD
 
    IEnumerator Shoot()
=======

    IEnumerator ShootLaser()
>>>>>>> 46d6df766fd97700a0ab913e8eadc93decf0aa5d
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isShooting = true;
            anim.SetInteger("Transition", 3);
            GameObject Shoot = Instantiate(shoot, shootPoint.position, shootPoint.rotation);

            if (transform.rotation.y == 0)
            {
                Shoot.GetComponent<Shoot>().isRight = true;
            }
            if (transform.rotation.y == 180)
            {
                Shoot.GetComponent<Shoot>().isRight = false;
            }

            yield return new WaitForSeconds(0.2f);
            isShooting = false;
            anim.SetInteger("Transition", 0);
        }
    }
    public void Damage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("death");

        if(health <= 0)
        {
            GameController.instance.GameOver();
        }
    }
    */
    void Move()
    {
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        /*
        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 2);
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (movement < 0 && !isJumping)
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
        */
    }
    
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            //anim.SetInteger("Transition", 1);
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }
<<<<<<< HEAD
    void OnCollisionEnter2D(Collision2D col)
=======

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
>>>>>>> 46d6df766fd97700a0ab913e8eadc93decf0aa5d
    {
        if (col.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
        /*
        public void IncreasePoints(int kills)
        {
            score += kills;
            GameController.instance.UpdateScore(score);
        }
        */
    }
