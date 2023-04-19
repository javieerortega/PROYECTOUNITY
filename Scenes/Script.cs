using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script : MonoBehaviour
{
    public InputField jugador1;
    public InputField jugador2;
    public GameObject panelInicio;
    public GameObject panelJuego;
    public Text MensajeFALLO;
    public Text MensajeBIENVENIDA;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }   
   public void ComenzarJuego()
     { if (jugador1.text.Length == 0 || jugador2.text.Length == 0 || jugador1.text.Length > 9 || jugador2.text.Length > 9)
         {
            MensajeFALLO.text="Introduzca un nombre válido para ambos jugadores";
            return;
            }

            MensajeBIENVENIDA.text = "¡Bienvenidos al juego, " + jugador1.text + " y " + jugador2.text + "!";
            panelInicio.SetActive(false);
            panelJuego.SetActive(true);

            
        }
    }

