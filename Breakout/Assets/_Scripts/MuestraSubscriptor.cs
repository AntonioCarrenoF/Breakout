using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuestraSubscriptor : MonoBehaviour
{

    MuestraEventos Subscriptor;
    // Start is called before the first frame update
    void Start()
    {
        Subscriptor = GetComponent<MuestraEventos>();
        Subscriptor.EnCasoDeEspacioPresionado += MensajeEscuchadoPorElSubscriptor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MensajeEscuchadoPorElSubscriptor(object sender, EventArgs e)
    {
        Debug.Log("el evento ha sido escuchado desde otra clase");
        Subscriptor.EnCasoDeEspacioPresionado -= MensajeEscuchadoPorElSubscriptor;
    }
}
