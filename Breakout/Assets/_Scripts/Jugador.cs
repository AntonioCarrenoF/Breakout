using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public int limiteX = 23;
    Vector3 mousePos2d;
    Vector3 mousePos3d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // cualquier codigo que se ejecute para input system o manager, realizar desden update
    {
        mousePos2d = Input.mousePosition;
        mousePos2d.z = -Camera.main.transform.position.z;
        mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);


        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        if (pos.x < -limiteX)
        {
            pos.x = -limiteX;
        }
        else if (pos.x > limiteX)
        {
            pos.x = limiteX;
        }
        this.transform.position = pos;
    }
}

