using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Idiomas : MonoBehaviour {

    //different language
    public GameObject otroIdioma;
    //for setting the language
    public string idioma;

    //buttons text to swap
    public Text jugarTexto;
    public Text personajesTexto;
    public Text salirTexto;
    

    private void Awake()
    {
        //get this language name
        idioma = this.name;

        CargarIdioma();
        ActualizarContenido();
    }
    
    //language selection
    public void ElegirIdioma()
    {
        PlayerPrefs.SetString("idiomaElegido", idioma);
        ActualizarContenido();
    }
    
    //Update the text depending n the selected language
    void ActualizarContenido()
    {
        //depending on the selected language change the buttons text
        if (PlayerPrefs.GetString("idiomaElegido") == "Ingles")
        {
            jugarTexto.text = "JUGAR";
            personajesTexto.text = "PERSONAJE";
            salirTexto.text = "SALIR";
        }
        else if (PlayerPrefs.GetString("idiomaElegido") == "Espanol")
        {
            jugarTexto.text = "PLAY";
            personajesTexto.text = "CHARACTER";
            salirTexto.text = "QUIT";
        }

    }

    //load the language previously selected
    public void CargarIdioma()
    {
        //if not exists makes english by default
        if (!PlayerPrefs.HasKey("idiomaElegido"))
        {
            PlayerPrefs.SetString("idiomaElegido", "Ingles");
        }
            //load the previously selected language
            if (PlayerPrefs.GetString("idiomaElegido") == idioma)
        {
            GameObject.Find(PlayerPrefs.GetString("idiomaElegido")).SetActive(false);
            otroIdioma.SetActive(true);
        }
    }
}
