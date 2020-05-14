using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //TODO:apply animation
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anima;
    [SerializeField] GameObject target;
    [SerializeField] private int HP;
    [SerializeField] private bool playerChaser = false;
    [SerializeField] private bool isChasing;
    private int nextMove;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anima = GetComponent<Animator>();
        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    public void Update()
    {
        //Death & destory
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Move()
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //damaged by bullet
        if (collision.gameObject.CompareTag("Projectile"))
        {
            HP = HP - 3;
        }
    }


    public void OnTriggerEnter2D(Collider2D trigger)
    {
        //target player
        if (trigger.gameObject.CompareTag("Player") && playerChaser)
        {
            target = trigger.gameObject;
            isChasing = true;
            StopCoroutine("ChangeMovement");
        }
    }

    public void OnTriggeStay2D(Collider2D trigger)
    {
        //chasing player
        if (trigger.gameObject.CompareTag("Player") && playerChaser)
        {
            StopCoroutine("ChangeMovement");
        }
    }

    public void OnTriggerExit2D(Collider2D trigger)
    {
        //stop chasing
        if (trigger.gameObject.CompareTag("Player") && playerChaser)
        {
            isChasing = false;
            StartCoroutine("ChangeMovement");
        }
    }
}
