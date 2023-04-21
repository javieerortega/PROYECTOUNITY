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
    public GameObject panelvictoria;

    public List<GameObject> vidap1;
    public List<GameObject> vidap2;


    public bool isJugador1Turn = true;
    public Text turnText;

    public Text MensajeVictoria;

    void Start()
    {

    }


    void Update()
    {

    }



    public void OnImageClick(GameObject image)
    {
            seleccionCarta(image);
    }



    void seleccionCarta(GameObject image)
    {
        if (Jugador1Lives <= 0 || Jugador2Lives <= 0)
        {
            panelvictoria.SetActive(true);
        }
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
        //else if (lives == 0)
        //{
        //    playerImage.sprite = Resources.Load<Sprite>("Corazones0");
  
        //    if (isJugador1Turn)
        //    {
        //        GameOver("Player 2");
        //    }
        //    else
        //    {
        //        GameOver("Player 1");
        //    }
            
        //}
    }
    void TextodelTurno()
    {
    
        if (isJugador1Turn)
        {
            turnText.text = "Turno de Player 1";
        }
        else
        {
            turnText.text = "Turno de Player 2";
        }
    }
    public void reiniciar()
    {
        SceneManager.LoadScene(0);
    }


    public void cerrar()
    {
        Application.Quit();
    }
    public void victoria()
    {
        MensajeVictoria.text = "EL GANADOR ES";
        return;
    }

}