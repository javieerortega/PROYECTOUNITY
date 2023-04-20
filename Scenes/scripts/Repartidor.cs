using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repartidor : MonoBehaviour
{
        public List<Image> originalImages;
        public int numberOfDuplicates;
        public Transform parentTransform;

        void Start()
        {
            // Duplica las imágenes y las coloca de forma aleatoria
            foreach (Image originalImage in originalImages)
            {
                for (int i = 0; i < numberOfDuplicates; i++)
                {
                    Image newImage = Instantiate(originalImage, parentTransform);
                    newImage.rectTransform.anchoredPosition = new Vector2(Random.Range(-300f, 300f), Random.Range(-200f, 200f));
                }
            }
        }
    }
