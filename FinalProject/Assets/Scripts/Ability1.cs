using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    [SerializeField] private float cooltime;
    private float curtime;
    [SerializeField] private bool usable = false;
    //laser point related
    private float length;
    private LineRenderer render;
    void Start()
    {
        render = GetComponent<LineRenderer>();

    }

    void Update()
    {
        //get target (mouse cursor) position
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        //available condition + cool down
        if (usable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, pos.position, transform.rotation);
                curtime = cooltime;
                usable = false;
            }
        }
        if (curtime <= 0f)
        {
            usable = true;
        }
        curtime -= Time.deltaTime;

        //laser pointer
        Vector3 endPos = transform.position + (transform.right * length);
        render.SetPositions(new Vector3[] { transform.position, endPos });
    }
}
