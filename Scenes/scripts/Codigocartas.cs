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
        // Si ya se han seleccionado el n�mero m�ximo de im�genes, desactivamos todas las im�genes y limpiamos la lista de selecci�n
        if (selectedImages.Count == maxSelectedImages)
        {
            // Buscamos si hay dos im�genes con el mismo source image
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

            // Si hay dos im�genes con el mismo source image, desactivamos todas las im�genes y las im�genes de los botones
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
                // Si no hay dos im�genes con el mismo source image, desactivamos todas las im�genes
                foreach (GameObject selectedImage in selectedImages)
                {
                    selectedImage.SetActive(false);
                }
            }
            selectedImages.Clear();
        }

        // A�adimos o eliminamos la imagen seleccionada de la lista de im�genes seleccionadas
        if (selectedImages.Contains(image))
        {
            selectedImages.Remove(image);
        }
        else
        {
            selectedImages.Add(image);
        }

        // Activamos o desactivamos las im�genes seleccionadas
        foreach (GameObject selectedImage in selectedImages)
        {
            selectedImage.SetActive(true);
        }
    }
}
