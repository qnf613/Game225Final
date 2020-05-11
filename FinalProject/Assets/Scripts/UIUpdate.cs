using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    Text UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UI.text = "HP: " + PlayerController.HP.ToString() + "\nCurrent Ability: " + PlayerController.CurrentAb;
    }
}
