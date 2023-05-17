using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Codigocartas : MonoBehaviour
{
    public List<GameObject> imagenesseleccionadas = new List<GameObject>();
    public int maximagenesseleccionadas = 2;

    public Text Jugador2;
    public int Jugador1vidas = 5;
    public int Jugador2vidas = 5;
    public GameObject panelvictoria;
    public GameObject panelJuego;

    public List<GameObject> vidap1;
    public List<GameObject> vidap2;


    public bool turnojugador = true;
    public Text textoturno;

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
        if (Jugador1vidas <= 0 || Jugador2vidas <= 0)
        {
            panelvictoria.SetActive(true);
            panelJuego.SetActive(false);

            if (Jugador1vidas > Jugador2vidas)
            {
                nombreGanador = jugador1.text;
            }
            else if (Jugador2vidas > Jugador1vidas)
            {
                nombreGanador = jugador2.text;
            }

            MensajeVictoria.text = "EL GANADOR ES " + nombreGanador;
            return;
        }
        if (turnojugador)
        {
            textoturno.text = "Turno de "+ jugador1.text;
            if (imagenesseleccionadas.Count >= maximagenesseleccionadas)
            {
                Image image1 = imagenesseleccionadas[0].GetComponent<Image>();
                Image image2 = imagenesseleccionadas[1].GetComponent<Image>();
                if (image1.sprite.name == image2.sprite.name)
                {
                    {
                        imagenesseleccionadas[0].transform.parent.gameObject.SetActive(false);
                        imagenesseleccionadas[1].transform.parent.gameObject.SetActive(false);

                    }

                }

                else
                {
                    imagenesseleccionadas[0].transform.gameObject.SetActive(false);
                    imagenesseleccionadas[1].transform.gameObject.SetActive(false);
                    Jugador1vidas--;
                    vidap1[Jugador1vidas].gameObject.SetActive(false);
                    turnojugador = false;
                    

                }
               
                imagenesseleccionadas.Clear();


            }

            else
            {
                imagenesseleccionadas.Add(image);
                image.gameObject.SetActive(true);
            }
        }
        else 
        {
            textoturno.text = "Turno de "+ jugador2.text;
            if (imagenesseleccionadas.Count >= maximagenesseleccionadas)
            {
                Image image1 = imagenesseleccionadas[0].GetComponent<Image>();
                Image image2 = imagenesseleccionadas[1].GetComponent<Image>();
                if (image1.sprite.name == image2.sprite.name)
                {
                    {
                        imagenesseleccionadas[0].transform.parent.gameObject.SetActive(false);
                        imagenesseleccionadas[1].transform.parent.gameObject.SetActive(false);

                    }

                }

                else
                {
                    imagenesseleccionadas[0].transform.gameObject.SetActive(false);
                    imagenesseleccionadas[1].transform.gameObject.SetActive(false);
                    Jugador2vidas--;
                    vidap2[Jugador2vidas].gameObject.SetActive(false);
                    turnojugador = true;
                    

                }

                imagenesseleccionadas.Clear();

            }

            else
            {
                imagenesseleccionadas.Add(image);
                image.gameObject.SetActive(true);
            }

        }

      

    }

    void ActualizarVidas(int vidas, Image playerImage)
    {

        if (vidas == 3)
        {
            playerImage.sprite = Resources.Load<Sprite>("Corazones3");
        }
        else if (vidas == 2)
        {
            playerImage.sprite = Resources.Load<Sprite>("Corazones2");
        }
        else if (vidas == 1)
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