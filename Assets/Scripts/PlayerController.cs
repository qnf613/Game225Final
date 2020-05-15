using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //TODO: animation
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private int jumpcount = 0;
    public static int HP; //all static variables are called at UIUpdate
    public static string CurrentAb = "Shooter";
    private bool isContacted = false;
    //ability control
    //default ability setup
    public static int abSwitch = 1;
    private int maxAbility = 1;
    [SerializeField] private GameObject Shooter;
    //ability that need to be accquired
    [SerializeField] private bool havingAb2 = false;
    [SerializeField] private GameObject Mover;
    [SerializeField] private bool havingAb3 = false;
    [SerializeField] private GameObject Barrier;
    [SerializeField] private bool havingAb4 = false;
    [SerializeField] private GameObject Freezer;

    //component
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Mover.SetActive(false);
        Barrier.SetActive(false);
        Freezer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //animation direction   
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        //animations
        if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("isWalking", false);
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetBool("isWalking", true);
        }

        //jump & double jump and animation for it
        if (Input.GetButtonDown("Jump") && jumpcount < 2)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            if (jumpcount > 0 && jumpcount < 2) 
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            jumpcount++;
        }

        //movement speed
        float horizontalInput = Input.GetAxis("Horizontal");
        float xVelocity = horizontalInput * speed;
        rigid.velocity = new Vector2(xVelocity, rigid.velocity.y);

        //stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //these are logic of abilities' cool-down but written here for UI displaying.
        Ability1.curtime1 -= Time.deltaTime;
        Ability2.curtime2 -= Time.deltaTime;
        Ability3.curtime3 -= Time.deltaTime;
        //changing abilities
        //if player doesn't hav abilities but shooter, switch doesn't work

        if (Input.GetKeyDown(KeyCode.E) && maxAbility > 1 && !Input.GetMouseButton(0))
        {
            abSwitch++;
        }
        
        if (abSwitch == 1)
        {
           Shooter.SetActive(true);
           CurrentAb = "Shooter";
        }

        if (abSwitch == 2)
        {
            Shooter.SetActive(false);
            Mover.SetActive(true);
            CurrentAb = "Mover";
            
        }

        if (abSwitch == 3)
        {
            Mover.SetActive(false);
            Barrier.SetActive(true);
            CurrentAb = "Barrier";
            //check if player doesnt hav barrier yet, if so turn on shooter, not barrier
            if (maxAbility < 3)
            {
                abSwitch = 1;
                Barrier.SetActive(false);
            }
        }

        if (abSwitch == 4)
        {
            Barrier.SetActive(false);
            Freezer.SetActive(true);
            CurrentAb = "Freezer";
            //check if player doesnt hav freezer yet, if so turn on shooter, not freezer
            if (maxAbility < 4)
            {
                Freezer.SetActive(false);
                abSwitch = 1;
            }
        }

        if (abSwitch > 4)
        {
            Freezer.SetActive(false);
            abSwitch = 1;
        }

        //check player accquire the ability
        if (havingAb2)
        {
            maxAbility = 2;
        }
        if (havingAb3)
        {
            maxAbility = 3;
        }
        if (havingAb4)
        {
            maxAbility = 4;
        }

        //death check
        if (HP <= 0)
        {
            Destroy(gameObject);
        }

        
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get new abilities
        if (collision.CompareTag("GetMover"))
        {
            Destroy(collision.gameObject);
            havingAb2 = true;
        }
        if (collision.CompareTag("GetBarrier"))
        {
            Destroy(collision.gameObject);
            havingAb3 = true;
        }
        if (collision.CompareTag("GetFreezer"))
        {
            Destroy(collision.gameObject);
            havingAb4 = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //being damaged
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle")
            || collision.gameObject.CompareTag("NP.Projectile"))
        {
            Damaged();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //re-set jump count
        if (collision.gameObject.tag == "Ground")
        {
            jumpcount = 0;
            animator.SetBool("isJumping", false);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && jumpcount == 0)
        {
            jumpcount = 1;
        }
    }

    void Damaged()
    {
        //TODO: Sound
        isContacted = true;
        HP -= 1;
        spriteRenderer.color = new Color(1, 1, 1, .4f);
        gameObject.layer = 14;
        Invoke("OutContact", 2f);
    }

    void OutContact()
    {
        isContacted = true;
        gameObject.layer = 13;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

}
