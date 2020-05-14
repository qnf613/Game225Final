using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    // Start is called before the first frame update
    private void Start()
    {
        //destroy projectile after certain amount of time
        Invoke("Destroy", duration);
    }

    // Update is called once per frame
    private void Update()
    {
        //move logic
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    //destroy
    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ignore the triggers of player and enemy
        if (collision.gameObject)
        {
            if (!(collision.CompareTag("Player") || collision.CompareTag("Enemy")))
            {
                Destroy(gameObject);
            }
        }
        //trigger the interaction with shootable objects
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
