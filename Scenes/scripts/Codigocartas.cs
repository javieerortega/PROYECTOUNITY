using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codigocartas : MonoBehaviour
{
    private List<Image> selectedImages = new List<Image>();
    private int maxSelectedImages = 2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnImageClick(Image image)
    {
        // Si la imagen ya está seleccionada, deseleccionarla y volverla a la posición inicial
        if (selectedImages.Contains(image))
        {
            selectedImages.Remove(image);
            image.gameObject.SetActive(false); // Opcional: volver a la posición inicial
        }
        // Si la imagen no está seleccionada y no se han seleccionado el máximo de imágenes, seleccionarla
        else if (selectedImages.Count < maxSelectedImages)
        {
            selectedImages.Add(image);
            image.gameObject.SetActive(true);
        }

        // Si se han seleccionado el máximo de imágenes permitidas, hacer algo con ellas
        if (selectedImages.Count == maxSelectedImages)
        {
            // Hacer algo con las imágenes seleccionadas, por ejemplo, voltearlas
            foreach (Image selectedImage in selectedImages)
            {
                selectedImage.gameObject.SetActive(false);
            }
            // Limpiar la lista de imágenes seleccionadas
            selectedImages.Clear();
        }
    }

}
