using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using System.Runtime.InteropServices;



public class FMODSoundEmitter : MonoBehaviour
{
    private ChannelGroup channelGroup;
    Dictionary<FMODLoader.SOUNDS, Channel> channels = new Dictionary<FMODLoader.SOUNDS, Channel>();
    RESULT result;
    FMODLoader loader;


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
        
        foreach(KeyValuePair< FMODLoader.SOUNDS, Channel> channel in channels)
        {
            channel.Value.set3DAttributes(ref pos, ref zero);
            FMODLoader.ERRCHECK(result);
        }
    }


    public void playSound(FMODLoader.SOUNDS sound, bool reverb)
    {
        Channel channel;
        result = loader.getSystem().playSound(loader.getSound(sound), channelGroup, false, out channel);
        FMODLoader.ERRCHECK(result);

        channels[sound] = channel;

        VECTOR pos;
        VECTOR zero;
        zero.x = 0;
        zero.y = 0;
        zero.z = 0;
        Vector3 position = transform.position;
        Utils.convertVector(out pos, ref position);

        result = channels[sound].set3DAttributes(ref pos, ref zero);
        FMODLoader.ERRCHECK(result);

        if (!reverb)
        {
            result = channels[sound].setReverbProperties(0, 0);
            FMODLoader.ERRCHECK(result);
        }
    }

    public void stopSound(FMODLoader.SOUNDS sound)
    {
        if (channels.ContainsKey(sound))
        {
            bool playing;
            result = channels[sound].isPlaying(out playing);
            FMODLoader.ERRCHECK(result);
            if (playing)
            {
                result = channels[sound].stop();
                FMODLoader.ERRCHECK(result);
                channels.Remove(sound);
            }
        }
            
    }

    public void playSoundwithPitch(FMODLoader.SOUNDS sound, bool reverb,float pitch)
    {
        Channel channel;
        result = loader.getSystem().playSound(loader.getSound(sound), channelGroup, false, out channel);
        FMODLoader.ERRCHECK(result);

        channels[sound] = channel;

        VECTOR pos;
        VECTOR zero;
        zero.x = 0;
        zero.y = 0;
        zero.z = 0;
        Vector3 position = transform.position;
        Utils.convertVector(out pos, ref position);

        result = channels[sound].set3DAttributes(ref pos, ref zero);
        FMODLoader.ERRCHECK(result);

        result = channels[sound].setPitch(pitch);
        FMODLoader.ERRCHECK(result);

        if (!reverb)
        {
            result = channels[sound].setReverbProperties(0, 0);
            FMODLoader.ERRCHECK(result);
        }

    }
}
