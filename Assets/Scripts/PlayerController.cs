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

        if (Input.GetKey(Up))
        {
            vel += transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(Down))
        {
            vel -= transform.forward * speed  * Time.deltaTime;
        }
        else
        {

        }
        if (Input.GetKey(Left))
        {
            vel -= transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(Right))
        {
            vel += transform.right * speed * Time.deltaTime;
        }

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
    }
}
