using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;


public class HeroControl : MonoBehaviour 
{

    public Color col;
    public static System.Random veloRamdHeroe = new System.Random();
    public readonly float veloHeroe = veloRamdHeroe.Next (10, 14);
    public GameObject finalMensaje;
    float force = 100;
    GameObject empty;
    GameObject brazos;
    GameObject bala;
    Vector3 comienzoBala;
    bool canShoot = true;

    void Start()
    {
        brazos = GameObject.FindGameObjectWithTag("Brazos");
        comienzoBala = new Vector3(0.3931f, 0.3802f, 0.9362f); // se define la localposition
        bala = GameObject.FindGameObjectWithTag("Bala");

        GetComponentInChildren<MeshRenderer>().material.color = col;

        empty = new GameObject();
        empty.name = "Camera";
        empty.AddComponent<Camera>();
        empty.AddComponent<FPSim>();
        empty.transform.SetParent(this.transform);
        empty.transform.localPosition = new Vector3(0f,1.7f,0f);

        brazos.transform.SetParent(empty.transform);

        GameObject heroe = gameObject;

        heroe.AddComponent<MoveHeroe>();
        heroe.GetComponent<MoveHeroe>().myVelo = veloHeroe;
        heroe.GetComponent<MoveHeroe>().veloCam = empty.GetComponent<FPSim>();

        finalMensaje = GameObject.Find("GAME OVER");
        finalMensaje.SetActive(false);// esto es para que le mensaje no se muestra desde el principio

    }

    void puedeDisparar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Shoot();
            canShoot = false;
        }

    }


    void Shoot()
    {
        if (canShoot)
            bala.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
            bala.transform.SetParent(null);
    }

    void Update()
    {
        puedeDisparar();

    }

    

    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "podrido")
        {
            finalMensaje.SetActive(true);
            Time.timeScale = 0;
        }


        if (bala.transform.localPosition == comienzoBala)
        {
            canShoot = true;
        }
    }
}
