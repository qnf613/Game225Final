using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (collision.gameObject && !collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("ShootableOb"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
