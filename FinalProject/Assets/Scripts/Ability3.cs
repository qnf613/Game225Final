using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3 : MonoBehaviour
{
    [SerializeField]private float cooltime;
    [SerializeField] private float curtime;
    [SerializeField] private float duration = 0.0f;
    private float maxDuration = 3.0f;
    [SerializeField] private bool isUsing = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<PolygonCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //active condition
        if (Input.GetMouseButton(0) && curtime < 0f)
        {
            //duration check
            isUsing = true;
            if (isUsing)
            {
                duration += Time.deltaTime;

            }
            //turn off conditions
            if (duration >= maxDuration)
            {
                duration = 0.0f;
                isUsing = false;
                this.GetComponent<PolygonCollider2D>().enabled = false;
                curtime = cooltime;
            }
            
        }
        //another turn off conditions
        else if (isUsing && Input.GetMouseButtonUp(0))
        {
            isUsing = false;
            this.GetComponent<PolygonCollider2D>().enabled = false;
            //cooldown reduce
            if (!isUsing && duration < maxDuration)
            {
                curtime = cooltime;
                curtime -= (maxDuration - duration);
            }
            duration = 0.0f;
        }

        curtime -= Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsing && collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
        if ((isUsing && collision.CompareTag("Enemy")) || (isUsing && collision.CompareTag("MovableOb")))
        {
            this.GetComponent<PolygonCollider2D>().enabled = true;
            
        }
        
    }
}
