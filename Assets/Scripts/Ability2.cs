using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    //components
    GameObject movingObject;
    GameObject player;
    Rigidbody2D playerRigid;
    Rigidbody2D objRigid;
    //object moving related 
    private Vector2 targetPos;
    [SerializeField] private float movingSpeed = 15.0f;
    //using condition related
    [SerializeField]private float cooltime;
        //this will count in playercontroller script due to UI display
    public static float curtime2;
    private float duration = 0f;
    [SerializeField]private float maxDuration;
    private bool isUsing = false;
    //for fixed update
    private bool btPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        movingObject = null;
        player = GameObject.Find("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //activate conditions
        //TODO: SE
        if (Input.GetMouseButtonDown(0) && !isUsing)
        {
            ObjDetect();
        }

        //check duration and
        else if (Input.GetMouseButton(0) && curtime2 < 0f && movingObject != null)
        {
            //trigger physics engine movement
            btPressed = true;
            if (movingObject.CompareTag("MovableOb") && duration <= maxDuration)
            {
                isUsing = true;
                duration += Time.deltaTime;
            }
            //turn off condition
            else if (duration >= maxDuration)
            {
                Release();
                btPressed = false;
            }
        }

        else if ((Input.GetMouseButtonUp(0) && isUsing))
        {
            Release();
            btPressed = false;
        }

    }

    public void FixedUpdate()
    {
        //moveing objects
        if (btPressed)
        {
            Move(targetPos);
        }
        //hold player position
        if (isUsing)
        {
            playerRigid.velocity = new Vector2(0, 0);
        }
    }


    public void ObjDetect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            movingObject = hit.collider.gameObject;
            objRigid = movingObject.GetComponent<Rigidbody2D>();

        }
        else
        {
            movingObject = null;
        }
    }

    public void Move(Vector2 direction)
    {
        objRigid.MovePosition((Vector2)movingObject.transform.position + (direction * movingSpeed * Time.deltaTime));
    }


    public void Release()
    {
        duration = 0.0f;
        isUsing = false;
        curtime2 = cooltime;
    }

}
