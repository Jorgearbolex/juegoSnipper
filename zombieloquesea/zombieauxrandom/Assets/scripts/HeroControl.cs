using UnityEngine;


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

    GameObject carga;
  
    bool canShoot = true;
    bool arrojar;
   // bool mostrarCarga;
   

    void Start()
    {
        brazos = GameObject.FindGameObjectWithTag("Brazos");
       
        

        GetComponentInChildren<MeshRenderer>().material.color = col;

        Camera();

        brazos.transform.SetParent(empty.transform);

        GameObject heroe = gameObject;

        heroe.AddComponent<MoveHeroe>();
        heroe.GetComponent<MoveHeroe>().myVelo = veloHeroe;
        heroe.GetComponent<MoveHeroe>().veloCam = empty.GetComponent<FPSim>();

        finalMensaje = GameObject.Find("GAME OVER");
        finalMensaje.SetActive(false);


    }

    void PuedeDisparar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         
            canShoot = false;
        }

    }

    void Camera()
    {
        empty = new GameObject();
        empty.name = "Camera";
        empty.AddComponent<Camera>();
        empty.AddComponent<FPSim>();
        empty.tag = "MainCamera";
        empty.transform.SetParent(this.transform);
        empty.transform.localPosition = new Vector3(0f, 1.7f, 0f);


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
    }
}
