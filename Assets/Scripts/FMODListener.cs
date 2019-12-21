using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class FMODListener : MonoBehaviour
{
    VECTOR position;
    VECTOR velocity;
    VECTOR forward;
    VECTOR up;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RESULT result;

        Rigidbody body = GetComponent<Rigidbody>();

        Vector3 transformPos = transform.position;
        Vector3 bodyVel = body.velocity;
        Vector3 transformFor = transform.forward;
        Vector3 transformUp = transform.up;

        Utils.convertVector(out position, ref transformPos);
        Utils.convertVector(out velocity, ref bodyVel);
        Utils.convertVector(out forward, ref transformFor);
        Utils.convertVector(out up, ref transformUp);
        FMODLoader loader = FindObjectOfType<FMODLoader>();
        result = loader.getSystem().set3DListenerAttributes(0, ref position, ref velocity, ref forward, ref up);
        FMODLoader.ERRCHECK(result);
    }
    

}
