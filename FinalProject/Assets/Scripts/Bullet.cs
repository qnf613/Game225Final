﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShootableOJ"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
