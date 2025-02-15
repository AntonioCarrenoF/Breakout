using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    public bool isGameStarted = false;
    [SerializeField] public float velocidadBola=20.0f;
    Vector3 ultimaPosicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    Rigidbody rigidbody;
    private ControlBordes control;
    public UnityEvent BolaDestruida;
    public Opciones opciones;


    private void Awake()
    {
        control = GetComponent<ControlBordes>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        velocidadBola = opciones.velocidadBola;

    }

    // Update is called once per frame
    void Update()
    {
        if (control.salioAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
        }

        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("la bola tocó el borde superior");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioArriba = false;
            control.enabled = false; //se agregó debido a que mi latop corre demasiado rapido
            Invoke("HabilitarControl", 0.2f); //se agregó debido a que mi latop corre demasiado rapido
        }

        if (control.salioDerecho)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("la bola tocó el borde derecho");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioDerecho = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (control.salioIzquierdo)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("la bola tocó el borde izquierdo");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioIzquierdo = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Submit"))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = velocidadBola * Vector3.up;
            }
        }

    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }

    private void FixedUpdate()
    {
        ultimaPosicion = transform.position;
    }

    public void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }
}
