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
    public GameObject mensajeCarga;
    float force = 100;
    GameObject empty;
    GameObject brazos;
    GameObject bala;
    GameObject carga;
    Vector3 comienzoBala;
    bool canShoot = true;
    bool arrojar;
    bool mostrarCarga;
   

    void Start()
    {
        brazos = GameObject.FindGameObjectWithTag("Brazos");
        comienzoBala = new Vector3(0.393f, 0.3788f, 0.933f); // se define la localposition
        bala = GameObject.FindGameObjectWithTag("Bala");
        carga = GameObject.Find("Carga");

        GetComponentInChildren<MeshRenderer>().material.color = col;

        Camera();

        brazos.transform.SetParent(empty.transform);

        GameObject heroe = gameObject;

        heroe.AddComponent<MoveHeroe>();
        heroe.GetComponent<MoveHeroe>().myVelo = veloHeroe;
        heroe.GetComponent<MoveHeroe>().veloCam = empty.GetComponent<FPSim>();

        finalMensaje = GameObject.Find("GAME OVER");
        finalMensaje.SetActive(false);
        mensajeCarga = GameObject.Find("avisoCarga");// esto es para que le mensaje no se muestra desde el principio
        mensajeCarga.SetActive(false);

    }

    void PuedeDisparar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            canShoot = false;
        }

    }

    void Camera()
    {
        empty = new GameObject();
        empty.name = "Camera";
        empty.AddComponent<Camera>();
        empty.AddComponent<FPSim>();
        empty.transform.SetParent(this.transform);
        empty.transform.localPosition = new Vector3(0f, 1.7f, 0f);


    }

    void Shoot()
    {
        if (canShoot)
            bala.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
            bala.transform.SetParent(null);
    }

    void Update()
    {
        PuedeDisparar();
        
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

        if (col.gameObject.name == "carga") // esto quedan PENDIENTE para hacer que alm colisionar muestre el aviso de carga
        {
            mensajeCarga.SetActive(true);
        }
    }
}
