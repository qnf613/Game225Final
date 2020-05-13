using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    Text UI;
    [SerializeField] private GameObject Shooter;
    [SerializeField] private GameObject Mover;
    [SerializeField] private GameObject Barrier;
    [SerializeField] private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Shooter.activeSelf)
        {
            cooldown = Ability1.curtime1;
        }
        if (Mover.activeSelf)
        {
            cooldown = Ability2.curtime2;
        }
        if (Barrier.activeSelf)
        {
            cooldown = Ability3.curtime3;
        }
        if (cooldown <= 0)
        {
            cooldown = 0;
        }
        UI.text = "HP: " + PlayerController.HP.ToString() + "\nCurrent Ability: " + PlayerController.CurrentAb + " Cooldown: " + cooldown.ToString("F2");
    }
}
