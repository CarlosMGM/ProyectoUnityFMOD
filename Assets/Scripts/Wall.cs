using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
public class Wall : MonoBehaviour
{
    public float ReverbOclusion ;
    // Start is called before the first frame update
    void Start()
    {
        RESULT result;
        FMODLoader loader = FindObjectOfType<FMODLoader>();
      


        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
       // print(mesh.vertices.Length);
      //  print(mesh.vertexCount);
       // print(mesh.triangles.Length);
        //for (int i = 0; i < mesh.vertices.Length; i++)
        //{
        //   // print(mesh.vertices[i]);
        //}
        /////////////////////////////////////////
        /////TERMINAR ESTO
        /////////////////////////////////////////

        FMOD.Geometry geometry;
        FMOD.VECTOR[] vertices;
        FMOD.VECTOR vertice;



        vertices = new VECTOR[3];
        int help = 0;
        int plog;
        loader.getSystem().createGeometry(mesh.triangles.Length, mesh.triangles.Length * 3, out geometry);
        while (help < mesh.triangles.Length)
        {
            for (int i = 0; i < 3; i++)
            {


                //    vertice.x = transform.localScale.x / 0.5f;
                //    vertice.y = transform.localScale.y / 0.5f;
                //    vertice.z = transform.localScale.z / 0.5f;
                Vector3 meshVertice = mesh.vertices[mesh.triangles[help]];
                Utils.convertVector(out vertice, ref meshVertice);
                vertices.SetValue(vertice, i);
               // print(mesh.vertices[mesh.triangles[help]]);

                help++;
            }
            
            result = geometry.addPolygon(1f, ReverbOclusion, true, 3, vertices, out plog);
            FMODLoader.ERRCHECK(result);
        }
        VECTOR pos;
        VECTOR forward;
        VECTOR up;
        VECTOR scale;
        

        
        Vector3 forwardVector = transform.forward;
        Vector3 upVector = transform.rotation * Vector3.up;
        //forwardVector.Normalize();
        //upVector.Normalize();
        //forwardVector *= 10;

        //Vector3 forwardVector = transform.rotation * Vector3.forward;
        //Vector3 upVector = transform.rotation * Vector3.up;
        

        Vector3 transformPos = transform.position;

        

        Utils.convertVector(out pos, ref transformPos);

   

        Utils.convertVector(out forward, ref forwardVector);

        

        Vector3 transformScale = transform.localScale;

        Utils.convertVector(out up, ref upVector);


        Utils.convertVector(out scale, ref transformScale);


        result = geometry.setRotation(ref forward, ref up);
        geometry.setScale(ref scale);
        geometry.setPosition(ref pos);
        VECTOR v1, v2;
        geometry.getRotation(out v1, out v2);
        //print("Antes");
        //print(v1.x);
        //print(v1.y);
        //print(v1.z);


        
        FMODLoader.ERRCHECK(result);

        

        //geometry.getRotation(out v1, out v2);
        //print("Después");
        //print(v1.x);
        //print(v1.y);
        //print(v1.z);
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
