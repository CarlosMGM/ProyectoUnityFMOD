using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FMOD;

public class FMODLoader : MonoBehaviour
{
    FMOD.System system;
    RESULT result;
    Sound[] sounds;

    static public void ERRCHECK(FMOD.RESULT result)
    {
        if (result != FMOD.RESULT.OK)
        {
            print(FMOD.Error.String(result));
            Application.Quit(-1);
        }
    }

    private void Awake()
    {
        result = FMOD.Factory.System_Create(out system);
        ERRCHECK(result);
        // 128 canales (numero maximo que podremos utilizar simultaneamente)

        result = system.init(128, FMOD.INITFLAGS.NORMAL, new System.IntPtr(0)); // Inicializacion de FMOD
        ERRCHECK(result);

        result = system.setGeometrySettings(100.0f);

        createSounds();


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EditorApplication.isPaused)
        {

            ChannelGroup master;
            system.getMasterChannelGroup(out master);
            master.setPaused(true);
        }
        system.update();
    }

    public FMOD.System getSystem()
    {
        return system;
    }

    private void createSounds()
    {
        string path = "Assets/Sounds/";
        sounds = new Sound[10];
        result = system.createSound(path + "A-Tone.wav", MODE.DEFAULT | MODE.LOOP_OFF | MODE._3D, out sounds[0]);
        ERRCHECK(result);
        result = system.createSound(path + "Water Drop.wav", MODE.LOOP_NORMAL| MODE._3D, out sounds[1]);
        ERRCHECK(result);
        result = system.createSound(path + "Smack.wav", MODE.DEFAULT | MODE._3D, out sounds[2]);
        ERRCHECK(result);
        result = system.createSound(path + "steps.wav", MODE.LOOP_NORMAL | MODE._3D, out sounds[3]);
        ERRCHECK(result);
        result = system.createSound(path + "WrongAnswer.wav", MODE.DEFAULT | MODE.LOOP_OFF | MODE._3D, out sounds[4]);
        ERRCHECK(result);
        result = system.createSound(path + "RightAnswer.wav", MODE.DEFAULT | MODE.LOOP_OFF | MODE._3D, out sounds[5]);
        ERRCHECK(result);
        result = system.createSound(path + "bensound-buddy-start.wav", MODE.DEFAULT | MODE.LOOP_OFF | MODE._3D, out sounds[6]);
        ERRCHECK(result);
        result = system.createSound(path + "bensound-buddy-bucle.wav", MODE.LOOP_NORMAL | MODE._3D, out sounds[7]);
        ERRCHECK(result);
        result = system.createSound(path + "Water Drop(secuencia).wav", MODE.LOOP_NORMAL | MODE._3D, out sounds[8]);
        ERRCHECK(result);
    }

    public enum SOUNDS
    {
        A_TONE,
        WATER_DROP,
        SMACK,
        STEPS,
        WRONG,
        RIGHT,
        BUDDY_START,
        BUDDY_LOOP,
        COMBINATION_WATER_DROP
    }

    public Sound getSound(SOUNDS sound)
    {
        return sounds[(int) sound];
    }


    private void OnApplicationQuit()
    {
        result = system.release();
        ERRCHECK(result);
    }

    static void EditorPlaying()
    {
        if (EditorApplication.isPaused)
        {
            print("paused");
        }
    }
    
    

    private void OnApplicationPause(bool pause)
    {
        ChannelGroup master;
        system.getMasterChannelGroup(out master);
        int numGroups;
        master.getNumGroups(out numGroups);
        int i = 0;
        while(i < numGroups)
        {
            ChannelGroup group;
            master.getGroup(i, out group);
            group.setPaused(true);
        }
    }
}
