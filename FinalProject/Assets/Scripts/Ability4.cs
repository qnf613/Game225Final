using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability4 : MonoBehaviour
{
    private float cooltime;
    private float curtime;
    private float maxXrange;
    private float maxyrange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get target (mouse cursor) position
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
