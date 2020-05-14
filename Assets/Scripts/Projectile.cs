using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float repeat;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", repeat);
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
        //pass the trigger of player and enemy
        if (collision.gameObject)
        {
            if (!(collision.CompareTag("Player") || collision.CompareTag("Enemy")))
            {
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("ShootableOb"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if it hits enemy's collider (not trigger) projectile will destroy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
