using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationGame : MonoBehaviour
{
    public CombinationNumber num1;
    public CombinationNumber num2;
    public CombinationNumber num3;
    public CombinationNumber num4;

    FMODSoundEmitter soundEmitter;
    public FMODSoundEmitter gotera;
    public int[] trueCombination; 
    public GameObject canvas;
    public GameObject endLevel;

    Trigger triger;
    bool canvasActive = false;
    public bool result = false;
    bool play = true;
    // Start is called before the first frame update
    void Start()
    {
        triger = GetComponent<Trigger>();
        soundEmitter = gameObject.GetComponent<FMODSoundEmitter>();
      
    }
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(play)
        {
            gotera.playSound(FMODLoader.SOUNDS.COMBINATION_WATER_DROP, true);
            play = false;
        }
        if(!canvas.activeInHierarchy)
        {
            canvasActive = false;
        }
       if(triger.pressed && !canvasActive)
        {
            canvas.SetActive(true);
            canvasActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        canvasActive = false;
    }
    public void checkResult()
    {
        if (num1.numerocombiancion == trueCombination[0])
        {
            if (num2.numerocombiancion == trueCombination[1])
                if (num3.numerocombiancion == trueCombination[2])
                    if (num4.numerocombiancion == trueCombination[3])
                    { result = true; soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.RIGHT, true, 1f);endLevel.SetActive(false); }
                    else
                        wrong();
                else
                    wrong();
            else
                wrong();
        }
        else
            wrong();

    }
    void wrong()
    {
        soundEmitter.playSoundwithPitch(FMODLoader.SOUNDS.WRONG, true, 1f);
    }
}
