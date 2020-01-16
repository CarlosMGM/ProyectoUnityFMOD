using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;

    public float speed = 10f;

    Rigidbody rigidBody;
    Vector3 mousepos;

    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        mousepos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = Vector3.zero;

        bool playing = isWalking;
        bool notWalking = false;

        if (Input.GetKey(Up))
        {
            isWalking = true;
            vel += transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(Down))
        {
            isWalking = true;
            vel -= transform.forward * speed  * Time.deltaTime;
        }
        else
        {
            notWalking = true;
        }
        if (Input.GetKey(Left))
        {
            isWalking = true;
            vel -= transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(Right))
        {
            isWalking = true;
            vel += transform.right * speed * Time.deltaTime;
        }
        else if (notWalking)
            isWalking = false;
        if(Input.GetMouseButton(1))
        {
            Vector3 rot=Vector3.zero;
            if (Input.mousePosition.x > mousepos.x)
            {
                rot.y =(mousepos.x- Input.mousePosition.x)/50;
                transform.Rotate(rot);
            }
            else if (Input.mousePosition.x < mousepos.x)
            {
                rot.y = (mousepos.x - Input.mousePosition.x)/50;
                transform.Rotate(rot);
            }
        }

        rigidBody.velocity = vel;

        if (isWalking && !playing)
        {
            gameObject.GetComponent<FMODSoundEmitter>().playSound(FMODLoader.SOUNDS.STEPS, true);
        }
        else if (!isWalking)
        {
            gameObject.GetComponent<FMODSoundEmitter>().stopSound(FMODLoader.SOUNDS.STEPS);
        }
    }
}
