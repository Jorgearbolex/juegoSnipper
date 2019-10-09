using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCollisions: MonoBehaviour
{

  Ray disparo;
  
  RaycastHit impacto;

 void Update ()
 {
  if(Input.GetMouseButton(0))
  {
   disparo=Camera.main.ScreenPointToRay(Input.mousePosition);
   if(Physics.Raycast(disparo,out impacto))
   {
    Debug.Log(impacto.collider.name); 
   }
  }
 }
}
