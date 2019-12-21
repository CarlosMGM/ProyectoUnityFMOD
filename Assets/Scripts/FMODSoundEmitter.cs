using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class FMODSoundEmitter : MonoBehaviour
{
    private ChannelGroup channelGroup;
    Channel channel;
    public KeyCode laughButton;
    RESULT result;
    FMODLoader loader;

    // Start is called before the first frame update
    void Start()
    {
         loader = FindObjectOfType<FMODLoader>();
        result = loader.getSystem().createChannelGroup(gameObject.name, out channelGroup);
        FMODLoader.ERRCHECK(result);

        
        result = channel.setVolume(1f);
        FMODLoader.ERRCHECK(result);

        VECTOR pos;
        VECTOR zero;
        zero.x = 0;
        zero.y = 0;
        zero.z = 0;
        Vector3 position = transform.position;
        Utils.convertVector(out pos, ref position);

        channel.set3DAttributes(ref pos, ref zero);

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
            
            result = loader.getSystem().playSound(loader.getSound(FMODLoader.SOUNDS.AHAHA), channelGroup, false, out channel);
            FMODLoader.ERRCHECK(result);


        }
        channel.set3DAttributes(ref pos, ref zero);
    }
}
