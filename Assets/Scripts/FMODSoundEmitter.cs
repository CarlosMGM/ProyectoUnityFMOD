using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using System.Runtime.InteropServices;



public class FMODSoundEmitter : MonoBehaviour
{
    private ChannelGroup channelGroup;
    Dictionary<FMODLoader.SOUNDS, Channel> channels = new Dictionary<FMODLoader.SOUNDS, Channel>();
    public KeyCode laughButton;
    public bool reverbDependent = false;
    RESULT result;
    FMODLoader loader;


    [System.Serializable]
    public struct SoundToAssign
    {
        public bool A_TONE;
        public bool WATER_DROP;
        public bool SMACK;

    }
    public SoundToAssign soundsToAsign;

    // Start is called before the first frame update
    void Start()
    {
         loader = FindObjectOfType<FMODLoader>();
        result = loader.getSystem().createChannelGroup(gameObject.name, out channelGroup);
        FMODLoader.ERRCHECK(result);

        
        result = channelGroup.setVolume(1f);
        FMODLoader.ERRCHECK(result);

        VECTOR pos;
        VECTOR zero;
        zero.x = 0;
        zero.y = 0;
        zero.z = 0;
        Vector3 position = transform.position;
        Utils.convertVector(out pos, ref position);

        channelGroup.set3DAttributes(ref pos, ref zero);

        ChannelGroup master;
        loader.getSystem().getMasterChannelGroup(out master);
        result = master.addGroup(channelGroup);
        FMODLoader.ERRCHECK(result);



    }

    // Update is called once per frame
    void Update()
    {

        VECTOR pos;
        VECTOR zero;
        zero.x = 0;
        zero.y = 0;
        zero.z = 0;
        Vector3 position = transform.position;
        Utils.convertVector(out pos, ref position);
        if (Input.GetKeyDown(laughButton))
        {
            playSound(FMODLoader.SOUNDS.A_TONE);
        }
        
        result = channelGroup.set3DAttributes(ref pos, ref zero);
        FMODLoader.ERRCHECK(result);
        
    }


    public void playSound(FMODLoader.SOUNDS sound)
    {
        Channel channel = channels[sound];
        result = loader.getSystem().playSound(loader.getSound(sound), channelGroup, false, out channel);
        FMODLoader.ERRCHECK(result);
        
        VECTOR pos;
        VECTOR zero;
        zero.x = 0;
        zero.y = 0;
        zero.z = 0;
        Vector3 position = transform.position;
        Utils.convertVector(out pos, ref position);

        result = channels[sound].set3DAttributes(ref pos, ref zero);
        FMODLoader.ERRCHECK(result);

        if (!reverbDependent)
        {
            result = channels[sound].setReverbProperties(0, 0);
            FMODLoader.ERRCHECK(result);
        }
    }

    public void stopSound(FMODLoader.SOUNDS sound)
    {
        result = channels[sound].stop();
        FMODLoader.ERRCHECK(result);
    }
}
