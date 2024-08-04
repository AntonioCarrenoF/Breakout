using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDownDificultad : MonoBehaviour
{
    public Opciones opciones;
    private TMP_Dropdown dificultad;

    // Start is called before the first frame update
    private void Start()
    {
        dificultad = GetComponent<TMP_Dropdown>();
        dificultad.onValueChanged.AddListener(delegate { opciones.CambiarDificultad(dificultad.value); });
    }

}
