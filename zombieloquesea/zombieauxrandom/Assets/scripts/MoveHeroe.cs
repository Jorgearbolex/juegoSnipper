using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeroe : MonoBehaviour
{
    public static Vector3 pos;
    public float myVelo;
    public FPSim veloCam;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Time.timeScale == 0) // detiene todo
            return;

        transform.eulerAngles = new Vector3(0, veloCam.rotY, 0);

        if (Input.GetKey(KeyCode.W)) { transform.position += transform.forward * myVelo * Time.deltaTime;}
        if (Input.GetKey(KeyCode.S)) { transform.position -= transform.forward * myVelo * Time.deltaTime;}
        if (Input.GetKey(KeyCode.D)) { transform.position += transform.right * myVelo * Time.deltaTime;}
        if (Input.GetKey(KeyCode.A)) { transform.position -= transform.right * myVelo * Time.deltaTime;}

        pos = transform.position;

    }
}
