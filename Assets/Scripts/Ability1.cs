using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{

    [SerializeField] private float cooltime;
    public static float curtime1; //this will count in playercontroller script due to UI display  
    private bool usable = false;
    //projectile
    public GameObject bullet;
    //start point position
    public Transform pos;
    //laser point related
    [SerializeField] private float length;
    private LineRenderer render;

    private void Start()
    {
        render = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        LookMouse();
        LaserPoint();
        //available condition & cool down
        if (usable)
        {
            //TODO: SE
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, pos.position, transform.rotation);
                curtime1 = cooltime;
                usable = false;
            }
        }

        if (curtime1 <= 0f)
        {
            usable = true;
        }


    }

    private void LookMouse()
    {
        //get target (mouse cursor) position
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }

    private void LaserPoint()
    {
        Vector3 endPos = transform.position + (transform.right * length);
        render.SetPositions(new Vector3[] { transform.position, endPos });
    }
}
