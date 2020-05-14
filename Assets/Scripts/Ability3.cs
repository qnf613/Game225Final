using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3 : MonoBehaviour
{
    //component
    SpriteRenderer spriterenderer;
    GameObject player;
    [SerializeField] private float cooltime;
    public static float curtime3; //this will count in playercontroller script due to UI display 
    public static float duration = 0;
    private float maxDuration = 3.0f;
    private bool isUsing = false;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Player");
        spriterenderer = GetComponent<SpriteRenderer>();
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //active condition
        //TODO: SE
        if (Input.GetMouseButton(0) && curtime3 < 0f)
        {
            //duration check
            isUsing = true;
            spriterenderer.enabled = true;
            if (isUsing)
            {
                duration += Time.deltaTime;
            }
            //turn off conditions
            if (duration >= maxDuration)
            {
                duration = 0.0f;
                isUsing = false;
                player.layer = 13;
                this.GetComponent<SpriteRenderer>().enabled = false;
                curtime3 = cooltime;
            }
            
        }
        //another turn off conditions
        else if (isUsing && Input.GetMouseButtonUp(0))
        {
            isUsing = false;
            player.layer = 13;
            this.GetComponent<SpriteRenderer>().enabled = false;
            //cooldown reduce
            if (!isUsing && duration < maxDuration)
            {
                curtime3 = cooltime;
                curtime3 -= (maxDuration - duration);
            }
            duration = 0.0f;
        }

        curtime3 -= Time.deltaTime;

    }
    //blocks projectiles that are not player's
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsing && collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
        
    }
    //ignore contact with enemies & obstacle
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isUsing && (collision.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle")))
        {
            player.layer = 14;
        }

    }
}
