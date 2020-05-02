using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    [SerializeField] public bool AB2usable = false;
    GameObject target;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            OjDetect();
            if (target.CompareTag("MovableOb"))
            {
                Debug.Log("Movable");
                target.transform.position = targetPos;
            }

        }

    }

    void OjDetect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
            Debug.Log("Hit");
        }
    }


}
