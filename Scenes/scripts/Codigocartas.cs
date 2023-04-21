using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Codigocartas : MonoBehaviour
{
    public List<GameObject> selectedImages = new List<GameObject>();
    public int maxSelectedImages = 2;

    public Text Jugador2;
    public int Jugador1Lives = 3;
    public int Jugador2Lives = 3;
    public GameObject panelvictoria;
    public GameObject panelJuego;

    public List<GameObject> vidap1;
    public List<GameObject> vidap2;


    public bool isJugador1Turn = true;
    public Text turnText;

    public Text MensajeVictoria;

    public InputField jugador1;
    public InputField jugador2;
    public GameObject panelInicio;
    //public GameObject panelJuego;
    public Text MensajeFALLO;

    string nombreGanador = "";



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
            panelJuego.SetActive(false);

            if (Jugador1Lives > Jugador2Lives)
            {
                nombreGanador = jugador1.text;
            }
            else if (Jugador2Lives > Jugador1Lives)
            {
                nombreGanador = jugador2.text;
            }

            MensajeVictoria.text = "EL GANADOR ES " + nombreGanador;
            return;
        }
        if (isJugador1Turn)
        {
            turnText.text = "Turno de "+ jugador1.text;
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
            turnText.text = "Turno de "+ jugador2.text;
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

    }
 
    public void reiniciar()
    {
        SceneManager.LoadScene(0);
    }


    public void cerrar()
    {
        Application.Quit();
    }
    void GameOver(string winner)
    {
        MensajeVictoria.text = "El ganador es " + winner + "!";
        panelvictoria.SetActive(true);
    }
    public void ComenzarJuego()
    {
        if (jugador1.text.Length == 0 || jugador2.text.Length == 0 || jugador1.text.Length > 9 || jugador2.text.Length > 9)

        {
            MensajeFALLO.text = "Introduzca un nombre válido para ambos jugadores";
            return;
        }
        panelInicio.SetActive(false);
        panelJuego.SetActive(true);


    }

}