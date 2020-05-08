using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    GameObject target;
    Vector2 targetPos;
    GameObject player;
    public float cooltime = 3.0f;
    private float curtime = 0f;
    private float usingTime = 0f;
    public bool isUsing = false;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        player = GameObject.Find("Player");
        player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && isUsing == false)
        {
            ObjDetect();
        }

        else if (Input.GetMouseButton(0) && curtime < 0f)
        {
            if (target.CompareTag("MovableOb") && usingTime < 5.0f)
            {
                isUsing = true;
                target.transform.position = targetPos;
                usingTime += Time.deltaTime;
            }
            else if (usingTime >= 5.0f)
            {
                Release();
            }
        }
        else if ((Input.GetMouseButtonUp(0) && isUsing == true))
        {
            Release();
        }

        curtime -= Time.deltaTime;

    }

    void ObjDetect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;

        }
        else
        {
            target = null;
        }
    }

    public void Release()
    {
        usingTime = 0.0f;
        isUsing = false;
        curtime = cooltime;
    }

}
