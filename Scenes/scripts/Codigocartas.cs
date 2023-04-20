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
            // Buscamos si hay dos imágenes con el mismo source image
            bool sameImage = false;
            for (int i = 0; i < selectedImages.Count; i++)
            {
                Image image1 = selectedImages[i].GetComponent<Image>();
                for (int j = i + 1; j < selectedImages.Count; j++)
                {
                    Image image2 = selectedImages[j].GetComponent<Image>();
                    if (image1.sprite.name == image2.sprite.name)
                    {
                        sameImage = true;
                        break;
                    }
                }
                if (sameImage)
                {
                    break;
                }
            }

            // Si hay dos imágenes con el mismo source image, desactivamos todas las imágenes y las imágenes de los botones
            if (sameImage)
            {
                foreach (GameObject selectedImage in selectedImages)
                {
                    selectedImage.SetActive(false);
                    Button parentButton = selectedImage.GetComponentInParent<Button>();
                    if (parentButton != null)
                    {
                        Image buttonImage = parentButton.GetComponent<Image>();
                        if (buttonImage != null)
                        {
                            buttonImage.enabled = false;
                        }
                    }
                }
            }
            else
            {
                // Si no hay dos imágenes con el mismo source image, desactivamos todas las imágenes
                foreach (GameObject selectedImage in selectedImages)
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
