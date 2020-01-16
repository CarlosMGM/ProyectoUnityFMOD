using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    bool trigger = false;
    public Text texto;
    public bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.E))
                pressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        texto.text = "Pulsa la E para interactuar";
        trigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        texto.text = "";
        trigger = false;
        pressed = false;
    }
}
