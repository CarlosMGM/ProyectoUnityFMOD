using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{

    public FMODLoader.SOUNDS start;
    public FMODLoader.SOUNDS loop;
    public FMODSoundEmitter emitter;
    public KeyCode rhythmInput;
    public Trigger inicioprueba;
    public Text aciertos;
    public Text maxAciertos;
    public GameObject canvas;

    bool first = true;
    bool isLooping = false;
    bool inputOpen = false;
    bool hasPressed = false;
    bool inicio = false;
    bool sound = false;

    float timerStart = 0;
    int timerCount = 0;
    int loopCount = 0;

    float[] inputReadTimes;
    float[] inputReadRanges;
    public bool completed = false;
    int rhythmCount = 0;
    int maxCount = 0;
    public GameObject puerta;


    // Start is called before the first frame update
    void Start()
    {
        FMODLoader loader = FindObjectOfType<FMODLoader>();

        inputReadTimes = new float[11];
        inputReadRanges = new float[10];

        inputReadTimes[0] = 0f;
        inputReadRanges[0] = 0.30f;
        inputReadTimes[1] = 0.53f;
        inputReadRanges[1] = 0.30f;
        inputReadTimes[2] = 0.886f;
        inputReadRanges[2] = 0.30f;
        inputReadTimes[3] = 1.45f;
        inputReadRanges[3] = 0.15f;
        inputReadTimes[4] = 1.61f;
        inputReadRanges[4] = 0.30f;
        inputReadTimes[5] = 2.13f;
        inputReadRanges[5] = 0.30f;
        inputReadTimes[6] = 2.66f;
        inputReadRanges[6] = 0.30f;
        inputReadTimes[7] = 3.02f;
        inputReadRanges[7] = 0.30f;
        inputReadTimes[8] = 3.58f;
        inputReadRanges[8] = 0.15f;
        inputReadTimes[9] = 3.734f;
        inputReadRanges[9] = 0.30f;
        inputReadTimes[10] = 4.272f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isLooping && Input.GetKeyDown(rhythmInput))
        {
            if (inputOpen)
            {
                rhythmCount++;
                hasPressed = true;
                print(rhythmCount);
            }
            else if (timerCount != 5)
            {
                print("Está fuera");
                rhythmCount = 0;
                print(rhythmCount);
                hasPressed = false;
            }
                

        }

        if(inicioprueba.pressed)
        {
            canvas.SetActive(true);
        }
        if (first && inicio)
        {
            emitter.playSound(start, false);
            first = false;
        }
        else if(!isLooping && !emitter.isPlaying(start)&&!first)
        {
            emitter.playSound(loop, false);
            isLooping = true;
            timerStart = Time.time;
        }


        if(isLooping && !inputOpen && !first)
        {
            if((Time.time - timerStart) >= inputReadTimes[timerCount])
            {
                //print("Open" + timerCount.ToString());
                if (timerCount == inputReadRanges.Length)
                {
                    timerStart += inputReadTimes[timerCount];
                    timerCount = 0;
                    loopCount++;
                }

                
                //print((inputReadRanges.Length * loopCount + timerCount));

                inputOpen = true;
            }
        }

        if(isLooping && inputOpen && !first)
        {
            if ((Time.time - timerStart) >= (inputReadTimes[timerCount] + inputReadRanges[timerCount]))
            {
                //print("Closed" + timerCount.ToString());
                inputOpen = false;
                timerCount++;
                if (!hasPressed)
                {
                    rhythmCount = 0;
                   // print(rhythmCount);
                }
                hasPressed = false;
                return;
                   
            }

            
        }
        aciertos.text = rhythmCount.ToString();
        if (rhythmCount > maxCount)
            maxCount = rhythmCount;
        maxAciertos.text = maxCount.ToString();
        if(rhythmCount>=20)
        {
            completed = true;
            puerta.SetActive(false);
        }
    
    }
    public void Iniciar()
    {
        inicio = true;
    }
    public void Terminar()
    {
        inicio = false;
        first = true;
        emitter.stopSound(loop);
        isLooping = false;
    }
    public void Salir()
    {
        if (inicio && !first)
        {
            inicio = false;
            first = true;
            emitter.stopSound(loop);
            isLooping = false;
        }
        canvas.SetActive(false);
        if(completed && !sound)
        {
            emitter.playSound(FMODLoader.SOUNDS.RIGHT, true);
            sound = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        inicio = false;
        first = true;
        emitter.stopSound(loop);
        isLooping = false;
        if (completed && !sound)
        {
            emitter.playSound(FMODLoader.SOUNDS.RIGHT, true);
            sound = true;
        }
    }
}


/*
 Start:        Duración:
 0.05s          0.25s.
 0.45s          0.25s.
 0.72s          0.25s.
 1.12s          0.125s
 1.245s         0.25s
 1.5s           0.15s       // EXTRA
 1.65s          0.25s

 * */