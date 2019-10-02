using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;




public class NPCRegulator : MonoBehaviour
{
    public float distanciaEntreObjetos = 15.0f;
    public int rotaparaqueLado, edad, estadoActual;
    public float velocidad;
    public GameObject heroeObjet;
    public GameObject citizenObjet;
    public GameObject zombieObjet;
    public Vector3 direction;
    Vector3 distPlayer;
    Vector3 distZombie;
    Vector3 distCitizen;
    public float distanceAlHeroe;
    public float distanceAlZombie;
    public float distanceAlCitizen;

    public void EstadosEnComun()
    {
       if (estadoActual == 0) { } // estado Idle
       if (estadoActual == 1) // estado moving
        {
            transform.position += transform.forward * velocidad * (15 / (float)edad) * Time.deltaTime;
        }

        if (estadoActual == 2)// estado de rotation
        {
            if (rotaparaqueLado == 0)
            {
                transform.eulerAngles += new Vector3(0, Random.Range(10f, 150f) * Time.deltaTime);
            }
            if (rotaparaqueLado == 1) // estado de rotation
            {
                transform.eulerAngles += new Vector3(0, Random.Range(-10f, -150f) * Time.deltaTime);
            }
        }        
    }

    public IEnumerator estadosComunes()
    {
        while (true)
        {
            estadoActual = Random.Range(0, 3); 
            if (estadoActual == 2)
            {
                rotaparaqueLado = Random.Range(0, 2);
            }
            yield return new WaitForSeconds(3);
        }
    }



    public void EncontrarYRemplazarCitizen()
    {
        if (heroeObjet == null)
            heroeObjet = GameObject.Find("Heroe");

        
            distPlayer = heroeObjet.transform.position - transform.position;
            distanceAlHeroe = distPlayer.magnitude;
        
        GameObject[] TodosLosObjetos = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject objetocualquiera in TodosLosObjetos)
        {
            Component seConvierteEn = objetocualquiera.GetComponent<Citizen>();
            if (seConvierteEn != null)
            {
                citizenObjet = objetocualquiera;
                distCitizen = citizenObjet.transform.position - transform.position;
                distanceAlCitizen = distCitizen.magnitude;
                if (distanceAlCitizen <= distanciaEntreObjetos)
                {
                    break;
                }
            }

        }
    }

    public void EncontrarYRemplazarZombie()
    {
        if (heroeObjet == null)
            heroeObjet = GameObject.Find("Heroe");

        
        
            distPlayer = heroeObjet.transform.position - transform.position;
            distanceAlHeroe = distPlayer.magnitude;
        

        GameObject[] TodosLosObjetos = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject objetocualquiera in TodosLosObjetos)
        {
            Component seConvierteEn = objetocualquiera.GetComponent<Zombies>();

            if (seConvierteEn != null)
            {
                zombieObjet = objetocualquiera;
                distZombie = zombieObjet.transform.position - transform.position;
                distanceAlZombie = distZombie.magnitude;
                if (distanceAlZombie <= distanciaEntreObjetos)
                {
                    break;
                }
            }

        }
    }

    public void Perseguir()
    {
        estadoActual = 3; // define la posición en el enum

        if (distanceAlCitizen <= distanciaEntreObjetos) // la distancia entre el zombie y el ciudadano
        {
            direction = Vector3.Normalize(citizenObjet.transform.position - transform.position);
            transform.position += direction * velocidad * (15 / (float)edad) * Time.deltaTime;
        }
        else if (distanceAlHeroe <= distanciaEntreObjetos)  // la distancia entre el zombie y el heroe
        {
            
                direction = Vector3.Normalize(heroeObjet.transform.position - transform.position);
                transform.position += direction * velocidad * (15 / (float)edad) * Time.deltaTime;
            
                
        }
    }

    public void Huir()
    {

        estadoActual = 3; // define la posición en el enum
        
            direction = Vector3.Normalize(zombieObjet.transform.position - transform.position);
            transform.position += -1 * direction * velocidad * (15 / (float)edad) * Time.deltaTime;
       
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }


}
