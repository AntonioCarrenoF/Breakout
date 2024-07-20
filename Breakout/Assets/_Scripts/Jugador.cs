using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public int limiteX = 23; //serializefield sirve para modificar desde unity y no directamente en el codigo
    [SerializeField] public float velocidadPaddle = 20f;
    new Transform transform;
    Vector3 mousePos2d;
    Vector3 mousePos3d;

    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update() // cualquier codigo que se ejecute para input system o manager, realizar desden update
    {
        //mousePos2d = Input.mousePosition;
        //mousePos2d.z = -Camera.main.transform.position.z;
        //mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.down * velocidadPaddle * Time.deltaTime); //time deltatime ayuda a que los objetos se muevan de forma suavizada
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.up * velocidadPaddle * Time.deltaTime);
        //}

        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * velocidadPaddle * Time.deltaTime); //con esta linea de codigo nos podemos ahorrar lo demás

        Vector3 pos = transform.position;
        //pos.x = mousePos3d.x;
        if (pos.x < -limiteX)
        {
            pos.x = -limiteX;
        }
        else if (pos.x > limiteX)
        {
            pos.x = limiteX;
        }
        transform.position = pos;
    }
}

