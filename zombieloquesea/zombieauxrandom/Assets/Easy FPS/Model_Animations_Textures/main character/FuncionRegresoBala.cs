using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;

public class FuncionRegresoBala : MonoBehaviour
{
    Vector3 comienzoBala;
    GameObject weapon01;
    void Start()
    {
        comienzoBala = new Vector3(0.3931f, 0.3802f, 0.9362f); // se define la localposition
        weapon01 = GameObject.Find("Weapon01");
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.GetComponent<Zombies>())
        {
            this.transform.SetParent(weapon01.transform);
            transform.localPosition = comienzoBala;

        }
        else if(col.gameObject.GetComponent<Object>())
        {
            this.transform.SetParent(weapon01.transform);

            transform.localPosition = comienzoBala;
        }
            

        
    }
}
