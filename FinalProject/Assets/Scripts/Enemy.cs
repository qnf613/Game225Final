using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //TODO:
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anima;
    [SerializeField] GameObject target;
    [SerializeField] private int HP;

    public int nextMove;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anima = GetComponent<Animator>();
        //call Direction() since this object has been appeared
        Invoke("Direction", 0);
    }

    // Update is called once per frame
    public void Update()
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
        //Death & destory
        if(HP <= 0)
        {
            Destroy(gameObject);
        }

        Debug.DrawRay(rigid.position, Vector3.up, Color.red);

    }

    //deciding direction
    void Direction()
    {
        //decide left, stop, right
        nextMove = Random.Range(-1, 2);
        //flip the sprites when it facing right side
        //if (nextMove != 0)
        //{
        //    spriteRenderer.flipX = nextMove == 1;
        //}
        //makes the enemy's direction deciding more randomly
        float nextDirectionTime = Random.Range(2f, 4f);
        //repeat this method itself
        Invoke("Direction", nextDirectionTime);
    }
    
    //trigger chasing player, damaged by movable objects
    public void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D rayHitup = Physics2D.Raycast(rigid.position, Vector3.up, .3f);
        if (rayHitup.collider != null)
        {
            if (collision.gameObject.tag == "MovableOb")
            {
                HP = HP - 5;
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //damaged by bullet
        if (collision.CompareTag("Projectile"))
        {
            HP = HP - 3;
        }

        //detect falling obj
        //if (collision.CompareTag("MovableOb"))
        //{
        //    //TODO: add knockback
        //    HP = HP - 5;
        //}


    }
}
