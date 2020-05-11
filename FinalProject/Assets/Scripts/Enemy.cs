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


    }

    public void FixedUpdate()
    {

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
    

    public void OnTriggerEnter2D(Collider2D collider)
    {
        //damaged by bullet
        if (collider.CompareTag("Projectile"))
        {
            HP = HP - 3;
        }
    }
}
