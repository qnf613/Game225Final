using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    GameObject movingObject;
    GameObject player;
    Rigidbody2D playerRigid;
    Rigidbody2D objRigid;
    Vector2 targetPos;
    [SerializeField]private float cooltime;
    private float curtime = 0f;
    private float duration = 0f;
    [SerializeField] private float maxDuration = 5.0f;
    [SerializeField] private bool isUsing = false;
    //[SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movingObject = null;
        player = GameObject.Find("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        //objRigid = movingObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (movingObject != null)
        {
            objRigid = movingObject.GetComponent<Rigidbody2D>();
        }
        //activate conditions
        if (Input.GetMouseButtonDown(0) && !isUsing)
        {
            ObjDetect();
        }

        else if (Input.GetMouseButton(0) && curtime < 0f)
        {
            if (movingObject.CompareTag("MovableOb") && duration <= maxDuration)
            {
                isUsing = true;
                if (isUsing)
                {
                    playerRigid.velocity = new Vector2(0, 0);
                }

                movingObject.transform.position = targetPos;
                
                duration += Time.deltaTime;
            }
            else if (duration >= maxDuration)
            {
                Release();
            }
        }

        else if ((Input.GetMouseButtonUp(0) && isUsing))
        {
            Release();
        }

        curtime -= Time.deltaTime;

    }

    public void ObjDetect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            movingObject = hit.collider.gameObject;

        }
        else
        {
            movingObject = null;
        }
    }


    public void Release()
    {
        duration = 0.0f;
        isUsing = false;
        curtime = cooltime;
    }

}
