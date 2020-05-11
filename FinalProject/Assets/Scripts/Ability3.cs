﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3 : MonoBehaviour
{
    [SerializeField] private float cooltime;
    private float curtime;
    private float duration;
    private float maxDuration = 3.0f;
    private bool isUsing = false;
    SpriteRenderer spriterenderer;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spriterenderer = GetComponent<SpriteRenderer>();
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //active condition
        //TODO: SE
        if (Input.GetMouseButton(0) && curtime < 0f)
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
                curtime = cooltime;
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
                curtime = cooltime;
                curtime -= (maxDuration - duration);
            }
            duration = 0.0f;
        }

        curtime -= Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsing && collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isUsing && collision.CompareTag("Enemy"))
        {
            player.layer = 14;
        }

    }
}
