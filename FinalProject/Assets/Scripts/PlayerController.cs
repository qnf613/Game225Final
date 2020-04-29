using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private int jumpcount = 0;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement speed
        float horizontalInput = Input.GetAxis("Horizontal");
        float xVelocity = horizontalInput * speed;
        rigid.velocity = new Vector2(xVelocity, rigid.velocity.y);
        //stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //jump & double jump
        if (Input.GetButtonDown("Jump") && jumpcount < 2)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            
            if (jumpcount > 0 && jumpcount < 2) 
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            jumpcount++;

        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 0.1f);
        if (rayHit.collider != null)
        {
            if (collision.gameObject.tag =="Ground")
            {
                jumpcount = 0;
            }
        }
    }

}
