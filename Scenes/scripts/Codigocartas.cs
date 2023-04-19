using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codigocartas : MonoBehaviour
{
    public Image imagenAMostrar;
    public Image fotito;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnImageClick()
    {
        // Desactiva la imagen anterior si está activada
        if (fotito.gameObject.activeSelf)
        {
            fotito.gameObject.SetActive(false);
        }

        // Muestra la nueva imagen
        imagenAMostrar.gameObject.SetActive(true);
    }
}
