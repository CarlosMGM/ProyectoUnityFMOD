using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonDice : MonoBehaviour
{

    public Trigger boton1;
    public Trigger boton2;
    public Trigger boton3;

    FMODSoundEmitter soundEmitter;

    public int[] orden1 = { 1, 1, 2, 3, 1 };
    public int[] orden2 = { 1, 1, 2, 3, 1 };
    public int[] orden3 = { 1, 1, 2, 3, 1 };

    bool done1 = false, done2 = false, done3 = false;

   public int contador = 0;
    public int botonayuda = 0;
    bool introducido = false;
    bool ok = false;
    // Start is called before the first frame update
    void Start()
    {
       // soundEmitter = gameObject.GetComponent<FMODSoundEmitter>();
    }
    void Awake()
    { 
        soundEmitter = gameObject.GetComponent<FMODSoundEmitter>();
  
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        Reproducir();

        introducido = false;
       
        if (boton1.pressed && !introducido  )
        {
            botonayuda = 1;
            introducido = true;
            if (!ok)
            { soundEmitter.stopSound(FMODLoader.SOUNDS.A_TONE); soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.A_TONE, true, 0.5f); }
        }
        else if (boton2.pressed && !introducido )
        {
            botonayuda = 2;
            introducido = true;
            if (!ok)
            { soundEmitter.stopSound(FMODLoader.SOUNDS.A_TONE); soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.A_TONE, true, 1.0f); }
        }
        else if (boton3.pressed && !introducido)
        {
            botonayuda = 3;
            introducido = true;
            if (!ok)
            { soundEmitter.stopSound(FMODLoader.SOUNDS.A_TONE); soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.A_TONE, true, 1.5f); }
        }
        else { botonayuda = 0; ok = false;   }


        if (!done1 && introducido && !ok)
        {
            ok = true;
            if (botonayuda == orden1[contador])
                contador++;
            else if (botonayuda != 0)
            { contador = 0; Invoke("Wrong", 1); }
            if (contador == orden1.Length)
            {
                contador = 0;
                done1 = true;
                Invoke("Correct", 1);
            }
        }
        else if (!done2 && introducido && !ok)
        {
            ok = true;
            if (botonayuda == orden2[contador])
                contador++;
            else if (botonayuda != 0)
            { contador = 0; Invoke("Wrong", 1); }
            if (contador == orden2.Length)
            {
                contador = 0;
                done2 = true;
                Invoke("Correct", 1);
            }
        }
        else if (!done3 && introducido && !ok)
        {
            ok = true;
            if (botonayuda == orden3[contador])
                contador++;
            else if (botonayuda != 0)
            { contador = 0; Invoke("Wrong", 1); }
            if (contador == orden3.Length)
            {
                contador = 0;
                done3 = true;
                Invoke("Correct", 1);
            }
        }
        else if(introducido && !ok) ok = true;
    }

    void Reproducir()
    {
        if(!done1)
        {
            for (int i = 0; i < orden1.Length; i++)
            {
                Invoke("tono"+orden1[i], 0.5f*(i+1));
                
            }
        }
        else if(!done2)
        {
            for (int i = 0; i < orden2.Length; i++)
            {
                Invoke("tono" + orden2[i], 0.5f * (i + 1));

            }
        }
        else if(!done3)
        {
            for (int i = 0; i < orden3.Length; i++)
            {
                Invoke("tono" + orden3[i], 0.5f * (i + 1));

            }
        }
    }

    void tono1()
    {
        soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.A_TONE, true, 0.5f);
    }

    void tono2()
    {
        soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.A_TONE, true, 1f);
    }
    void tono3()
    {
        soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.A_TONE, true, 1.5f);
    }

    void Correct()
    {

        soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.RIGHT, true, 1f);
    }
    void Wrong()
    {

        soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.WRONG, true, 1f);
    }
}
