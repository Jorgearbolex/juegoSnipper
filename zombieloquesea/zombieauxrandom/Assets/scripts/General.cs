using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPC.Enemy;
using NPC.Ally;

public class General : MonoBehaviour
{
    public GameObject body;
    GameObject herom;
    GameObject zombies, citizens;
    public Color CityColor;
    public Color ZombieColor;
    public Text numZombies;
    public Text numCitizens;
    public GameObject mensaje;
    public GameObject mensajeZombie;
    public GameObject mensajeCitizen;
    public int z, c;
    public static float veloHeroe;
    static System.Random ramdi = new System.Random();
    public readonly int limitemin = ramdi.Next(5, 15);
    const int limitemax = 25;
    int contadorFrames = 0;
    public GameObject grupoZombie; // este grupo es para saber quines son desdee siempre zombies
    public GameObject grupoCitizen; // y este grupo es para verificar quinhjes se transforman
    public GameObject cubeHeroe;
    void Start()
    {
        int limiteFinal = Random.Range(limitemin, limitemax + 1);

        herom = Instantiate(cubeHeroe);
        herom.transform.tag = "heroe";
        herom.transform.position = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
        herom.transform.localScale = new Vector3(1, 3, 1);
        herom.AddComponent<HeroControl>();
        herom.GetComponent<HeroControl>().col = Color.red;
        herom.AddComponent<Rigidbody>();
        herom.name = "Heroe";

        grupoCitizen = new GameObject();
        grupoCitizen.name = "grupoCitizen";
        grupoZombie = new GameObject();
        grupoZombie.name = "grupoZombie";

        for (int i = 0; i < limiteFinal; i++)
        {
            int esZomOCiti = Random.Range(0, 2);
            if (esZomOCiti == 0)
            {
                CreatorZombies();
            }
            else if (esZomOCiti == 1)
            {
                CreatorCitizen();
            }

        }
        ContadorNPCS();
    }

    void Update()
    {
        contadorFrames++;
        if(contadorFrames >= 200)
        {
            ContadorNPCS();
            contadorFrames = 0; // de aca se reinica a cero
        }
    }

    void ContadorNPCS()
    {
        numZombies.text = "Zombies " + z;
        numCitizens.text = "Citizens " + c;
    }
    

    void CreatorCitizen ()
    {
        c++;
        citizens = GameObject.Instantiate(body) as GameObject;
        citizens.transform.position = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
        citizens.AddComponent<Citizen>();
        citizens.AddComponent<Rigidbody>();
        citizens.GetComponent<Renderer>().material.color = CityColor;
        citizens.name = "caremirla";
        citizens.transform.SetParent(grupoCitizen.transform);

        mensajeCitizen = Instantiate(mensaje);
        mensajeCitizen.name = "myMensajeCitizen";
        mensajeCitizen.transform.SetParent(citizens.transform);
        mensajeCitizen.transform.localPosition = Vector3.up;
    }

    void CreatorZombies ()
    {

        z++;
        zombies = GameObject.Instantiate(body) as GameObject;
        zombies.transform.position = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        zombies.AddComponent<Zombies>();
        zombies.AddComponent<Rigidbody>();
        zombies.GetComponent<Zombies>().zombie.col = Zombies.zCol[Random.Range(0, 3)];
        zombies.GetComponent<Renderer>().material.color = zombies.GetComponent<Zombies>().zombie.col;
        zombies.name = "podrido";
        zombies.transform.SetParent(grupoZombie.transform);
        zombies.transform.localScale = new Vector3(1, 2, 1);

        mensajeZombie = Instantiate(mensaje); //
        mensajeZombie.name = "myMensajeZomb";
        mensajeZombie.transform.SetParent(zombies.transform);
        mensajeZombie.transform.localPosition = Vector3.up;

        
    }
}


