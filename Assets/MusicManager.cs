using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public FMODLoader.SOUNDS start;
    public FMODLoader.SOUNDS loop;
    public FMODSoundEmitter emitter;
    public KeyCode rhythmInput;

    bool first = true;
    bool isLooping = false;
    bool inputOpen = false;
    bool hasPressed = false;

    float timerStart = 0;
    int timerCount = 0;
    int loopCount = 0;

    float[] inputReadTimes;
    float[] inputReadRanges;

    int rhythmCount = 0;


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


        if (first)
        {
            emitter.playSound(start, false);
            first = false;
        }
        else if(!isLooping && !emitter.isPlaying(start))
        {
            emitter.playSound(loop, false);
            isLooping = true;
            timerStart = Time.time;
        }


        if(isLooping && !inputOpen)
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

        if(isLooping && inputOpen)
        {
            if ((Time.time - timerStart) >= (inputReadTimes[timerCount] + inputReadRanges[timerCount]))
            {
                //print("Closed" + timerCount.ToString());
                inputOpen = false;
                timerCount++;
                if (!hasPressed)
                {
                    rhythmCount = 0;
                    print(rhythmCount);
                }
                hasPressed = false;
                return;
                   
            }

            
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