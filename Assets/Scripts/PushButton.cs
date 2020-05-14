using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    [SerializeField] private GameObject thingsToShow;
    [SerializeField] private string thingToReact;
    // Start is called before the first frame update
    private void Start()
    {
        //disables the game object that will appear when button pushed
        thingsToShow.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enable the game object that will appear when button pushed
        if (collision.gameObject.CompareTag(thingToReact))
        {
            thingsToShow.SetActive(true);
            Destroy(gameObject);
        }
    }
}
