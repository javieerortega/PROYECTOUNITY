using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codigocartas : MonoBehaviour
{
    public List<Image> selectedImages = new List<Image>();
    private int maxSelectedImages = 2;
    void Start()
    {

    }
    void Update()
    {

    }
    public void OnImageClick(Image image)
    {
        if (selectedImages.Contains(image))
        {
            selectedImages.Remove(image);
            image.gameObject.SetActive(false); 
        }
      
        else if (selectedImages.Count < maxSelectedImages)
        {
            selectedImages.Add(image);
            image.gameObject.SetActive(true);
        }

        if (selectedImages.Count == maxSelectedImages)
        {
           
            foreach (Image selectedImage in selectedImages)
            {
                selectedImage.gameObject.SetActive(false);
            }
           
            selectedImages.Clear();
        }
    }

}
