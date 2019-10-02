using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace NPC
{
    namespace Enemy
    {
        public enum zTaste
        {
            intestinoGrueso,
            hipotálamo,
            asterisco,
            higadoCanceroso,
            pelodeHipster
        }
        

        public enum State
        {
            idle,
            move,
            rotating,
            pursuing
        }

        public struct DataZombies
        {
            public Color col;
            public State estados;
            public zTaste gustosZomb;
            public int age;
            public float veloZombie;

        }
        public class Zombies : NPCRegulator
        {

            public static Color[] zCol;
            public DataZombies zombie;
            public int estadosAlAzar;
            
            private void Awake()
            {
                zCol = new Color[3] //registro de colores
                {
                 Color.cyan,
                 Color.magenta,
                 Color.green
                };
                int gustosAlAzar = Random.Range(0, 5);
                zombie.gustosZomb = (zTaste)gustosAlAzar;
                zombie.age = Random.Range(15, 101);
                zombie.veloZombie = 10f;
                edad = zombie.age;
                velocidad = zombie.veloZombie;
            }

            private void Start()
            {

                StartCoroutine(estadosComunes());

                ActualizarEstado();
                EncontrarYRemplazarCitizen();

            }

            private void Update()
            {
                if (Time.timeScale == 0) // detiene todo
                    return;


                EncontrarYRemplazarCitizen();

                ActualizarEstado();
                mostrarMensaje();

                if (distanceAlCitizen <= distanciaEntreObjetos)
                {
                    Perseguir();
                }

                else if(distanceAlHeroe <= distanciaEntreObjetos)
                {
                    Perseguir();
                }
                else
                {
                    EncontrarYRemplazarCitizen();
                    EstadosEnComun();
                }
            }

            void ActualizarEstado ()
            {
                zombie.estados = (State)estadoActual;
            }

            void mostrarMensaje()
            {
                if (distanceAlHeroe <= distanciaEntreObjetos)
                {
                    gameObject.GetComponentInChildren<TextMesh>().text = "Waaaarrrr quiero comer " + zombie.gustosZomb;
                    
                        gameObject.GetComponentInChildren<TextMesh>().transform.rotation = heroeObjet.transform.rotation; // el texto se iguala a la camara


                }
                else
                {
                    gameObject.GetComponentInChildren<TextMesh>().text = "";

                }


            }


        }
    

    }
}



