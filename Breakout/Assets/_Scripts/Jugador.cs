using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public int limiteX = 23;
    [SerializeField] public float velocidadPaddle = 40f;
    new Transform transform;
    //Vector3 mousePos2d;
    //Vector3 mousePos3d;

    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //mousePos2d = Input.mousePosition;
        //mousePos2d.z = -Camera.main.transform.position.z;
        //mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.down * velocidadPaddle * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.up * velocidadPaddle * Time.deltaTime);
        //}

        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * velocidadPaddle * Time.deltaTime);

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

