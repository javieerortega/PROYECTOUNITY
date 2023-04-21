using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Codigocartas : MonoBehaviour
{
    public List<GameObject> selectedImages = new List<GameObject>();
    public int maxSelectedImages = 2;

    public GameObject Jugador1;
    public GameObject Jugador2;
    public int Jugador1Lives = 3;
    public int Jugador2Lives = 3;
    public Image Jugador1Image;
    public Image Jugador2Image;

    public List<GameObject> vidap1;
    public List<GameObject> vidap2;


    public bool isJugador1Turn = true;
    public Text turnText;

    void Start()
    {
        // Buscamos los objetos de los jugadores y sus imágenes correspondientes
        //Jugador1 = GameObject.Find("Jugador1");
        //Jugador2 = GameObject.Find("Jugador2");
        //Jugador1Image = Jugador1.GetComponent<Image>();
        //Jugador2Image = Jugador2.GetComponent<Image>();


        // Mostramos el turno del jugador actual
        // TextodelTurno();
    }


    void Update()
    {

    }



    public void OnImageClick(GameObject image)
    {
        // Si ya se han seleccionado el número máximo de imágenes, desactivamos todas las imágenes y limpiamos la lista de selección
        //if (selectedImages.Count == maxSelectedImages)
        //{
        //    // Buscamos si hay dos imágenes con el mismo source image
        //    bool sameImage = false;
        //    for (int i = 0; i < selectedImages.Count; i++)
        //    {
        //        Image image1 = selectedImages[i].GetComponent<Image>();
        //        for (int j = i + 1; j < selectedImages.Count; j++)
        //        {
        //            Image image2 = selectedImages[j].GetComponent<Image>();
        //            if (image1.sprite.name == image2.sprite.name)
        //            {
        //                sameImage = true;
        //                break;
        //            }
        //        }
        //        if (sameImage)
        //        {
        //            break;
        //        }
        //    }

        //    // Si hay dos imágenes con el mismo source image, desactivamos todas las imágenes y las imágenes de los botones
        //    if (sameImage)
        //    {
        //        foreach (GameObject selectedImage in selectedImages)
        //        {
        //            selectedImage.SetActive(false);
        //            Button parentButton = selectedImage.GetComponentInParent<Button>();
        //            if (parentButton != null)
        //            {
        //                Image buttonImage = parentButton.GetComponent<Image>();
        //                if (buttonImage != null)
        //                {
        //                    buttonImage.enabled = false;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // Si no hay dos imágenes con el mismo source image, reducimos las vidas del jugador correspondiente
        //        if (selectedImages[0].transform.parent == Jugador1.transform)
        //        {
        //            Jugador1Lives--;
        //            ActualizarVidas(Jugador1Lives, Jugador1Image);
        //        }
        //        else if (selectedImages[0].transform.parent == Jugador2.transform)
        //        {
        //            Jugador2Lives--;
        //            ActualizarVidas(Jugador2Lives, Jugador2Image);
        //        }

        //        // Cambiamos el turno al siguiente jugador
        //        isJugador1Turn = !isJugador1Turn;
        //        TextodelTurno();
        //    }
        //    selectedImages.Clear();
        //}






        // Añadimos o eliminamos la imagen seleccionada de la lista de imágenes seleccionadas
        //if (selectedImages.Contains(image)) // te lo hace la segunda vez que haces click en una carta
        //{
        //    selectedImages.Remove(image);
        //}
        //else  // si no hay cartas en lista, la añade
        //{
        //    selectedImages.Add(image);
        //}


      
            seleccionCarta(image);
        

     
       

       


    }



    void seleccionCarta(GameObject image)
    {

        if (isJugador1Turn)
        {
            if (selectedImages.Count >= maxSelectedImages)
            {
                Image image1 = selectedImages[0].GetComponent<Image>();
                Image image2 = selectedImages[1].GetComponent<Image>();
                if (image1.sprite.name == image2.sprite.name)
                {
                    {
                        selectedImages[0].transform.parent.gameObject.SetActive(false);
                        selectedImages[1].transform.parent.gameObject.SetActive(false);

                    }

                }

                else
                {
                    selectedImages[0].transform.gameObject.SetActive(false);
                    selectedImages[1].transform.gameObject.SetActive(false);
                    Jugador1Lives--;
                    vidap1[Jugador1Lives].gameObject.SetActive(false);
                    isJugador1Turn = false;

                }

                selectedImages.Clear();



                // Activamos o desactivamos las imágenes seleccionadas
                //foreach (GameObject selectedImage in selectedImages)
                //{
                //    selectedImage.SetActive(true);
                //}
            }

            else
            {
                selectedImages.Add(image);
                image.gameObject.SetActive(true);
            }
        }
        else 
        {
            if (selectedImages.Count >= maxSelectedImages)
            {
                Image image1 = selectedImages[0].GetComponent<Image>();
                Image image2 = selectedImages[1].GetComponent<Image>();
                if (image1.sprite.name == image2.sprite.name)
                {
                    {
                        selectedImages[0].transform.parent.gameObject.SetActive(false);
                        selectedImages[1].transform.parent.gameObject.SetActive(false);

                    }

                }

                else
                {
                    selectedImages[0].transform.gameObject.SetActive(false);
                    selectedImages[1].transform.gameObject.SetActive(false);
                    Jugador2Lives--;
                    vidap2[Jugador2Lives].gameObject.SetActive(false);
                    isJugador1Turn = true;

                }

                selectedImages.Clear();



                // Activamos o desactivamos las imágenes seleccionadas
                //foreach (GameObject selectedImage in selectedImages)
                //{
                //    selectedImage.SetActive(true);
                //}
            }

            else
            {
                selectedImages.Add(image);
                image.gameObject.SetActive(true);
            }

        }

      

    }

    void ActualizarVidas(int lives, Image playerImage)
    {
        // Actualizamos las imágenes de corazones
        if (lives == 3)
        {
            playerImage.sprite = Resources.Load<Sprite>("Corazones3");
        }
        else if (lives == 2)
        {
            playerImage.sprite = Resources.Load<Sprite>("Corazones2");
        }
        else if (lives == 1)
        {
            playerImage.sprite = Resources.Load<Sprite>("Corazones1");
        }
        else if (lives == 0)
        {
            playerImage.sprite = Resources.Load<Sprite>("Corazones0");
            // Mostramos la pantalla de Game Over
            if (isJugador1Turn)
            {
                GameOver("Player 2");
            }
            else
            {
                GameOver("Player 1");
            }
        }
    }
    void TextodelTurno()
    {
        // Actualizamos el texto de turno
        if (isJugador1Turn)
        {
            turnText.text = "Turno de Player 1";
        }
        else
        {
            turnText.text = "Turno de Player 2";
        }
    }

    void GameOver(string winner)
    {
        // Mostramos la pantalla de Game Over con el ganador correspondiente
        Debug.Log("Game Over, " + winner + " wins!");
    }
}