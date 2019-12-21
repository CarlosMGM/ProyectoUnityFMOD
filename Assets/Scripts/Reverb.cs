using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;


public class Reverb : MonoBehaviour
{
    Reverb3D reverb;
    public float minDistance = 0;
    public float maxDistance = 10;


    public REVERB_PROPERTIES properties;
    
    // Start is called before the first frame update
    void Start()
    {
      
        VECTOR ReverbPosition;
        RESULT result;
        FMODLoader loader = FindObjectOfType<FMODLoader>();
        Vector3 position = transform.position;
        Utils.convertVector(out ReverbPosition, ref position);

        result = loader.getSystem().createReverb3D(out reverb);
        reverb.set3DAttributes(ref ReverbPosition, minDistance, maxDistance);
        reverb.setActive(true);
        FMODLoader.ERRCHECK(result);

   


       
       // reverb.getProperties(ref properties);

     
        reverb.setProperties(ref properties);
        //print(propeties);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
