using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationNumber : MonoBehaviour
{
    Text numero;
    public int numerocombiancion;
    // Start is called before the first frame update
    void Start()
    {
        numerocombiancion = 0;
        numero = GetComponentInChildren<Text>();
        numero.text = numerocombiancion.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void up()
    {
        numerocombiancion = numerocombiancion + 1;
        if (numerocombiancion >= 10)
            numerocombiancion = 0;

        numero.text = numerocombiancion.ToString();
    }
    public void down()
    {
        numerocombiancion = numerocombiancion - 1;
        if (numerocombiancion < 0)
            numerocombiancion = 9;

        numero.text = numerocombiancion.ToString();
    }
}
