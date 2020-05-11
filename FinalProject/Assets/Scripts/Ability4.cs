using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability4 : MonoBehaviour
{
    [SerializeField]private float cooltime;
    private float curtime;
    private bool usable = false;
    //projectile
    public GameObject freezbomb;
    //start point position
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookMouse();
        //available condition & cool down
        if (usable)
        {
            //TODO: SE
            if (Input.GetMouseButtonDown(0))
            {
                Throw();
                curtime = cooltime;
                usable = false;
            }
        }
        if (curtime <= 0f)
        {
            usable = true;
        }
        curtime -= Time.deltaTime;
    }

    void LookMouse()
    {
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dirPos = new Vector2(targetPos.x - pos.position.x, targetPos.y - pos.position.y);

        pos.right = dirPos;
    }

    void Throw()
    {
        GameObject go = Instantiate(freezbomb, pos.position, transform.rotation);
        go.GetComponent<Rigidbody2D>().velocity = go.transform.right * 10f;
    }
}
