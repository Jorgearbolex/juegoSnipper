using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeCargaBala : MonoBehaviour
{
    GameObject cuboCarga;
    public GameObject mensajeCarga;
    GameObject carga;

    void Start()
    {
        mensajeCarga = GameObject.Find("avisoCarga");// esto es para que le mensaje no se muestra desde el principio
        mensajeCarga.SetActive(false);

    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
       

        if (col.gameObject.name == "carga") // esto quedan PENDIENTE para hacer que alm colisionar muestre el aviso de carga
        {
            mensajeCarga.SetActive(true);
        }

    }
