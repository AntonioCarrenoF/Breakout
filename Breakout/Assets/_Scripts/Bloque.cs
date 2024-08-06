using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public int resistencia = 1;
    public UnityEvent AumentarPuntaje;
    public Opciones opciones;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }

    public virtual void RebotarBola(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        resistencia--;
   
    }

    // Start is called before the first frame update
    void Start()
    {
        if ((int)opciones.NivelDificultad == 0)
        {
            resistencia = resistencia * 1;
        }
        if ((int)opciones.NivelDificultad == 1)
        {
            resistencia = resistencia * 2;
        }
        if ((int)opciones.NivelDificultad == 3)
        {
            resistencia = resistencia * 3;
        }

     
    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            AumentarPuntaje.Invoke();
            Destroy(this.gameObject);
        }
        
    }

    public virtual void RebotarBola()
    {

    }
}
