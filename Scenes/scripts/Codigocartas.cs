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
        // Si no hay ninguna imagen seleccionada, selecciona la primera
        if (!firstImageSelected && !secondImageSelected)
        {
            firstImageSelected = true;
        }
        // Si ya hay una imagen seleccionada, selecciona la segunda
        else if (firstImageSelected && !secondImageSelected)
        {
            secondImageSelected = true;
            // Desactiva la imagen anterior si está activada
            if (imagenAMostrar.gameObject.activeSelf)
            {
                imagenAMostrar.gameObject.SetActive(false);
            }
            // Muestra la nueva imagen
            imagenAMostrar.gameObject.SetActive(true);
        }
        // Si ya se han seleccionado dos imágenes, no hace nada
        else
        {
            return;
        }
    }
}
