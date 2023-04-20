using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codigocartas : MonoBehaviour
{
    public List<GameObject> selectedImages = new List<GameObject>();
    private int maxSelectedImages = 2;

    void Start()
    {

        {

        }
    }

    void Update()
    {

    }

    public void OnImageClick(GameObject image)
    {
        // Si ya se han seleccionado el número máximo de imágenes, desactivamos todas las imágenes y limpiamos la lista de selección
        if (selectedImages.Count == maxSelectedImages)
        {
            bool match = selectedImages[0].GetComponentInChildren<Image>().sprite.name == selectedImages[1].GetComponentInChildren<Image>().sprite.name;
            foreach (GameObject selectedImage in selectedImages)
            {
                if (match)
                {
                    Destroy(selectedImage);
                }
                else
                {
                    selectedImage.SetActive(false);
                }
            }
            selectedImages.Clear();
        }

        // Añadimos o eliminamos la imagen seleccionada de la lista de imágenes seleccionadas
        if (selectedImages.Contains(image))
        {
            selectedImages.Remove(image);
        }
        else
        {
            selectedImages.Add(image);
        }

        // Activamos o desactivamos las imágenes seleccionadas
        foreach (GameObject selectedImage in selectedImages)
        {
            selectedImage.SetActive(true);
        }
    }
}
