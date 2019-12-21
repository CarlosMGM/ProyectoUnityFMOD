using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Utils
{
    public static void convertVector(out FMOD.VECTOR dest, ref Vector3 orig)
    {
        if (Math.Abs(0 - orig.x) > 0.0001)
            dest.x = orig.x;
        else
            dest.x = 0;
        if (Math.Abs(0 - orig.y) > 0.0001)
            dest.y = orig.y;
        else
            dest.y = 0;
        if (Math.Abs(0 - orig.z) > 0.0001)
            dest.z = orig.z;
        else
            dest.z = 0;
    }
}

    
