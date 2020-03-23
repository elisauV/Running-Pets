using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComprobarIdioma : MonoBehaviour {

    //two different text available for the language
    public Text textoUno;
    public Text textoDos;

    //two different image available for the language
    public GameObject imagen1;
    public GameObject imagen2;

    void Awake () {
        
        //check if it is the result scene
        //switch text an image for the respective language
        if (SceneManager.GetActiveScene().name == "Resultado")
        {
            if (PlayerPrefs.GetString("idiomaElegido") == "Ingles")
            {
                textoUno.text = "Continuar";
                textoDos.text = "Elegir Nivel";
                imagen2.SetActive(false);
            }
            else if (PlayerPrefs.GetString("idiomaElegido") == "Espanol")
            {
                textoUno.text = "Continue";
                textoDos.text = "Choose Level";
                imagen1.SetActive(false);
            }

            //check if it is the game over scene
            //switch text an image for the respective language
        }
        else if (SceneManager.GetActiveScene().name == "GameOver")
        {
            if (PlayerPrefs.GetString("idiomaElegido") == "Ingles")
            {
                textoUno.text = "Reintentar";
                textoDos.text = "Salir";
                imagen2.SetActive(false);
            }
            else if (PlayerPrefs.GetString("idiomaElegido") == "Espanol")
            {
                textoUno.text = "Try Again";
                textoDos.text = "Quit";
                imagen1.SetActive(false);
            }
        }

        //check if it is the levels selection scene
        //switch text an image for the respective language
        else if (SceneManager.GetActiveScene().name == "Niveles")
        {
            if (PlayerPrefs.GetString("idiomaElegido") == "Ingles")
            {
                imagen2.SetActive(false);
            }
            else if (PlayerPrefs.GetString("idiomaElegido") == "Espanol")
            {
                imagen1.SetActive(false);
            }
        }
    }
}
