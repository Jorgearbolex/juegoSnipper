using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using UnityEngine.UI;

namespace NPC
{
    namespace Ally
    {
        public enum nombresCitis
        {
                    RicardoMontalvant,
                    ElcharritoNegro,
                    Platano,
                     Marzorco,
                    PatriciaNieto,
                    JeanMichelBasquiat,
                    CalvinKlein,
                    Terre,
                    Omaira,
                    CarlosVivesMonda,
                    Elsimpaticoculero,
                    Sacriapiedrasdelrio,
                    Otto,
                    Elherpes,
                    Caremimbre,
                    Estabro,
                    Hanna,
                    Ofelia,
                    Cersar,
                    UribeelEterno
        }

        public enum State
        {
            idle,
            move,
            rotating,
            running
        }
        
        public struct sCitizen
        {
            public string name;
            public int age;
            public nombresCitis nombreSitis;
            public State estadoCitiz;
            public float veloCiti;
            public static explicit operator DataZombies(sCitizen exCiti) // esto de aca es para covertir explicitamente de citizen a zombie
            {
                DataZombies nuevaStruct = new DataZombies();
                nuevaStruct.age = exCiti.age;
                nuevaStruct.veloZombie = exCiti.veloCiti;

                return nuevaStruct;
            }

        }

        public class Citizen : NPCRegulator
        {
           
            public sCitizen citizen = new sCitizen();
            GameObject canvacho;
            


            void Awake()
            {
                int nomRandom = Random.Range(0, 20);
                citizen.nombreSitis = (nombresCitis)nomRandom;
                citizen.age = Random.Range(15, 101);
                citizen.veloCiti = 6f;
                ActualizarEstado();
                edad = citizen.age;
                velocidad = citizen.veloCiti;
            }

            void Start()
            {
                StartCoroutine(estadosComunes());
                EncontrarYRemplazarZombie();
                canvacho = GameObject.Find("General"); // reconocer el gameobject que es el que almacena las variables de losn contadores
            }

            void ActualizarEstado()
            {
                citizen.estadoCitiz = (State)estadoActual; // estadoActual es para actualizar el estado en el inspector, y este cast se hace de los estados comunes a el enum de los estados

            }

            void Update()
            {
                EncontrarYRemplazarZombie(); //incluyo esta función para que detecte la distancia entre el zombie y el ciudadano
                ActualizarEstado();
                MostrarMensaje();

                if (distanceAlZombie <= distanciaEntreObjetos) // esta condición hace referencia a cuando el zombien entra en el perimetro del ciudadano y este empieza a huir
                {
                    Huir();
                }
                else
                {
                    EstadosEnComun();
                }
            }

            void MostrarMensaje()
            {
               if (distanceAlHeroe <= distanciaEntreObjetos)
                {
                    gameObject.GetComponentInChildren<TextMesh>().text = "ooee valija soy " + citizen.nombreSitis + " y tengo " + citizen.age + "años";
                    if (heroeObjet != null)
                        gameObject.GetComponentInChildren<TextMesh>().transform.rotation = heroeObjet.transform.rotation; // el texto se iguala a la camara

                }

                else
                {
                    gameObject.GetComponentInChildren<TextMesh>().text = "";

                }


            }

            private void OnCollisionEnter(Collision col)
            {
                if (col.transform.name == "podrido")
                {
                    DataZombies zombieStrut = gameObject.AddComponent<Zombies>().zombie;
                    zombieStrut = (DataZombies)gameObject.GetComponent<Citizen>().citizen;
                    gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                    gameObject.name = "podrido";
                    canvacho.GetComponent<General>().c -= 1;// es la ruta hasta la variable "c" de el script General y aca resta 1
                    canvacho.GetComponent<General>().z += 1;// es la ruta hasta la variable "z" de el script General y aca suma 1

                    StopAllCoroutines();
                    Destroy(gameObject.GetComponent<Citizen>());

                }
                
               
            }
        }

       

    }

}
