﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.rigid.transform.position = rigid.transform.position;
        }

        if (collision.gameObject.CompareTag("Player") && (gameObject.CompareTag("GetBarrier") || gameObject.CompareTag("GetMover")))
        {
            SoundManager.instance.newAbility();
        }


    }
    



}
