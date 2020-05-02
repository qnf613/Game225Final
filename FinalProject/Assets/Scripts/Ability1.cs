using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;
    [SerializeField] private bool AB1usable = false;
    void Start()
    {

    }

    void Update()
    {
        //get target (mouse cursor) position
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        //available condition + cool down
        if (AB1usable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, pos.position, transform.rotation);
                curtime = cooltime;
                AB1usable = false;
            }
        }
        if (curtime <= 0f)
        {
            AB1usable = true;
        }
        curtime -= Time.deltaTime;
    }
}
