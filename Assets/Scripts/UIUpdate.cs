using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    Text UI;
    [SerializeField] private float cooldown;
    [SerializeField] private float displayingCD;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.abSwitch == 1)
        {
            cooldown = Ability1.curtime1;
            displayingCD = cooldown;
        }

        else if (PlayerController.abSwitch == 2)
        {
            cooldown = Ability2.curtime2;
            displayingCD = cooldown;
        }

        else if (PlayerController.abSwitch == 3)
        {
            cooldown = Ability3.curtime3;
            displayingCD = cooldown;
        }

        if (displayingCD <= 0)
        {
            displayingCD = 0;
        }

        UI.text = "HP: " + PlayerController.HP.ToString() + "\nCurrent Ability: " + PlayerController.CurrentAb + " Cooldown: " + displayingCD.ToString("F2");
    }
}
