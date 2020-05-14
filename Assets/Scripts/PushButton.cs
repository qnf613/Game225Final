using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    [SerializeField] private GameObject thingsToShow;
    // Start is called before the first frame update
    void Start()
    {
        thingsToShow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovableOb"))
        {
            thingsToShow.SetActive(true);
            Destroy(gameObject);
        }
    }
}
