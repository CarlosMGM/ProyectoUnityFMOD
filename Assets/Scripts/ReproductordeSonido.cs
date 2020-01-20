using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductordeSonido : MonoBehaviour
{
    public FMODLoader.SOUNDS sonido;
    public bool pulsarBoton;
    FMODSoundEmitter soundEmitter;
    Trigger triger;
    bool pulsado = false;
    // Start is called before the first frame update
    void Start()
    {
        float x=Random.value;
        soundEmitter = gameObject.GetComponent<FMODSoundEmitter>();
        if(pulsarBoton)
        triger = gameObject.GetComponent<Trigger>();
        if (!pulsarBoton)
            Invoke("play",x+0.1f*2);
    }

    // Update is called once per frame
    void Update()
    {
        if (pulsarBoton)
        {
            if (triger.pressed && !pulsado)
            {
                play();
                pulsado = true;
            }
            else if (!triger.pressed)
            {
                pulsado = false;
            }
        }

    }
    void play()
    {
        soundEmitter.playSound(sonido, true);
    }
}
