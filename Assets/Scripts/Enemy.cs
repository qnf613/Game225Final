using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //TODO:apply animation
    //components
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anima;
    [SerializeField] GameObject target;
    [SerializeField] GameObject bullet;
    [SerializeField] private int HP;
    //enemy variation - chaser
    [SerializeField] private bool playerChaser = false;
    [SerializeField] private bool isChasing;
    //enemy variation - spitter
    [SerializeField] private bool Spitter = false;
    [SerializeField] private bool isLockingOn;
    [SerializeField] private float curtime;
    [SerializeField] private float cooltime;
    private int nextMove;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anima = GetComponent<Animator>();
        StartCoroutine("ChangeMovement");
        
    }

    // Update is called once per frame
    private void Update()
    {
        //Death & destory
        if(HP <= 0)
        {
            Destroy(gameObject);
        }

        curtime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move();
        if (isLockingOn)
        {
            Spit();
        }
    }

    private void Move()
    {
        //moving && animations
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        //if (rigid.velocity.normalized.x != 0)
        //{
        //    anima.SetBool("isWalking", true);
        //}
        //else
        //{
        //    anima.SetBool("isWalking", false);
        //}
        if (isChasing)
        {
            Vector3 targetPos = target.transform.position;
            if (targetPos.x < transform.position.x)
            {
                nextMove = -1;
            }
            else if (targetPos.x > transform.position.x)
            {
                nextMove = 1;
            }
        }

        else
        {
            if (nextMove == -1)
            {
                nextMove = -1;
            }
            else if (nextMove == 1)
            {
                nextMove = 1;
            }
        }

    }

    private void Spit()
    {
    //    transform.rotation = new Vector2(target.)
        if (curtime <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            curtime = cooltime;
        }
    }


    //decide direction to go
    IEnumerator ChangeMovement()
    {
        //decide left -1, stop 0, right 1
        nextMove = Random.Range(-1, 2);
        ////flip the sprites when it facing right side
        //if (nextMove != 0)
        //{
        //    spriteRenderer.flipX = nextMove == 1;
        //}
        //makes the enemy's direction deciding more randomly
        float nextDirectionTime = Random.Range(2f, 4f);
        yield return new WaitForSeconds(nextDirectionTime);
        //repeat this method itself
        StartCoroutine("ChangeMovement");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //damaged by bullet
        if (collision.gameObject.CompareTag("Projectile"))
        {
            HP = HP - 3;
        }
    }


    private void OnTriggerEnter2D(Collider2D trigger)
    {
        //target player - chaser
        if (trigger.gameObject.CompareTag("Player") && playerChaser)
        {
            target = trigger.gameObject;
            isChasing = true;
            StopCoroutine("ChangeMovement");
        }
        //target player - spitter
        if (trigger.gameObject.CompareTag("Player") && Spitter)
        {
            target = trigger.gameObject;
            isLockingOn = true;
            StopCoroutine("ChangeMovement");
        }
    }

    private void OnTriggeStay2D(Collider2D trigger)
    {
        //chasing or lock on player
        if (trigger.gameObject.CompareTag("Player") && (playerChaser || Spitter))
        {
            StopCoroutine("ChangeMovement");
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        //stop chasing
        if (trigger.gameObject.CompareTag("Player") && playerChaser)
        {
            isChasing = false;
            StartCoroutine("ChangeMovement");
        }
        //stop lock on
        if (trigger.gameObject.CompareTag("Player") && Spitter)
        {
            isLockingOn = false;
            StartCoroutine("ChangeMovement");
        }
    }
}
