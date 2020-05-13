using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezBomb : MonoBehaviour
{
    [SerializeField] private float repeat;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("Destroy", repeat);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }
    void Destroy()
    {
        Destroy(gameObject);
    }

}
