using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBordes : MonoBehaviour
{
    [Header("Configurar en el editor")]
    public float radio = 1f;
    public bool mantenerEnPantalla = false;

    [Header("Configuraciones Dinamicas")]
    public bool estaEnPantalla = true;
    public float anchoCamara;
    public float altoCamara;
    public bool salioDerecho, salioIzquierdo, salioArriba, salioAbajo;


    public void Awake()
    {
        altoCamara = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        estaEnPantalla = true;
        salioAbajo = salioArriba = salioDerecho = salioIzquierdo = false;
        if (pos.x > anchoCamara - radio)
        {
            pos.x = anchoCamara - radio;
            salioDerecho = true;
        }
        if (pos.x < -anchoCamara + radio)
        {
            pos.x = -anchoCamara + radio;
            salioIzquierdo = true;
        }
        if (pos.y >altoCamara - radio)
        {
            pos.y = anchoCamara - radio;
            salioArriba = true;
        }
        if (pos.y < -altoCamara + radio)
        {
            pos.y = -altoCamara + radio;
            salioAbajo = true;
        }
        estaEnPantalla = !(salioAbajo || salioArriba || salioDerecho || salioIzquierdo);
        if (mantenerEnPantalla && !estaEnPantalla)
        {
            transform.position = pos;
            estaEnPantalla = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 tamanoBorde = new Vector3(anchoCamara * 2, altoCamara * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, tamanoBorde);
    }
}
