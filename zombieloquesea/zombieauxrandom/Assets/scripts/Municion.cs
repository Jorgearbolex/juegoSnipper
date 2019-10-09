using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{ 
    public GameObject myMunicion;
     void OnCollisionEnter(Collision col) 
    {
      if (col.transform.tag == "heroe")
      {
        myMunicion.SetActive(true);  
      }  
    }
}
